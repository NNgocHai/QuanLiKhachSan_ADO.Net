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
    public partial class FrmNhanVien : Form
    {
        DataTable DTNV = null;
        bool Them;
        string err;
        BLNhanVien BLNV = null;
        public FrmNhanVien()
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
            this.txtTenDangNhap.ResetText();
            this.txtMatKhau.ResetText();
            this.txtHoVaTen.ResetText();
            this.txtDiaChi.ResetText();
            this.txtSDT.ResetText();
            this.txtEmail.ResetText();
            this.txtPhanQuyen.ResetText();
            this.txtTimKiem.ResetText();

        }
       

        public void LoadData()
        {
            try
            {
                DTNV = new DataTable();
                BLNV = new BLNhanVien();
                DTNV.Clear();
                DataSet ds = BLNV.LayNhanVien();
                DTNV = ds.Tables[0];
                // Đưa dữ liệu lên DataGridView
                dgvNhanVien.DataSource = DTNV;
                Default_txt();
                dgvNhanVien_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong bảng NHANVIEN. Lỗi rồi!!!");
            }
        }

        
        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            Default_txt();
            Default_Button();
            this.txtTenDangNhap.Enabled = true;
            dgvNhanVien_CellClick(null, null);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            BLNV = new BLNhanVien();
            if (Them)
            {
                if (this.txtTenDangNhap.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập ID!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtTenDangNhap.Focus();
                }
                 else
                 {                     
                        try
                        {
                            if (BLNV.ThemNhanVien(this.txtTenDangNhap.Text, this.txtMatKhau.Text, this.txtHoVaTen.Text, this.txtDiaChi.Text, this.txtSDT.Text, this.txtEmail.Text, this.txtPhanQuyen.Text, ref err))
                            {
                                LoadData();
                                MessageBox.Show("Đã thêm xong!");
                                Default_Button();
                            }
                            else
                            {
                                MessageBox.Show( err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (BLNV.CapNhatNhanVien(this.txtTenDangNhap.Text, this.txtMatKhau.Text, this.txtHoVaTen.Text, this.txtDiaChi.Text, this.txtSDT.Text, this.txtEmail.Text, this.txtPhanQuyen.Text, ref err))
                    {
                        LoadData();
                        MessageBox.Show("Đã sửa xong!");
                        Default_Button();
                        this.txtTenDangNhap.Enabled = true;

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
            dgvNhanVien_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;          
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            this.txtTenDangNhap.Enabled = false;
            this.txtMatKhau.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            BLNV = new BLNhanVien();
            try
            {
                if (txtTenDangNhap.Text != "")
                {
                    DialogResult DL = MessageBox.Show("Bạn có muốn xóa mẫu tin này?", "xác nhận", MessageBoxButtons.YesNoCancel);
                    if (DL == DialogResult.Yes)
                    {
                        int r = dgvNhanVien.CurrentCell.RowIndex;
                        if (BLNV.XoaNhanVien(ref err, this.txtTenDangNhap.Text))
                        {
                            LoadData();
                            MessageBox.Show("Đã xóa xong");
                        }
                        else
                        {
                            MessageBox.Show( err, "Thông báo",
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them
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

            this.txtTenDangNhap.Focus();

        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Thứ tự dòng hiện hành
                int r = dgvNhanVien.CurrentCell.RowIndex;
                //Chuyển thông tin lên panel
                this.txtTenDangNhap.Text = dgvNhanVien.Rows[r].Cells[0].Value.ToString().Trim();
                this.txtMatKhau.Text = dgvNhanVien.Rows[r].Cells[1].Value.ToString().Trim();
                this.txtHoVaTen.Text = dgvNhanVien.Rows[r].Cells[2].Value.ToString().Trim();
                this.txtDiaChi.Text = dgvNhanVien.Rows[r].Cells[3].Value.ToString().Trim();
                this.txtSDT.Text = dgvNhanVien.Rows[r].Cells[4].Value.ToString().Trim();
                this.txtEmail.Text = dgvNhanVien.Rows[r].Cells[5].Value.ToString().Trim();
                this.txtPhanQuyen.Text = dgvNhanVien.Rows[r].Cells[6].Value.ToString().Trim();

            }
            catch
            {
                this.txtTenDangNhap.Text = "";
                this.txtMatKhau.Text = "";
                this.txtHoVaTen.Text = "";
                this.txtDiaChi.Text = "";
                this.txtSDT.Text = "";
                this.txtEmail.Text = "";
                this.txtPhanQuyen.Text = "";

            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            BLNV = new BLNhanVien();
            DTNV = new DataTable();
            DTNV.Clear();
            DataSet ds = BLNV.TimNhanVienTheoTDN(txtTimKiem.Text);
            DTNV = ds.Tables[0];
            dgvNhanVien.DataSource = DTNV;
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
