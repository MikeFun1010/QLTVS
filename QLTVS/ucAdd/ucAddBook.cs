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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace QLTVS.ucAdd
{
    public partial class ucAddBook : UserControl
    {
        public event EventHandler<Book> OnBookSaved; // Gửi dữ liệu ra ngoài
        private Book currentBook = null;
        private bool isEditMode = false;

        public ucAddBook()
        {
            InitializeComponent();
            SetupForAdd();
        }

        // Gọi khi SỬA
        public void LoadForEdit(Book book)
        {
            currentBook = book;
            isEditMode = true;

            textBox_MaTL.Text = book.MaTaiLieu;
            textBox_TenTL.Text = book.TenTaiLieu;
            comboBox_TheLoai.Text = book.MaTheLoai;
            textBox_TacGia.Text = book.TacGia;
            textBox_NamXB.Text = book.NamXuatBan.ToString();
            textBox_NXB.Text = book.NhaXuatBan;
            textBox_SL.Text = book.SoLuong.ToString();
            textBox_Link.Text = book.LinkTaiLieu;

            button_Them.Text = "Lưu thay đổi";
            groupBox1.Text = "SỬA TÀI LIỆU";
        }

        private void SetupForAdd()
        {
            isEditMode = false;
            currentBook = null;
            button_Them.Text = "Thêm";
            textBox_MaTL.Clear();
            textBox_TenTL.Clear();
            comboBox_TheLoai.SelectedIndex = -1;
            textBox_TacGia.Clear();
            textBox_NamXB.Clear();
            textBox_NXB.Clear();
            textBox_SL.Clear();
            textBox_Link.Clear();
        }

        private void CloseForm()
        {
            if (this.FindForm() is Form form) form.Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBox_MaTL.Text) ||
                string.IsNullOrWhiteSpace(textBox_TenTL.Text) ||
                comboBox_TheLoai.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(textBox_NamXB.Text) ||
                string.IsNullOrWhiteSpace(textBox_SL.Text) ||
                !int.TryParse(textBox_NamXB.Text, out _) ||
                !int.TryParse(textBox_SL.Text, out _))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void button_Them_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var book = new Book
            {
                MaTaiLieu = textBox_MaTL.Text.Trim(),
                TenTaiLieu = textBox_TenTL.Text.Trim(),
                MaTheLoai = comboBox_TheLoai.Text,
                TacGia = textBox_TacGia.Text.Trim(),
                NamXuatBan = int.Parse(textBox_NamXB.Text),
                NhaXuatBan = textBox_NXB.Text.Trim(),
                SoLuong = int.Parse(textBox_SL.Text),
                LinkTaiLieu = textBox_Link.Text.Trim()
            };

            OnBookSaved?.Invoke(this, book); // Gửi dữ liệu ra ngoài
            CloseForm();
        }

        private void button_Dong_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
    }
}
