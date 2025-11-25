using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLTVS
{
    public partial class ucLogin : UserControl
    {
        private Form1 mainForm;

        public ucLogin(Form1 form)
        {
            InitializeComponent();
            this.mainForm = form;
        }


        private bool IsFirstLogin(string username)
        {
            // THAY BẰNG DB SAU
            return username == "admin";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button_DN_Click_1(object sender, EventArgs e)
        {
            string username = textBox_TenDN.Text.Trim();
            string password = textBox_MK.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // GIẢ LẬP ĐĂNG NHẬP THÀNH CÔNG
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ucLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
