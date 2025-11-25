# === BUILD STAGE ===
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Đổi thư mục làm việc thành thư mục chứa file .csproj
WORKDIR /src/QLTSV_API
# Copy file project .csproj vào thư mục làm việc hiện tại
COPY ["QLTSV_API/QLTSV_API.csproj", ""]
# Chạy dotnet restore
RUN dotnet restore

# Copy toàn bộ code
COPY . .
# Publish ứng dụng
RUN dotnet publish -c Release -o /app/publish

# === RUNTIME STAGE ===
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Cấu hình cổng và chạy ứng dụng
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "QLTSV_API.dll"]