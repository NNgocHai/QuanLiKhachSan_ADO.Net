using QLKS__ADO.Net_CNPM.DB_Layer;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLKS__ADO.Net_CNPM.BS_Layer
{
    

    class BLNhanVien
    {
        DBMain db = null;

        public BLNhanVien()
        {
            db = new DBMain();
        }
        public DataSet LayNhanVien()
        {
            return db.ExecuteQueryDataSet("select * from NHANVIEN", CommandType.Text);
        }

        public DataSet TimNhanVienTheoTDN(string TenDangNhap)
        {
            return db.ExecuteQueryDataSet("select * from NHANVIEN where TENDANGNHAP LIKE N'%" + TenDangNhap + "%'", CommandType.Text);
        }

        public bool ThemNhanVien(string TenDangNhap, string MatKhau, string HoTen, string DiaChi, string SDT, string EMail, string TinhTrangHD, ref string err)
        {
            string sqlString = "Insert Into NHANVIEN Values('" + TenDangNhap.Trim()
                                                      + "',N'" + MatKhau.Trim()
                                                      + "',N'" + HoTen.Trim()
                                                      + "',N'" + DiaChi.Trim()
                                                      + "','" + SDT.Trim()
                                                      + "',N'" + EMail.Trim()
                                                      + "','" + TinhTrangHD.Trim() + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaNhanVien(ref string err, string TenDangNhap)
        {
            string sqlString = "Delete From NHANVIEN Where TENDANGNHAP='" + TenDangNhap + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhatNhanVien(string TenDangNhap, string MatKhau, string HoTen, string DiaChi, string SDT, string EMail, string TinhTrangHD, ref string err)
        {
            string sqlString = "Update NHANVIEN Set MATKHAU=N'" + MatKhau.Trim()
                                                               + "',HOTEN=N'" + HoTen.Trim()
                                                               + "',DIACHI='" + DiaChi.Trim()
                                                               + "',SDT='" + SDT.Trim()
                                                               + "',EMAIL='" + EMail.Trim()
                                                               + "',TINHTRANGHD='" + TinhTrangHD.Trim()
                                                               + "' Where TENDANGNHAP='" + TenDangNhap.Trim() + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
