# === BUILD STAGE ===
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
# Copy file .csproj của project API vào thư mục con (chỉ copy file này)
COPY QLTSV_API/QLTSV_API.csproj QLTSV_API/
# Khôi phục các thư viện
RUN dotnet restore QLTSV_API/QLTSV_API.csproj

# Copy toàn bộ code còn lại
COPY . .

# Publish ứng dụng
RUN dotnet publish QLTSV_API/QLTSV_API.csproj -c Release -o /app/publish

# === RUNTIME STAGE ===
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
# Copy kết quả Build sang thư mục chạy
COPY --from=build /app/publish .

# Cấu hình cổng và chạy ứng dụng
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "QLTSV_API.dll"]