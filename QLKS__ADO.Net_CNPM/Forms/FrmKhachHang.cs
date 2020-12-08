using QLKS__ADO.Net_CNPM.BS_Layer;
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
    public partial class FrmKhachHang : Form
    {
        DataTable DTKH = null;
        bool Them;
        string err;
        BLKhachHang BLKH = null;
        public FrmKhachHang()
        {
            InitializeComponent();
        }
        public void Default_Button()
        {
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
        }
        public void Default_txt()
        {
            this.txtMa.ResetText();
            this.txtTen.ResetText();
            this.txtGioiTinh.ResetText();
            this.txtCMND.ResetText();
            this.txtDiaChi.ResetText();
            this.txtSDT.ResetText();
            this.txtTinhTrang.ResetText();
            this.txtTimKiemTen.ResetText();
            this.cbbGioiTinh.Text = "ALL";
            this.cbbTinhTrang.Text = "ALL";
            this.cbbTimKiem.Text = "Tên";
            this.cbbTinhTrang.Enabled = false;
            this.cbbGioiTinh.Enabled = false;
            this.txtTimKiemTen.ResetText();

        }
        private void LoadData()
        {
            try
            {
                BLKH = new BLKhachHang();
                DTKH = new DataTable();
                DTKH.Clear();
                DataSet ds = BLKH.LayKhachHang();
                DTKH = ds.Tables[0];
                // Đưa dữ liệu lên DataGridView
                dgvKhachHang.DataSource = DTKH;
                Default_txt();
                dgvKhachHang_CellClick(null, null);
                LoadGioiTinh();
                LoadTinhTrang();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong bảng PHONG. Lỗi rồi!!!");
            }
        }
        private void LoadTinhTrang()
        {
            BLKhachHang BLKH = new BLKhachHang();
            List<string> dsTrangThai = new List<string>();
            dsTrangThai.Clear();
            dsTrangThai = BLKH.LayTinhTrang();
            cbbTinhTrang.Items.Clear();
            cbbTinhTrang.Items.Add("ALL");

            foreach (string TrangThai in dsTrangThai)
            {
                cbbTinhTrang.Items.Add(TrangThai);
            }
        }

        private void LoadGioiTinh()
        {
            BLKhachHang BLKH = new BLKhachHang();
            List<string> dsGioiTinh = new List<string>();
            dsGioiTinh.Clear();
            dsGioiTinh = BLKH.LayGioiTinh();
            cbbGioiTinh.Items.Clear();
            cbbGioiTinh.Items.Add("ALL");

            foreach (string Ten in dsGioiTinh)
            {
                cbbGioiTinh.Items.Add(Ten);
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            BLKH = new BLKhachHang();
            try
            {
                if (txtMa.Text != "")
                {
                    DialogResult DL = MessageBox.Show("Bạn có muốn xóa mẫu tin này?", "xác nhận", MessageBoxButtons.YesNoCancel);
                    if (DL == DialogResult.Yes)
                    {
                        int r = dgvKhachHang.CurrentCell.RowIndex;
                        if (BLKH.XoaKhachHang(ref err, this.txtMa.Text))
                        {
                            LoadData();
                            MessageBox.Show("Đã xóa xong");
                        }
                        else
                        {
                            MessageBox.Show(err, "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn chưa nhập ID", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
                MessageBox.Show("Lỗi rồi");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            BLKhachHang BLKH = new BLKhachHang();
            DTKH = new DataTable();
            DTKH.Clear();
            DataSet ds = new DataSet();
            if (cbbTimKiem.Text == "Tên")
            {
                ds = BLKH.TimKiemKhachHangTheoTen(txtTimKiemTen.Text, ref err);
                this.cbbGioiTinh.Enabled = false;
                this.cbbTinhTrang.Enabled = false;
                this.txtTimKiemTen.Enabled = true;

            }
            else
            {
                ds = BLKH.TimKiemKhachHang_TheoGTTT(cbbTinhTrang.Text, cbbGioiTinh.Text, ref err);
                this.cbbGioiTinh.Enabled = true;
                this.cbbTinhTrang.Enabled = true;
                this.txtTimKiemTen.Enabled = false;
                
            }
            DTKH = ds.Tables[0];
            dgvKhachHang.DataSource = DTKH;//11
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            Default_txt();
            Default_Button();
            this.txtMa.Enabled = true;
            dgvKhachHang_CellClick(null, null);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            BLKH = new BLKhachHang();
            if (Them)
            {
                if (this.txtMa.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập ID!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtMa.Focus();
                }
                else
                {
                    try
                    {//(string MaPhong, string Ten, string TinhTrang, string SoNguoiToiDa, string Gia, string KhuyenMai, ref string err)
                        if (BLKH.ThemKhachHang(this.txtMa.Text, this.txtTen.Text, this.txtDiaChi.Text, this.txtSDT.Text, this.txtCMND.Text, this.txtGioiTinh.Text, this.txtTinhTrang.Text, ref err))
                        {
                            LoadData();
                            MessageBox.Show("Đã thêm xong!");
                            Default_Button();
                        }
                        else
                        {
                            MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Không thêm được. Lỗi rồi!");
                    }
                }
            }
            else
            {

                try
                {
                    if (BLKH.CapNhatKhachHang(this.txtMa.Text, this.txtTen.Text, this.txtDiaChi.Text, this.txtSDT.Text, this.txtCMND.Text, this.txtGioiTinh.Text, this.txtTinhTrang.Text, ref err))
                    {
                        LoadData();
                        MessageBox.Show("Đã sửa xong!");
                        Default_Button();
                        this.txtMa.Enabled = true;

                    }
                    else
                    {
                        MessageBox.Show(this.err);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không sửa được. Lỗi rồi!");
                }

            }
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            // Cho phép thao tác trên Panel
            dgvKhachHang_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            this.txtMa.Enabled = false;
            this.txtTen.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            // Xóa trống các đối tượng trong Panel

            Default_txt();
            // Cho thao tác trên các nút Lưu / Hủy / Panel

            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;

            // Không cho thao tác trên các nút Thêm / Xóa / Thoát

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            this.txtMa.Focus();
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {

            LoadData();
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BLKH = new BLKhachHang();
            try
            {
                //Thứ tự dòng hiện hành
                int r = dgvKhachHang.CurrentCell.RowIndex;
                //Chuyển thông tin lên panel
                this.txtMa.Text = dgvKhachHang.Rows[r].Cells[0].Value.ToString().Trim();
                this.txtTen.Text = dgvKhachHang.Rows[r].Cells[1].Value.ToString().Trim();
                this.txtDiaChi.Text = dgvKhachHang.Rows[r].Cells[2].Value.ToString().Trim();
                this.txtSDT.Text = dgvKhachHang.Rows[r].Cells[3].Value.ToString().Trim();
                this.txtCMND.Text = dgvKhachHang.Rows[r].Cells[4].Value.ToString().Trim();
                this.txtGioiTinh.Text = dgvKhachHang.Rows[r].Cells[5].Value.ToString().Trim();
                this.txtTinhTrang.Text = dgvKhachHang.Rows[r].Cells[6].Value.ToString().Trim();

            }
            catch
            {
                this.txtMa.Text = "";
                this.txtTen.Text = "";
                this.txtDiaChi.Text = "";
                this.txtSDT.Text = "";
                this.txtCMND.Text = "";
                this.txtGioiTinh.Text = "";
                this.txtTinhTrang.Text = "";
            }

        }

        private void cbbTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTimKiem.Text == "Tên")
            {
                //ds = BLKH.TimKiemKhachHang_TheoGTTT(cbbTinhTrang.Text, cbbGioiTinh.Text, ref err);
                this.cbbGioiTinh.Enabled = false;
                this.cbbTinhTrang.Enabled = false;
                this.txtTimKiemTen.Enabled = true;

            }
            else
            {
                this.cbbGioiTinh.Enabled = true;
                this.cbbTinhTrang.Enabled = true;
                this.txtTimKiemTen.Enabled = false;
                //ds = BLKH.TimKiemKhachHangTheoTen(txtTimKiemTen.Text);
            }
        }
    }
}
