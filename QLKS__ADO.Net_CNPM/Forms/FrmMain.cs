using QLKS__ADO.Net_CNPM.BS_Layer;
using QLKS__ADO.Net_CNPM.BusinessObject;
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

namespace QLKS__ADO.Net_CNPM.Forms
{

    public partial class FrmMain : DevComponents.DotNetBar.Office2007RibbonForm
    {
        string err;
        public static bool bIsLogin = false;
        DataTable DTP = null;
        BLPhong BLP = null;
        public FrmMain()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            try
            {
                DTP = new DataTable();
                BLP = new BLPhong();
                this.lvPhong.Items.Clear();
                DTP.Clear();
                DataSet ds = BLP.LayPhong();
                DTP = ds.Tables[0];
                foreach (DataRow dr in DTP.Rows)
                {
                    Phong Phong = new Phong();
                    Phong.Ma_Phong = (string)dr.ItemArray[0];
                    Phong.TinhTrang = (string)dr.ItemArray[3];
                    ListViewItem item = new ListViewItem(Phong.Ma_Phong);
                    if(Phong.TinhTrang == "1")//Phòng đã có người roi
                    {
                        item.ImageIndex = 1;
                    }
                    else if (Phong.TinhTrang == "2")//Phòng đã được book
                    {
                        item.ImageIndex = 2;
                    }
                    else //Phòng chưa có người đặt
                    {
                        item.ImageIndex = 0;
                    }

                    lvPhong.Items.Add(item);
                }


            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong bảng PHONG. Lỗi rồi!!!");
            }
        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadData();
            
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

        private void lvPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ToolStripItemDangKy_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripItemNhanPhong_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripItemTraPhong_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripItemThongTinPhong_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripItemCapNhat_Click(object sender, EventArgs e)
        {

        }

        private void buttonDichVu_Click(object sender, EventArgs e)
        {
            FrmDichVu frmDichVu = new FrmDichVu();
            frmDichVu.ShowDialog();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            FrmKhachHang frmKhachHang = new FrmKhachHang();
            frmKhachHang.ShowDialog();
        }
    } 
}
