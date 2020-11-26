using QLKS__ADO.Net_CNPM.DB_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS__ADO.Net_CNPM.BS_Layer
{
    class BLDangNhap
    {
        DBMain db = null;
        public BLDangNhap()
        {
            db = new DBMain();

        }

        public DataSet LayTaiKhoan()
        {
            return db.ExecuteQueryDataSet("select * from NHANVIEN ", CommandType.Text);
        }
    }
}
