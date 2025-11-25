using QLTVS_API.DTO;
using QLTVS_API.Models;
using QLTVS_API.DAO;

using System;

namespace QLTVS_API.BUS
{
    public class ThanhVienBUS
    {
        private readonly ThanhVienDAO _dao;

        public ThanhVienBUS(ThanhVienDAO dao)
        {
            _dao = dao;
        }

        public string ThemSinhVien(SinhVienDTO dto)
        {
            if (_dao.CheckSinhVienExists(dto.MaSV)) return "Mã sinh viên đã tồn tại!";
            if (_dao.CheckTaiKhoanExists(dto.MaSV)) return "Tài khoản đã tồn tại!";

            // Tạo data SinhVien
            var sv = new Sinhvien
            {
                Masv = dto.MaSV,
                Hoten = dto.HoTen,
                Lop = dto.Lop,
                Email = dto.Email,
                Sdt = dto.SDT
            };

            // Tạo data TaiKhoan (Pass mặc định 123456)
            var tk = new Taikhoan
            {
                Tendangnhap = dto.MaSV,
                Matkhau = "123456",
                Vaitro = "SinhVien",
                Masv = dto.MaSV
            };

            try
            {
                _dao.CreateSinhVienAccount(sv, tk);
                return "OK";
            }
            catch (Exception ex)
            {
                return "Lỗi hệ thống: " + ex.Message;
            }
        }

        public string ThemQuanLy(QuanLyDTO dto)
        {
            if (_dao.CheckQuanLyExists(dto.MaQL)) return "Mã quản lý đã tồn tại!";
            if (_dao.CheckTaiKhoanExists(dto.MaQL)) return "Tài khoản đã tồn tại!";

            var ql = new Quanly
            {
                Maql = dto.MaQL,
                Hoten = dto.HoTen,
                Email = dto.Email,
                Sdt = dto.SDT
            };

            // Pass mặc định admin123
            var tk = new Taikhoan
            {
                Tendangnhap= dto.MaQL,
                Matkhau = "admin123",
                Vaitro = "QuanLy",
                Maql = dto.MaQL
            };

            try
            {
                _dao.CreateQuanLyAccount(ql, tk);
                return "OK";
            }
            catch (Exception ex)
            {
                return "Lỗi hệ thống: " + ex.Message;
            }
        }
    }
}