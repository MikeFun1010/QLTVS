using QLTVS.class_test_;
using QLTVS.ucAdd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTVS
{
    public partial class ucMember : UserControl
    {
        public ucMember()
        {
            InitializeComponent();
            SetupDataGridView(); // GỌI HÀM MỚI
        }

        private void SetupDataGridView()
        {
            dataGridView1.Columns.Clear(); // Xóa nếu có

            dataGridView1.Columns.Add("Mã", "Mã số");
            dataGridView1.Columns.Add("HoTen", "Họ và tên");
            dataGridView1.Columns.Add("Lop", "Lớp/Chức vụ");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns.Add("SDT", "Số điện thoại");
            dataGridView1.Columns.Add("Loai", "Phân loại");
            // Tùy chọn: căn chỉnh, chiều rộng
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;

            // Không cho thêm dòng mới ở dưới cùng
            dataGridView1.AllowUserToAddRows = false;
        }

        private async void ucMember_Load(object sender, EventArgs e)
        {
            await LoadDataFromApi();
        }

        private async Task LoadDataFromApi()
        {
            dataGridView1.Rows.Clear();
            ApiService api = new ApiService();

            // 1. Lấy danh sách Sinh Viên
            var listSV = await api.LayDanhSachSinhVien();
            if (listSV != null)
            {
                foreach (var sv in listSV)
                {
                    dataGridView1.Rows.Add(sv.MaSV, sv.HoTen, sv.Lop, sv.Email, sv.SDT, "Sinh Viên");
                }
            }

            // 2. Lấy danh sách Quản Lý
            var listQL = await api.LayDanhSachQuanLy();
            if (listQL != null)
            {
                foreach (var ql in listQL)
                {
                    dataGridView1.Rows.Add(ql.MaQL, ql.HoTen, "Quản Lý", ql.Email, ql.SDT, "Quản Lý");
                }
            }
        }

        private void button_Them_Click(object sender, EventArgs e)
        {
            OpenAddEditForm(null);
        }

        private void button_Xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
        }

        private void button_Sua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            // Map dữ liệu từ Grid sang MemberInfo để truyền vào form sửa
            var row = dataGridView1.CurrentRow;
            var member = new MemberInfo
            {
                Ma = row.Cells[0].Value.ToString(),
                HoTen = row.Cells[1].Value.ToString(),
                LopOrChucVu = row.Cells[2].Value.ToString(),
                Email = row.Cells[3].Value.ToString(),
                SDT = row.Cells[4].Value.ToString(),
                Loai = row.Cells[5].Value.ToString() == "Sinh Viên" ? "SV" : "QL"
            };

            OpenAddEditForm(member);
        }
        private void OpenAddEditForm(MemberInfo member)
        {
            // Tạo Form chứa
            var form = new Form
            {
                Text = member == null ? "THÊM THÀNH VIÊN" : "SỬA THÀNH VIÊN",
                Size = new Size(600, 450),
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowIcon = false
            };

            // Nhúng UserControl ucAddMember vào Form
            var uc = new ucAddMember();
            uc.Dock = DockStyle.Fill;

            if (member != null) uc.LoadForEdit(member);

            // Đăng ký sự kiện: Khi lưu thành công thì làm gì?
            uc.OnMemberSaved += async (s, savedMember) =>
            {
                // Cách 1: Thêm trực tiếp vào Grid (Nhanh, đỡ gọi API lại)
                AddToGrid(savedMember);

                // Cách 2 (Khuyên dùng): Load lại toàn bộ từ API để đảm bảo đồng bộ
                // await LoadDataFromApi(); 
            };

            form.Controls.Add(uc);
            form.ShowDialog(this); // Hiện form dạng Modal (không bấm được form cha khi form con đang mở)
        }

        private void AddToGrid(MemberInfo member)
        {
            if (member.Loai == "SV")
            {
                dataGridView1.Rows.Add(member.Ma, member.HoTen, member.LopOrChucVu, member.Email, member.SDT);
            }
            else
            {
                dataGridView1.Rows.Add(member.Ma, member.HoTen, "", member.Email, member.SDT); // QL: không có lớp
            }
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu click vào Header hoặc click ra ngoài thì bỏ qua
            if (e.RowIndex < 0 || dataGridView1.CurrentRow == null)
                return;

            // Lấy dòng hiện tại
            var row = dataGridView1.CurrentRow;

            // Tạo object MemberInfo từ dòng được chọn
            var member = new MemberInfo
            {
                Ma = row.Cells[0].Value?.ToString(),
                HoTen = row.Cells[1].Value?.ToString(),
                LopOrChucVu = row.Cells[2].Value?.ToString(),
                Email = row.Cells[3].Value?.ToString(),
                SDT = row.Cells[4].Value?.ToString(),
                Loai = row.Cells[5].Value?.ToString() == "Sinh Viên" ? "SV" : "QL"
            };

            // Mở form sửa thành viên
            OpenAddEditForm(member);
        }

    }
}
