using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Utils
{
    class DB
    {
        private static SqlConnection db;

        public static SqlConnection GetDB()
        {
            if (db == null)
            {
                db = new SqlConnection("Data Source=LOCALHOST\\SQLSERVER2012;Initial Catalog=GD1C2016;Persist Security Info=True;User ID=gd;Password=gd2016");
                db.Open();
            }
           
            return db;
        }
    }
}
