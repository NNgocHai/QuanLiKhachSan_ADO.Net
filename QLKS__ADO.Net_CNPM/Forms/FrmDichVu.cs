using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKS__ADO.Net_CNPM.BS_Layer;

using System.Data.SqlClient;

namespace QLKS__ADO.Net_CNPM.Forms
{
    public partial class FrmDichVu : Form
    {
        DataTable DTDV = null;
        bool Them;
        string err;
        BLDichVu BLDV = null;
        public FrmDichVu()
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
            this.txtTenDichVu.ResetText();
            this.txtMaDV.ResetText();
            this.txtGia.ResetText();
            this.txtTimKiem.ResetText();
        }
        public void LoadData()
        {
            try
            {
                DTDV = new DataTable();
                BLDV = new BLDichVu();
                DTDV.Clear();
                DataSet ds = BLDV.LayDichVu();
                DTDV = ds.Tables[0];
                // Đưa dữ liệu lên DataGridView
                dgvDichVu.DataSource = DTDV;
                Default_txt();
                dgvDichVu_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong bảng DICHVU. Lỗi rồi!!!");
            }
        }

        private void FrmDichVu_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Thứ tự dòng hiện hành
                int r = dgvDichVu.CurrentCell.RowIndex;
                //Chuyển thông tin lên panel
                this.txtMaDV.Text = dgvDichVu.Rows[r].Cells[0].Value.ToString().Trim();
                this.txtTenDichVu.Text = dgvDichVu.Rows[r].Cells[1].Value.ToString().Trim();
                this.txtGia.Text = dgvDichVu.Rows[r].Cells[2].Value.ToString().Trim();

            }
            catch
            {
                this.txtMaDV.Text = "";
                this.txtTenDichVu.Text = "";
                this.txtGia.Text = "";

            }

        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            Default_txt();
            Default_Button();
            this.txtMaDV.Enabled = true;
            dgvDichVu_CellClick(null, null);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            BLDV = new BLDichVu();
            if (Them)
            {
                if (this.txtMaDV.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtMaDV.Focus();
                }
                else
                {
                    try
                    {
                        if (BLDV.ThemDichVu(this.txtMaDV.Text, this.txtTenDichVu.Text, this.txtGia.Text, ref err))
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
                    if (BLDV.CapNhatDichVu(this.txtMaDV.Text, this.txtTenDichVu.Text, this.txtGia.Text, ref err))
                    {
                        LoadData();
                        MessageBox.Show("Đã sửa xong!");
                        Default_Button();
                        this.txtMaDV.Enabled = true;

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
            dgvDichVu_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            this.txtMaDV.Enabled = false;
            this.txtTenDichVu.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            BLDV = new BLDichVu();
            try
            {
                if (txtMaDV.Text != "")
                {
                    DialogResult DL = MessageBox.Show("Bạn có muốn xóa mẫu tin này?", "xác nhận", MessageBoxButtons.YesNoCancel);
                    if (DL == DialogResult.Yes)
                    {
                        int r = dgvDichVu.CurrentCell.RowIndex;
                        if (BLDV.XoaDichVu(ref err, this.txtMaDV.Text))
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

            this.txtMaDV.Focus();

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            BLDV = new BLDichVu();
            DTDV = new DataTable();
            DTDV.Clear();
            DataSet ds = BLDV.TimKiemDichVu(txtTimKiem.Text);
            DTDV = ds.Tables[0];
            dgvDichVu.DataSource = DTDV;
        }
    }
}
