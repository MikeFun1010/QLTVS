using QLTVS_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using QLTVS_API.Models;

namespace QLTVS_API.DAO
{
    public class ThanhVienDAO
    {
        private readonly LibraryContext _context;

        public ThanhVienDAO(LibraryContext context)
        {
            _context = context;
        }

        // Kiểm tra tồn tại
        public bool CheckSinhVienExists(string maSV) => _context.Sinhviens.Any(x => x.Masv == maSV);
        public bool CheckQuanLyExists(string maQL) => _context.Quanlies.Any(x => x.Maql == maQL);
        public bool CheckTaiKhoanExists(string tenDangNhap) => _context.Taikhoans.Any(x => x.Tendangnhap == tenDangNhap);

        // Thêm Sinh Viên + Tài Khoản (Dùng Transaction)
        public void CreateSinhVienAccount(Sinhvien sv, Taikhoan tk)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Sinhviens.Add(sv);
                    _context.Taikhoans.Add(tk);
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        // Thêm Quản Lý + Tài Khoản
        public void CreateQuanLyAccount(Quanly ql, Taikhoan tk)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Quanlies.Add(ql);
                    _context.Taikhoans.Add(tk);
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}