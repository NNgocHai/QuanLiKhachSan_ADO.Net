namespace QLKS__ADO.Net_CNPM
{
    partial class FrmDangNhap
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grbTTDN = new System.Windows.Forms.GroupBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnThoat = new System.Windows.Forms.Button();
            this.grbTTDN.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbTTDN
            // 
            this.grbTTDN.BackColor = System.Drawing.Color.PapayaWhip;
            this.grbTTDN.Controls.Add(this.btnDangNhap);
            this.grbTTDN.Controls.Add(this.txtPass);
            this.grbTTDN.Controls.Add(this.txtUser);
            this.grbTTDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTTDN.ForeColor = System.Drawing.SystemColors.Highlight;
            this.grbTTDN.Location = new System.Drawing.Point(152, 137);
            this.grbTTDN.Margin = new System.Windows.Forms.Padding(4);
            this.grbTTDN.Name = "grbTTDN";
            this.grbTTDN.Padding = new System.Windows.Forms.Padding(4);
            this.grbTTDN.Size = new System.Drawing.Size(498, 293);
            this.grbTTDN.TabIndex = 6;
            this.grbTTDN.TabStop = false;
            this.grbTTDN.Text = "Thông tin Đăng nhập";
            this.grbTTDN.Enter += new System.EventHandler(this.grbTTDN_Enter);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnDangNhap.Location = new System.Drawing.Point(142, 198);
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(4);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(197, 42);
            this.btnDangNhap.TabIndex = 3;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.SystemColors.Control;
            this.txtPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.ForeColor = System.Drawing.Color.Blue;
            this.txtPass.Location = new System.Drawing.Point(95, 123);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(307, 30);
            this.txtPass.TabIndex = 2;
            this.txtPass.Text = "123";
            this.txtPass.UseSystemPasswordChar = true;
            this.txtPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPass_KeyPress);
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.SystemColors.Control;
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.ForeColor = System.Drawing.Color.Blue;
            this.txtUser.Location = new System.Drawing.Point(95, 67);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4);
            this.txtUser.Multiline = true;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(307, 34);
            this.txtUser.TabIndex = 1;
            this.txtUser.Text = "hai";
            this.txtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUser_KeyPress);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(90, 20);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(621, 80);
            this.lbTitle.TabIndex = 5;
            this.lbTitle.Text = "Quản Lý Khách Sạn";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.DimGray;
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(673, 438);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(128, 58);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "     Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // FrmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(823, 499);
            this.Controls.Add(this.grbTTDN);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.btnThoat);
            this.Name = "FrmDangNhap";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmDangNhap_Load);
            this.grbTTDN.ResumeLayout(false);
            this.grbTTDN.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbTTDN;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnThoat;
    }
}

