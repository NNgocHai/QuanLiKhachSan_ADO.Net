using QLKS__ADO.Net_CNPM.DB_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS__ADO.Net_CNPM.BS_Layer
{
    class BLRestore
    {

        DBMain db = null;
        public BLRestore()
        {
            db = new DBMain();

        }
        public void Restore(string fileName, ref string err)
        {
            string sqlString = "use master alter database [CSDL_KHACHSAN] set single_user with rollback immediate restore database [CSDL_KHACHSAN] from disk = '" + fileName + "'with replace alter database [CSDL_KHACHSAN] set multi_user";
            db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
