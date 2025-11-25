using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Text;


namespace QLTVS
{
    public class SinhVienDTO
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string Lop { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
    }

    public class QuanLyDTO
    {
        public string MaQL { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
    }

    public class ApiService
    {
        private readonly string BaseUrl = "https://localhost:7000/api/ThanhVien"; // Nhớ check lại Port

        // --- HÀM CŨ (GIỮ NGUYÊN) ---
        public async Task<bool> ThemThanhVien(object data, string loai)
        {
            // ... (Code cũ của bạn giữ nguyên) ...
            // Code mẫu để tránh lỗi biên dịch khi copy paste:
            using (HttpClient client = new HttpClient())
            {
                string endpoint = loai == "SV" ? "them-sinhvien" : "them-quanly";
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                try
                {
                    var response = await client.PostAsync($"{BaseUrl}/{endpoint}", content);
                    return response.IsSuccessStatusCode;
                }
                catch { return false; }
            }
        }

        // --- CÁC HÀM MỚI CẦN THÊM ---

        public async Task<List<SinhVienDTO>> LayDanhSachSinhVien()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync($"{BaseUrl}/get-all-sinhvien"); // Bạn cần viết thêm API này bên Backend nhé
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<SinhVienDTO>>(json);
                    }
                }
                catch { }
                return new List<SinhVienDTO>(); // Trả về rỗng nếu lỗi
            }
        }

        public async Task<List<QuanLyDTO>> LayDanhSachQuanLy()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync($"{BaseUrl}/get-all-quanly"); // Bạn cần viết thêm API này bên Backend nhé
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<QuanLyDTO>>(json);
                    }
                }
                catch { }
                return new List<QuanLyDTO>();
            }
        }
    }
}
