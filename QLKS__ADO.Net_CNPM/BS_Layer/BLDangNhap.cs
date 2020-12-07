using QLKS__ADO.Net_CNPM.DB_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS__ADO.Net_CNPM.BS_Layer
{
    class BLDangNhap
    {
        DBMain db = null;
        SqlCommand cmd = null;
        public BLDangNhap()
        {
            db = new DBMain();
            cmd = new SqlCommand();
        }

        public DataSet LayTaiKhoan()
        {
            return db.ExecuteQueryDataSet(cmd,"NHANVIEN_LayNhanVien");
        }
        public object LayPhanQuyen(string TenDangNhap)
        {
            cmd.Parameters.Add("@tendn", SqlDbType.VarChar).Value = TenDangNhap;
            return db.MyExecuteScalar(cmd, "Select dbo.NHANVIEN_LayPhanQuyen(@tendn)");
        }
    }
}
