using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS__ADO.Net_CNPM.DB_Layer;
using System.Data.SqlClient;
using System.Data;

namespace QLKS__ADO.Net_CNPM.BS_Layer
{
    class BLDichVu
    {
        DBMain db = null;
        SqlCommand cmd = null;
        public BLDichVu()
        {
            db = new DBMain();
            cmd = new SqlCommand();
        }
        public DataSet LayDichVu()
        {
            return db.ExecuteQueryDataSet(cmd, "DICHVU_LayDichVu");
        }
        public bool ThemPhong(string MaDichVu, string TenDV, string Gia, ref string err)
        {
            cmd.Parameters.Add("@madv", SqlDbType.VarChar).Value = MaDichVu;
            cmd.Parameters.Add("@tendv", SqlDbType.NVarChar).Value = TenDV;
            cmd.Parameters.Add("@gia", SqlDbType.NVarChar).Value = Gia;
            return db.ExecuteProcNonQuery(cmd, "DICHVU_ThemDichVu", ref err);
        }
        public bool XoaDichVu(ref string err, string MaDichVu)
        {
            cmd.Parameters.Add("@madv", SqlDbType.VarChar).Value = MaDichVu;
            return db.ExecuteProcNonQuery(cmd, "DICHVU_ThemDichVu", ref err);
        }

        public bool CapNhatDichVu(string MaDichVu, string TenDV, string Gia, ref string err)
        {
            cmd.Parameters.Add("@madv", SqlDbType.VarChar).Value = MaDichVu;
            cmd.Parameters.Add("@tendv", SqlDbType.NVarChar).Value = TenDV;
            cmd.Parameters.Add("@gia", SqlDbType.NVarChar).Value = Gia;
            return db.ExecuteProcNonQuery(cmd, "DICHVU_CapNhatDichVu", ref err);
        }
        public DataSet TimKiemDichVu(string TenDV, ref string err)
        {
            cmd.Parameters.Add("@tendv", SqlDbType.NVarChar).Value = TenDV;
            return db.ExecuteQueryDataSet(cmd, "DICHVU_TimKiemDichVu");
        }
    }
}
