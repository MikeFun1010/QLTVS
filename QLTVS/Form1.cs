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
    public partial class Form1 : Form
    {
        private Panel ucContainer;
        private UserControl currentUC;
        

        public Form1()
        {
            InitializeComponent();

            // TẠO UC CONTAINER
            ucContainer = new Panel();
            ucContainer.Dock = DockStyle.Fill;
            ucContainer.BackColor = Color.Transparent;
            ucContainer.Visible = false;

            tableLayoutPanel3.Controls.Add(ucContainer, 0, 1);
            tableLayoutPanel3.SetRowSpan(ucContainer, 2);
            tableLayoutPanel3.Controls.SetChildIndex(ucContainer, 0); // TRÊN groupBox1

            ShowHome(); // HIỆN TRANG CHỦ TRƯỚC

            // LOGO
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.logo;
            tableLayoutPanel1.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, 120F);
        }

        public void ShowUC(UserControl uc)
        {
            groupBox1.Visible = false;  // Ẩn row 2
            groupBox2.Visible = false;  // Ẩn row 3

            if (currentUC != null)
            {
                ucContainer.Controls.Remove(currentUC);
                currentUC.Dispose();
            }

            currentUC = uc;
            currentUC.Dock = DockStyle.Fill;
            ucContainer.Controls.Add(currentUC);
            ucContainer.Visible = true;
            ucContainer.BringToFront();
            tableLayoutPanel1.BringToFront();
        }

        public void ShowHome()
        {
            if (currentUC != null)
            {
                ucContainer.Controls.Remove(currentUC);
                currentUC.Dispose();
                currentUC = null;
            }

            ucContainer.Visible = false;
            groupBox1.Visible = true;   // Hiện row 2
            groupBox2.Visible = true;   // Hiện row 3
            tableLayoutPanel1.BringToFront();
            UpdateLoginButton(true);
        }

        private void UpdateLoginButton(bool loggedIn)
        {
            if (loggedIn)
            {
                button6.Text = "Đăng xuất";
                button6.Click -= button6_Click_Login;
                button6.Click += button6_Click_Logout;
            }
            else
            {
                button6.Text = "Đăng nhập";
                button6.Click -= button6_Click_Logout;
                button6.Click += button6_Click_Login;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Click += (s, ev) => ShowHome();
            button2.Click += (s, ev) => ShowUC(new ucBook());
            button3.Click += (s, ev) => ShowUC(new ucMember());
            button4.Click += (s, ev) => ShowUC(new ucBorrow());
            button5.Click += (s, ev) => ShowUC(new ucReturn());
            UpdateLoginButton(false);
        }

        private void button6_Click_Login(object sender, EventArgs e)
        {
            ShowUC(new ucLogin(this));
        }

        private void button6_Click_Logout(object sender, EventArgs e)
        {
            UpdateLoginButton(false);
            ShowUC(new ucLogin(this));
            MessageBox.Show("Đã đăng xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

