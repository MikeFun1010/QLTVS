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
    public partial class ucBook : UserControl
    {
        public ucBook()
        {
            InitializeComponent();
            SetupDataGridView(); // GỌI HÀM MỚI
        }

        private void SetupDataGridView()
        {
            dataGridView1.Columns.Clear(); // Xóa nếu có

            dataGridView1.Columns.Add("MaTaiLieu", "Mã tài liệu");
            dataGridView1.Columns.Add("TenTaiLieu", "Tên tài liệu");
            dataGridView1.Columns.Add("TacGia", "Tác giả");
            dataGridView1.Columns.Add("NamXuatBan", "Năm xuất bản");
            dataGridView1.Columns.Add("NhaXuatBan", "Nhà xuất bản");
            dataGridView1.Columns.Add("MaTheLoai", "Thể loại");
            dataGridView1.Columns.Add("SoLuong", "Số lượng");
            dataGridView1.Columns.Add("LinkTaiLieu", "Link");

            // Tùy chọn: căn chỉnh, chiều rộng
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 160;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 160;
            dataGridView1.Columns[4].Width = 180;
            dataGridView1.Columns[5].Width = 120;
            dataGridView1.Columns[6].Width = 130;
            dataGridView1.Columns[7].Width = 180;
            // Không cho thêm dòng mới ở dưới cùng
            dataGridView1.AllowUserToAddRows = false;
        }
        private void OpenAddEditForm(Book book)
        {
            var form = new Form
            {
                Text = book == null ? "Thêm tài liệu mới" : "Sửa tài liệu",
                Size = new Size(700, 600),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.FromArgb(240, 248, 255)
            };

            var uc = new ucAddBook();
            uc.Dock = DockStyle.Fill;
            if (book != null) uc.LoadForEdit(book);

            uc.OnBookSaved += (s, savedBook) =>
            {
                if (book == null)
                    AddToGrid(savedBook);
                else
                    UpdateGrid(savedBook);
            };

            form.Controls.Add(uc);
            form.ShowDialog(this);
        }

        private void AddToGrid(Book book)
        {
            dataGridView1.Rows.Add(
                book.MaTaiLieu,
                book.TenTaiLieu,
                book.TacGia,
                book.NamXuatBan,
                book.NhaXuatBan,
                book.MaTheLoai,
                book.SoLuong,
                book.LinkTaiLieu
            );
        }

        private void UpdateGrid(Book book)
        {
            var row = dataGridView1.CurrentRow;
            row.Cells[0].Value = book.MaTaiLieu;
            row.Cells[1].Value = book.TenTaiLieu;
            row.Cells[2].Value = book.TacGia;
            row.Cells[3].Value = book.NamXuatBan;
            row.Cells[4].Value = book.NhaXuatBan;
            row.Cells[5].Value = book.MaTheLoai;
            row.Cells[6].Value = book.SoLuong;
            row.Cells[7].Value = book.LinkTaiLieu;
        }

        private void button_Them_Click(object sender, EventArgs e)
        {
            OpenAddEditForm(null);
        }

        private void button_Sua_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một tài liệu để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var book = new Book
            {
                MaTaiLieu = dataGridView1.CurrentRow.Cells[0].Value?.ToString() ?? "",
                TenTaiLieu = dataGridView1.CurrentRow.Cells[1].Value?.ToString() ?? "",
                TacGia = dataGridView1.CurrentRow.Cells[2].Value?.ToString() ?? "",
                NamXuatBan = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value ?? 0),
                NhaXuatBan = dataGridView1.CurrentRow.Cells[4].Value?.ToString() ?? "",
                MaTheLoai = dataGridView1.CurrentRow.Cells[5].Value?.ToString() ?? "",
                SoLuong = Convert.ToInt32(dataGridView1.CurrentRow.Cells[6].Value ?? 0),
                LinkTaiLieu = dataGridView1.CurrentRow.Cells[7].Value?.ToString() ?? ""
            };

            OpenAddEditForm(book); // Sửa
        }

        private void button_Xoa_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn tài liệu để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa tài liệu này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
        }
    }
}
