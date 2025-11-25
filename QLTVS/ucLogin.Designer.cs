namespace QLTVS
{
    partial class ucLogin
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_TenDN = new System.Windows.Forms.TextBox();
            this.textBox_MK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_DN = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập:";
            // 
            // textBox_TenDN
            // 
            this.textBox_TenDN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_TenDN.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TenDN.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBox_TenDN.Location = new System.Drawing.Point(18, 119);
            this.textBox_TenDN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_TenDN.Name = "textBox_TenDN";
            this.textBox_TenDN.Size = new System.Drawing.Size(663, 39);
            this.textBox_TenDN.TabIndex = 1;
            this.textBox_TenDN.Tag = "";
            this.textBox_TenDN.Text = "Nhập tên đăng nhập...";
            // 
            // textBox_MK
            // 
            this.textBox_MK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_MK.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_MK.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBox_MK.Location = new System.Drawing.Point(18, 245);
            this.textBox_MK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_MK.Name = "textBox_MK";
            this.textBox_MK.Size = new System.Drawing.Size(663, 39);
            this.textBox_MK.TabIndex = 3;
            this.textBox_MK.Tag = "";
            this.textBox_MK.Text = "Nhập mật khẩu...";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(12, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu:";
            // 
            // button_DN
            // 
            this.button_DN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_DN.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button_DN.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_DN.Location = new System.Drawing.Point(116, 359);
            this.button_DN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_DN.Name = "button_DN";
            this.button_DN.Size = new System.Drawing.Size(454, 76);
            this.button_DN.TabIndex = 4;
            this.button_DN.Text = "Đăng nhập";
            this.button_DN.UseVisualStyleBackColor = false;
            this.button_DN.Click += new System.EventHandler(this.button_DN_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.Color.LightGray;
            this.groupBox1.Controls.Add(this.textBox_TenDN);
            this.groupBox1.Controls.Add(this.textBox_MK);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button_DN);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox1.Location = new System.Drawing.Point(437, 167);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(705, 497);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đăng nhập";
            // 
            // ucLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BackgroundImage = global::QLTVS.Properties.Resources.background_anh_sang_xanh;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucLogin";
            this.Size = new System.Drawing.Size(1504, 966);
            this.Load += new System.EventHandler(this.ucLogin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_DN;
        private System.Windows.Forms.TextBox textBox_MK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_TenDN;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
