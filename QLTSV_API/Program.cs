using Microsoft.EntityFrameworkCore;
using QLTVS_API.Models;
using QLTVS_API.DAO;
using QLTVS_API.BUS;// Nếu dòng này báo đỏ, hãy kiểm tra lại tên namespace trong folder Models

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// 1. ĐĂNG KÝ DỊCH VỤ (SERVICES)
// ==========================================

// Thêm Controllers (Quan trọng cho mô hình 3 lớp)
builder.Services.AddControllers();

// Cấu hình Swagger (để test API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ThanhVienDAO>();
builder.Services.AddScoped<ThanhVienBUS>();

// --- CẤU HÌNH KẾT NỐI DATABASE (POSTGRESQL) ---
// Đây là đoạn quan trọng nhất bạn cần thêm
// Ưu tiên lấy từ biến môi trường của Render, nếu không có thì lấy chuỗi mặc định (để chạy local)
var host = Environment.GetEnvironmentVariable("PGHOST");
var user = Environment.GetEnvironmentVariable("PGUSER");
var pass = Environment.GetEnvironmentVariable("PGPASSWORD");
var db = Environment.GetEnvironmentVariable("PGDATABASE");

// Nếu chạy trên Render (có 4 biến) thì dùng 4 biến đó, nếu không thì dùng chuỗi Local
var connectionString = (host != null && user != null)
    ? $"Host={host};Database={db};Username={user};Password={pass}"
    : "Host=localhost;Port=5432;Database=QLTVS;Username=postgres;Password=123456";

builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseNpgsql(connectionString));
// ----------------------------------------------

var app = builder.Build();

// ==========================================
// 2. CẤU HÌNH PIPELINE (MIDDLEWARE)
// ==========================================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Kích hoạt định tuyến cho Controllers (Quan trọng)
app.MapControllers();

// --- (Đoạn WeatherForecast mẫu bên dưới giữ lại để test, sau này xóa cũng được) ---
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}