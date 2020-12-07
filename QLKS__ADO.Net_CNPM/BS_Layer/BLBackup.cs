using QLKS__ADO.Net_CNPM.DB_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS__ADO.Net_CNPM.BS_Layer
{
    class BLBackup
    {

        DBMain db = null;
        public BLBackup()
        {
            db = new DBMain();

        }
        public void Backup(string fileName, ref string err)
        {
            string sqlString = "use master Backup database CSDL_KHACHSAN to disk ='" +fileName + ".bak'";
            db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
