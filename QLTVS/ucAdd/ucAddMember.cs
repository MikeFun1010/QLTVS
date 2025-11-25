using QLTVS.class_test_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTVS.ucAdd
{
    public partial class ucAddMember : UserControl
    {
        public event EventHandler<MemberInfo> OnMemberSaved;
        private MemberInfo currentMember = null;
        private bool isEditMode = false;

        public ucAddMember()
        {
            InitializeComponent();
            SetupForAdd();
        }

        public void LoadForEdit(MemberInfo member)
        {
            currentMember = member;
            isEditMode = true;

            if (member.Loai == "SV")
            {
                tabControl1.SelectedTab = tabPage_SV;
                textBox_MaSV.Text = member.Ma;
                textBox_HoTenSV.Text = member.HoTen;
                textBox_Lop.Text = member.LopOrChucVu;
                textBox_EmailSV.Text = member.Email;
                textBox_SDTSV.Text = member.SDT;
                textBox_MaSV.ReadOnly = true;
            }
            else
            {
                tabControl1.SelectedTab = tabPage_QL;
                textBox_MaQL.Text = member.Ma;
                textBox_HoTenQL.Text = member.HoTen;
                textBox_EmailQL.Text = member.Email;
                textBox_SDTQL.Text = member.SDT;
                textBox_MaQL.ReadOnly = true;
            }
            button_Add.Text = "Lưu thay đổi";
        }

        private void SetupForAdd()
        {
            isEditMode = false;
            currentMember = null;
            button_Add.Text = "Thêm";

            // Reset TextBox
            textBox_MaSV.ReadOnly = false; textBox_MaSV.Clear();
            textBox_HoTenSV.Clear(); textBox_Lop.Clear();
            textBox_EmailSV.Clear(); textBox_SDTSV.Clear();

            textBox_MaQL.ReadOnly = false; textBox_MaQL.Clear();
            textBox_HoTenQL.Clear(); textBox_EmailQL.Clear();
            textBox_SDTQL.Clear();
        }

        private void CloseForm()
        {
            if (this.ParentForm != null) this.ParentForm.Close();
        }

        private bool ValidateInput()
        {
            if (tabControl1.SelectedTab == tabPage_SV)
            {
                if (string.IsNullOrWhiteSpace(textBox_MaSV.Text) || string.IsNullOrWhiteSpace(textBox_HoTenSV.Text))
                {
                    MessageBox.Show("Nhập Mã và Tên Sinh Viên!", "Thiếu tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(textBox_MaQL.Text) || string.IsNullOrWhiteSpace(textBox_HoTenQL.Text))
                {
                    MessageBox.Show("Nhập Mã và Tên Quản Lý!", "Thiếu tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private async void button_Add_Click_1(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            object dataToSend = null;
            string loai = "";

            // 1. Gom dữ liệu
            if (tabControl1.SelectedTab == tabPage_SV)
            {
                loai = "SV";
                dataToSend = new
                {
                    MaSV = textBox_MaSV.Text.Trim(),
                    HoTen = textBox_HoTenSV.Text.Trim(),
                    Lop = textBox_Lop.Text.Trim(),
                    Email = textBox_EmailSV.Text.Trim(),
                    SDT = textBox_SDTSV.Text.Trim()
                };
            }
            else
            {
                loai = "QL";
                dataToSend = new
                {
                    MaQL = textBox_MaQL.Text.Trim(),
                    HoTen = textBox_HoTenQL.Text.Trim(),
                    Email = textBox_EmailQL.Text.Trim(),
                    SDT = textBox_SDTQL.Text.Trim()
                };
            }

            // 2. GỌI API (Chỉ khi Thêm mới)
            if (!isEditMode)
            {
                button_Add.Enabled = false;
                button_Add.Text = "Đang lưu...";

                ApiService api = new ApiService();
                bool ok = await api.ThemThanhVien(dataToSend, loai);

                button_Add.Enabled = true;
                button_Add.Text = "Thêm";

                if (!ok) return;

                // Thông báo thành công + pass
                string pass = loai == "SV" ? "123456" : "admin123";
                string user = loai == "SV" ? textBox_MaSV.Text : textBox_MaQL.Text;
                MessageBox.Show($"Thêm thành công!\nTài khoản: {user}\nMật khẩu: {pass}", "Thông báo");
            }
            else
            {
                MessageBox.Show("Chức năng sửa code sau!");
                return;
            }

            // 3. Cập nhật Grid cha
            var member = new MemberInfo();
            if (loai == "SV")
            {
                member.Ma = textBox_MaSV.Text; member.HoTen = textBox_HoTenSV.Text;
                member.LopOrChucVu = textBox_Lop.Text; member.Email = textBox_EmailSV.Text;
                member.SDT = textBox_SDTSV.Text; member.Loai = "SV";
            }
            else
            {
                member.Ma = textBox_MaQL.Text; member.HoTen = textBox_HoTenQL.Text;
                member.LopOrChucVu = "Quản lý"; member.Email = textBox_EmailQL.Text;
                member.SDT = textBox_SDTQL.Text; member.Loai = "QL";
            }

            OnMemberSaved?.Invoke(this, member);
            CloseForm();
        }

        private void button_Dong_Click_1(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void ucAddMember_Load(object sender, EventArgs e)
        {

        }
    }
}
