using QLKS__ADO.Net_CNPM.BS_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS__ADO.Net_CNPM.Forms
{

    public partial class FrmMain : DevComponents.DotNetBar.Office2007RibbonForm
    {
        string err;
        public static bool bIsLogin = false;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //Default();
/*            PhongData data = new PhongData();
            lvPhong.Items.Clear();
            foreach (DataRow dr in data.LayMaPhong().Rows)
            {
                PhongInFo phong = new PhongInFo();
                phong.MaLoaiPhong = (string)dr.ItemArray[1];
                phong.MaPhong = (string)dr.ItemArray[0];
                phong.TinhTrangPhong = (int)dr.ItemArray[2];
                ListViewItem item = new ListViewItem(phong.MaPhong);

                if (phong.TinhTrangPhong == 1)
                {
                    item.ImageIndex = 0;

                }
                else if (phong.TinhTrangPhong == 2)
                {
                    item.ImageIndex = 1;
                }
                else
                {
                    item.ImageIndex = 2;
                }

                listViewEx1.Items.Add(item);*/
            }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            FrmDangNhap frmDangNhap = new FrmDangNhap();
            frmDangNhap.ShowDialog();
        }

        private void btnNguoiDung_Click(object sender, EventArgs e)
        {
            FrmNhanVien frmNhanVien = new FrmNhanVien();
            frmNhanVien.ShowDialog();
        }

        private void buttonPhong_Click(object sender, EventArgs e)
        {
            FrmPhong frmPhong = new FrmPhong();
            frmPhong.ShowDialog();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            
            BLBackup filebackup = new BLBackup();
            SaveFileDialog save = new SaveFileDialog();
            if(save.ShowDialog()==DialogResult.OK)
            {
                filebackup.Backup(save.FileName,ref err);
            }    
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            BLRestore restore = new BLRestore();
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK)
            {
                restore.Restore(save.FileName, ref err);

                MessageBox.Show("Khôi phục dữ liệu thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
    /*private void lbUser_Click(object sender, EventArgs e)
    {
*//*            pnlMain.BackgroundImage = null;

            FrmNhanVien frmNhanVien = new FrmNhanVien();
            this.pnlMain.Controls.Clear();
            frmNhanVien.TopLevel = false;
            frmNhanVien.AutoScroll = true;
            pnlMain.Controls.Add(frmNhanVien);
            frmNhanVien.Dock = DockStyle.Fill;
            frmNhanVien.FormBorderStyle = FormBorderStyle.None;

            frmNhanVien.Location = new Point(
            this.pnlMain.Width / 2 - frmNhanVien.Size.Width / 2,
            this.pnlMain.Height / 2 - frmNhanVien.Size.Height / 2);
            frmNhanVien.Anchor = AnchorStyles.None;

            frmNhanVien.Show();*//*
        }*/  
}
