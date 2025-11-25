using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QLTVS
{
    public partial class ucBorrow : UserControl
    {
        // Simple in-memory model for UI-only behavior
        private BindingList<BorrowDetail> _borrowDetails = new BindingList<BorrowDetail>();
        private bool _isCreating = false;

        public ucBorrow()
        {
            InitializeComponent();
            SetupGrid();
            WireEvents();
        }

        private void SetupGrid()
        {
            // Make grid usable without backend
            dataGridView_ChiTietPhieuMuon.AutoGenerateColumns = false;
            dataGridView_ChiTietPhieuMuon.Columns.Clear();

            var c1 = new DataGridViewTextBoxColumn { HeaderText = "Mã sách", DataPropertyName = "MaSach", Width = 150 };
            var c2 = new DataGridViewTextBoxColumn { HeaderText = "Tên sách", DataPropertyName = "TenSach", Width = 500 };
            var c3 = new DataGridViewTextBoxColumn { HeaderText = "Số lượng", DataPropertyName = "SoLuong", Width = 120 };

            dataGridView_ChiTietPhieuMuon.Columns.AddRange(c1, c2, c3);
            dataGridView_ChiTietPhieuMuon.DataSource = _borrowDetails;

            // UX defaults
            textBox_MaPhieu.ReadOnly = true;
            textBox_TenTV.ReadOnly = false;
            textBox_MaTV.ReadOnly = false;
        }

        private void WireEvents()
        {
            // Wire designer buttons to handlers so UI does something
            button_TaoPhieu.Click -= Button_TaoPhieu_Click;
            button_TaoPhieu.Click += Button_TaoPhieu_Click;

            button_ThemTaiLieu.Click -= Button_ThemTaiLieu_Click;
            button_ThemTaiLieu.Click += Button_ThemTaiLieu_Click;

            button_LuuPhieu.Click -= Button_LuuPhieu_Click;
            button_LuuPhieu.Click += Button_LuuPhieu_Click;

            button_InPhieuMuon.Click -= Button_InPhieuMuon_Click;
            button_InPhieuMuon.Click += Button_InPhieuMuon_Click;

            comboBox_MaSach.DropDown -= ComboBox_MaSach_DropDown;
            comboBox_MaSach.DropDown += ComboBox_MaSach_DropDown;
        }

        private void ComboBox_MaSach_DropDown(object sender, EventArgs e)
        {
            // Lazy populate sample items if no backend data provided.
            if (comboBox_MaSach.Items.Count == 0)
            {
                comboBox_MaSach.Items.Add(new ComboBoxItem("S001", "Clean Code"));
                comboBox_MaSach.Items.Add(new ComboBoxItem("S002", "The Pragmatic Programmer"));
                comboBox_MaSach.Items.Add(new ComboBoxItem("S003", "Design Patterns"));
                comboBox_MaSach.DisplayMember = nameof(ComboBoxItem.Display);
            }
        }

        private void Button_TaoPhieu_Click(object sender, EventArgs e)
        {
            // Start a new borrow in-memory
            _borrowDetails.Clear();
            textBox_MaPhieu.Text = "PM" + DateTime.Now.ToString("yyyyMMddHHmmss");
            dateTimePicker_MuonSach.Value = DateTime.Now;
            _isCreating = true;
            MessageBox.Show("Phiếu mượn được tạo (UI-only). Thêm tài liệu để tiếp tục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Button_ThemTaiLieu_Click(object sender, EventArgs e)
        {
            if (!_isCreating)
            {
                MessageBox.Show("Vui lòng tạo phiếu mượn trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!(comboBox_MaSach.SelectedItem is ComboBoxItem sel))
            {
                MessageBox.Show("Vui lòng chọn một sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int qty;
            if (!int.TryParse(textBox_SoLuong.Text.Trim(), out qty) || qty <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Add to in-memory list (UI only)
            _borrowDetails.Add(new BorrowDetail
            {
                MaSach = sel.Code,
                TenSach = sel.Name,
                SoLuong = qty
            });

            // Clear quantity after adding
            textBox_SoLuong.Text = "";
        }

        private void Button_LuuPhieu_Click(object sender, EventArgs e)
        {
            if (!_isCreating)
            {
                MessageBox.Show("Không có phiếu để lưu. Tạo phiếu mới trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_borrowDetails.Count == 0)
            {
                MessageBox.Show("Phiếu rỗng, thêm ít nhất một tài liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // UI-only "save"
            _isCreating = false;
            MessageBox.Show("Phiếu mượn đã được lưu (in-memory, front-end only).", "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Button_InPhieuMuon_Click(object sender, EventArgs e)
        {
            // Basic print simulation: show summary
            if (_borrowDetails.Count == 0)
            {
                MessageBox.Show("Không có nội dung để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string summary = "Phiếu: " + textBox_MaPhieu.Text + Environment.NewLine +
                             "Thành viên: " + textBox_MaTV.Text + " - " + textBox_TenTV.Text + Environment.NewLine +
                             "Ngày: " + dateTimePicker_MuonSach.Value.ToShortDateString() + Environment.NewLine +
                             "Số dòng: " + _borrowDetails.Count;

            MessageBox.Show(summary, "In (simulated)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Simple helper types for UI-only logic
        private class ComboBoxItem
        {
            public string Code { get; }
            public string Name { get; }
            public string Display => $"{Code} - {Name}";

            public ComboBoxItem(string code, string name)
            {
                Code = code;
                Name = name;
            }

            public override string ToString() => Display;
        }

        private class BorrowDetail
        {
            public string MaSach { get; set; }
            public string TenSach { get; set; }
            public int SoLuong { get; set; }
        }

        // Leave designer event stubs empty to avoid accidental double-wiring
        private void Label6_Click(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void ucBorrow_Load(object sender, EventArgs e) { }
    }
}
