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
        public BLPhong()
        {
            db = new DBMain();

        }

        public DataSet LayPhong()
        {
            return db.ExecuteQueryDataSet("select * from PHONG ", CommandType.Text );
        }


        public bool ThemPhong(string MaPhong, string Ten, string TinhTrang, string SoNguoiToiDa, string Gia, string KhuyenMai, ref string err)
        {
            string sqlString = "Insert Into PHONG Values('" + MaPhong.Trim()
                                                      + "',N'" + Ten.Trim()
                                                      + "',N'" + TinhTrang.Trim()
                                                      + "',N'" + SoNguoiToiDa.Trim()
                                                      + "','" + Gia.Trim()
                                                      + "',N'" + KhuyenMai.Trim() + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaPhong(ref string err, string MaPhong)
        {
            string sqlString = "Delete From PHONG Where MAPHONG='" + MaPhong + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhatPhong(string MaPhong, string Ten, string TinhTrang, string SoNguoiToiDa, string Gia, string KhuyenMai, ref string err)
        {
            string sqlString = "Update PHONG Set TEN=N'" + Ten.Trim()
                                                               + "',TINHTRANG=N'" + TinhTrang.Trim()
                                                               + "',SoNguoiToiDa='" + SoNguoiToiDa.Trim()
                                                               + "',Gia='" + Gia.Trim()
                                                               + "',KhuyenMai='" + KhuyenMai.Trim()
                                                               + "' Where TENDANGNHAP='" + MaPhong.Trim() + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public List<string> LayTinhTrang()
        {
            List<string> dsTinhTrang = new List<string>();
            dsTinhTrang.Clear();
            string selectcomm = "select DISTINCT TinhTrang from PHONG";
            SqlDataReader reader = db.MyExcuteReader(selectcomm, CommandType.Text);
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
            string selectcomm = "select DISTINCT Ten from PHONG";
            SqlDataReader reader = db.MyExcuteReader(selectcomm, CommandType.Text);
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
            string sqlstring = "select * from PHONG";
            if (TinhTrang != "ALL" && Ten == "ALL")
            {

                sqlstring = " select * from PHONG Where TinhTrang=N'"+ TinhTrang +"'";


            }
            else if (TinhTrang == "ALL" && Ten != "ALL")
            {

                    sqlstring = " select * from PHONG Where Ten=" + Ten + "'";

            }
            else if (TinhTrang == "ALL" && Ten == "ALL")
            {
                sqlstring = " select * from PHONG" ;
            }
            else
                sqlstring = " select * from PHONG Where TinhTrang=N'" + TinhTrang + "'and Ten=N'" + Ten + "'";

            return db.ExecuteQueryDataSet(sqlstring, CommandType.Text);
        }

    }
}
