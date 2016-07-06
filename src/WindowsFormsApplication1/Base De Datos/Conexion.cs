using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoEnvio.Base_De_Datos
{
    class Conexion
    {
        public static string parametros = ConfigurationManager.ConnectionStrings["miCadenaConexion"].ConnectionString;
        //public static string parametros = ConfigurationManager.ConnectionStrings["miCadenaConexion"];
        //declarar una conexion llamada conexion ojo esta no es la misma que la clase E!! la diferencia esta en la c mayuscula y minuscula
        public static SqlConnection conexion;
        //vamos a validar que se conecte correctamente

        public static bool conectar()

        {
            bool conectado = false;        
            //llenar la variable conexión con los parámetros de la variable parametros
            conexion = new SqlConnection(parametros);

            try
            {
                //abrir la conexion
                conexion.Open();
                conectado = true;
            }
            catch 
            {
                conectado = false;
            }
            return conectado;
        }
        public static DataTable LeerTabla(string consulta)

        {
            DataSet ds = new DataSet();
            DataTable dtresultado= new DataTable();
            if (conectar())
            {
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(ds,"tabla");
                dtresultado = ds.Tables["tabla"];
            }        
            return dtresultado;
        }
        public static int EjecutarComando(string sentencia)
        {
            int retorno=0;
            if (conectar())
            {
                SqlCommand comando =new SqlCommand(sentencia, conexion);
                retorno=comando.ExecuteNonQuery();
            }
            return retorno;
        }

        public static int ExecuteAndReturnId(string query)
        {
            if (conectar())
            {
                query += "; SELECT CAST(scope_identity() AS int)";
                SqlCommand comando = new SqlCommand(query, conexion);
                return (Int32) comando.ExecuteScalar();
            }
            return 0;
        }   

    }
}
