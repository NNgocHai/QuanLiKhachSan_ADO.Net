using QLKS__ADO.Net_CNPM.BS_Layer;
using QLKS__ADO.Net_CNPM.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS__ADO.Net_CNPM
{
    public partial class FrmDangNhap : Form
    {
        DataTable dtUser = null;
        BLDangNhap user = null;
        int time = 0;

        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Close();
        }

        private void grbTTDN_Enter(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();
            for (int i = 0; i < dtUser.Rows.Count; i++)
            {
                string dataUser = dtUser.Rows[i][0].ToString().Trim();
                string dataPassword = dtUser.Rows[i][1].ToString().Trim();
                if (user == dataUser && password == dataPassword)
                {
                    FrmMain.bIsLogin = true;
                    this.Hide();
                    FrmMain form1 = new FrmMain();
                    form1.ShowDialog();
                    this.Show();
                    return;
                }
            }
            txtUser.Focus();
            MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //Tài khoản mặc định Username: hai, mk: 123 
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            if (time % 7 == 0) this.lbTitle.ForeColor = Color.Red;
            if (time % 7 == 1) this.lbTitle.ForeColor = Color.Orange;
            if (time % 7 == 2) this.lbTitle.ForeColor = Color.Yellow;
            if (time % 7 == 3) this.lbTitle.ForeColor = Color.Green;
            if (time % 7 == 4) this.lbTitle.ForeColor = Color.Blue;
            if (time % 7 == 5) this.lbTitle.ForeColor = Color.Indigo;
            if (time % 7 == 6) this.lbTitle.ForeColor = Color.Violet;
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            try
            {
                dtUser = new DataTable();
                dtUser.Clear();
                user = new BLDangNhap();
                DataSet dts = user.LayTaiKhoan();
                dtUser = dts.Tables[0];

            }
            catch (SqlException)
            {
                MessageBox.Show("Không Lấy Được Dữ Liệu!!!");
            }
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPass.Focus();
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnDangNhap.Focus();
            }
        }
    }
}
