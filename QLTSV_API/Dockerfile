# === BUILD STAGE ===
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Đổi thư mục làm việc sang thư mục gốc của Solution
WORKDIR /src
# Copy file project .csproj vào thư mục con QLTSV_API/
COPY ["QLTSV_API/QLTSV_API.csproj", "QLTSV_API/"] 

# KHÔI PHỤC CÁC THƯ VIỆN (Thêm --no-cache để buộc làm lại từ đầu)
RUN dotnet restore "QLTSV_API/QLTSV_API.csproj" --no-cache

# Copy toàn bộ code còn lại
COPY . .

# Publish ứng dụng (chỉ định file csproj để build, thêm --no-cache)
RUN dotnet publish "QLTSV_API/QLTSV_API.csproj" -c Release -o /app/publish --no-cache

# === RUNTIME STAGE ===
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Cấu hình cổng và chạy ứng dụng
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "QLTSV_API.dll"]