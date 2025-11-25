using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLTVS_API.BUS;
using QLTVS_API.DTO;
using QLTVS_API.BUS;

namespace QLTVS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThanhVienController : ControllerBase
    {
        private readonly ThanhVienBUS _bus;

        public ThanhVienController(ThanhVienBUS bus)
        {
            _bus = bus;
        }

        [HttpPost("them-sinhvien")]
        public IActionResult ThemSinhVien([FromBody] SinhVienDTO sv)
        {
            string kq = _bus.ThemSinhVien(sv);
            if (kq == "OK") return Ok(new { message = "Thêm thành công" });
            return BadRequest(new { message = kq });
        }

        [HttpPost("them-quanly")]
        public IActionResult ThemQuanLy([FromBody] QuanLyDTO ql)
        {
            string kq = _bus.ThemQuanLy(ql);
            if (kq == "OK") return Ok(new { message = "Thêm thành công" });
            return BadRequest(new { message = kq });
        }
    }
}
