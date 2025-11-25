using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTVS.class_test_
{
    public class MemberInfo
    {
        public string Ma { get; set; }
        public string HoTen { get; set; }
        public string LopOrChucVu { get; set; } // Lớp (SV) hoặc Chức vụ (QL)
        public string Email { get; set; }
        public string SDT { get; set; }
        public string Loai { get; set; } // "SV" hoặc "QL"
    }
}
