using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace MercadoEnvio.Utils.AccesoDatos
{
    public class DAL
    {
        private string _strConn = null;

        public DAL()
        {
            _strConn=ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString;
        }

        public DataTable EjecutarComando(string cmd)
        {
            DataTable ret = new DataTable();
            using (SqlConnection conn = new SqlConnection(_strConn))
            {
                conn.Open();
                using (SqlCommand comando = new SqlCommand(cmd, conn))
                {
                    SqlDataReader reader = comando.ExecuteReader();
                    ret.Load(reader);
                }
            }
            return ret;
        }

        public DataTable EjecutarStoredProcedure(string sp, List<KeyValuePair<string, object>> parametros)
        {
            DataTable ret = new DataTable();
            using (SqlConnection conn = new SqlConnection(_strConn))
            {
                conn.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conn;
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = sp;
                    foreach (KeyValuePair<string, object> p in parametros)
                    {
                        comando.Parameters.Add(new SqlParameter(p.Key, p.Value));
                    }
                    SqlDataReader reader = comando.ExecuteReader();
                    ret.Load(reader);
                }
            }
            return ret;
        }
    }
}
