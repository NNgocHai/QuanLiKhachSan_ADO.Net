using QLKS__ADO.Net_CNPM.DB_Layer;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLKS__ADO.Net_CNPM.BS_Layer
{
    
    class BLPhong
    {
        
        DBMain db = null;
        SqlCommand cmd = null;
        public BLPhong()
        {
            db = new DBMain();
            cmd = new SqlCommand();
        }

        public DataSet LayPhong()
        {
            return db.ExecuteQueryDataSet(cmd, "PHONG_LayPhong");
        }


        public bool ThemPhong(string MaPhong, string Ten, string Gia, string TinhTrang, string SoNguoiToiDa, string phong_km,string mota, ref string err)
        {
            cmd.Parameters.Add("@MaPhong", SqlDbType.VarChar).Value = MaPhong;
            cmd.Parameters.Add("@Ten", SqlDbType.NVarChar).Value = Ten;
            cmd.Parameters.Add("@Gia", SqlDbType.NVarChar).Value = Gia;
            cmd.Parameters.Add("@TinhTrang", SqlDbType.NVarChar).Value = TinhTrang;
            cmd.Parameters.Add("@SoNguoiToiDa", SqlDbType.NVarChar).Value = SoNguoiToiDa;
            cmd.Parameters.Add("@phong_km", SqlDbType.NVarChar).Value = phong_km;
            cmd.Parameters.Add("@mota", SqlDbType.NVarChar).Value = mota;
            return db.ExecuteProcNonQuery(cmd, "PHONG_ThemPhong", ref err);
        }
        public bool XoaPhong(ref string err, string MaPhong)
        {
            cmd.Parameters.Add("@MaPhong", SqlDbType.VarChar).Value = MaPhong;
            return db.ExecuteProcNonQuery(cmd, "PHONG_XoaPhong", ref err);
        }
        public bool CapNhatPhong(string MaPhong, string Ten, string Gia, string TinhTrang, string SoNguoiToiDa, string phong_km,string mota, ref string err)
        
        {
            cmd.Parameters.Add("@MaPhong", SqlDbType.VarChar).Value = MaPhong;
            cmd.Parameters.Add("@Ten", SqlDbType.NVarChar).Value = Ten;
            cmd.Parameters.Add("@Gia", SqlDbType.NVarChar).Value = Gia;
            cmd.Parameters.Add("@TinhTrang", SqlDbType.NVarChar).Value = TinhTrang;
            cmd.Parameters.Add("@SoNguoiToiDa", SqlDbType.NVarChar).Value = SoNguoiToiDa;
            cmd.Parameters.Add("@phong_km", SqlDbType.NVarChar).Value = phong_km;
            cmd.Parameters.Add("@mota", SqlDbType.NVarChar).Value = mota;
            return db.ExecuteProcNonQuery(cmd, "PHONG_CapNhatPhong", ref err);
        }
        public List<string> LayTinhTrang()
        {
            List<string> dsTinhTrang = new List<string>();
            dsTinhTrang.Clear();
            SqlDataReader reader = db.MyExcuteProcReader(cmd, "PHONG_LayTinhTrang");
            while (reader.Read())
            {
                dsTinhTrang.Add(reader.GetString(0));
            }
            db.myDispose();
            reader.Dispose();
            return dsTinhTrang;
        }
        public List<string> LayTen()
        {
            List<string> dsTen = new List<string>();
            dsTen.Clear();        
            SqlDataReader reader = db.MyExcuteProcReader(cmd, "PHONG_LayTen");
            while (reader.Read())
            {
                dsTen.Add(reader.GetString(0));
            }
            db.myDispose();
            reader.Dispose();
            return dsTen;
        }
        public DataSet TimKiemPhong(string TinhTrang, string Ten, ref string err)
        {
            cmd.Parameters.Add("@tinhtrang", SqlDbType.VarChar).Value = TinhTrang;
            cmd.Parameters.Add("@ten", SqlDbType.NVarChar).Value = Ten;
            return db.ExecuteQueryDataSet(cmd, "PHONG_TimKiemPhong");
        }

    }
}
