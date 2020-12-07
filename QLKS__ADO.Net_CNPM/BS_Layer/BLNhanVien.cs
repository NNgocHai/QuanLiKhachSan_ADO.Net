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
        SqlCommand cmd = null;
        public BLNhanVien()
        {
            db = new DBMain();
            cmd = new SqlCommand();
        }
        public DataSet LayNhanVien()
        {
            return db.ExecuteQueryDataSet(cmd, "NHANVIEN_LayNhanVien");
        }

        public DataSet TimNhanVienTheoTDN(string TenDangNhap)
        {
            cmd.Parameters.Add("@tendn", SqlDbType.VarChar).Value = TenDangNhap;
            return db.ExecuteQueryDataSet(cmd, "NHANVIEN_TimKiemNhanVien");
        }

        public bool ThemNhanVien(string TenDangNhap, string MatKhau, string HoTen, string DiaChi, string SDT, string EMail, string PhanQuyen, ref string err)
        {
            cmd.Parameters.Add("@tendn", SqlDbType.VarChar).Value = TenDangNhap;
            cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = MatKhau;
            cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = HoTen;
            cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = DiaChi;
            cmd.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = SDT;
            cmd.Parameters.Add("@EMail", SqlDbType.NVarChar).Value = EMail;
            cmd.Parameters.Add("@PhanQuyen", SqlDbType.NVarChar).Value = PhanQuyen;
            return db.ExecuteProcNonQuery(cmd, "NHANVIEN_ThemNhanVien", ref err);
        }
        public bool XoaNhanVien(ref string err, string TenDangNhap)
        {
            cmd.Parameters.Add("@tendn", SqlDbType.VarChar).Value = TenDangNhap;
            return db.ExecuteProcNonQuery(cmd, "NHANVIEN_XoaNhanVien", ref err);
        }
        public bool CapNhatNhanVien(string TenDangNhap, string MatKhau, string HoTen, string DiaChi, string SDT, string EMail, string PhanQuyen, ref string err)
        {
            cmd.Parameters.Add("@tendn", SqlDbType.VarChar).Value = TenDangNhap;
            cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = MatKhau;
            cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = HoTen;
            cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = DiaChi;
            cmd.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = SDT;
            cmd.Parameters.Add("@EMail", SqlDbType.NVarChar).Value = EMail;
            cmd.Parameters.Add("@PhanQuyen", SqlDbType.NVarChar).Value = PhanQuyen;
            return db.ExecuteProcNonQuery(cmd, "NHANVIEN_CapNhatNhanVien", ref err);
        }
    }
}
