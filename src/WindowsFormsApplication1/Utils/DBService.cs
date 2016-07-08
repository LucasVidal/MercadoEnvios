using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Utils;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApplication1.Utils
{
    class DBService
    {
        public static DataTable Obtener_Registro_Con_ID(int id, string nombreColumna, string nombreTabla)
        {
            SqlConnection connection = DB.GetDB();
            SqlCommand cmd = new SqlCommand(    );
            cmd.Connection = connection;

            string query = "SELECT * FROM " + nombreTabla + " WHERE " + nombreColumna + " = " + id;
            cmd.CommandText = query;

            DataSet datos = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(datos);

            return datos.Tables[0];
        }

        public static DataTable Obtener_Registro_Con_String(string stringBuscado, string nombreColumna, string nombreTabla)
        {
            SqlConnection connection = DB.GetDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            string query = "SELECT * FROM " + nombreTabla + " WHERE " + nombreColumna + " = '" + (stringBuscado) + "'";
            cmd.CommandText = query;

            DataSet datos = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(datos);
            return datos.Tables[0];
        }

        public static DataTable SelectDataTable(String columna_unica, String nombreTabla)
        {
            string query = "SELECT " + columna_unica + " FROM " + nombreTabla;
            DataTable dt = EjecutarQuery(query);
            return dt;
        }

        public static DataTable SelectDataTable(List<String> listaColumnas, String nombreTabla)
        {
            string query = ConstruirConsulta(listaColumnas, nombreTabla);
            DataTable dt = EjecutarQuery(query);
            return dt;
        }

        private static string ConstruirConsulta(List<String> listaParametros, String nombreTabla)
        {
            string query = "SELECT ";

            for (int i = 0; i < listaParametros.Count; i++)
            {
                if ((i + 1) == listaParametros.Count)
                {
                    query += listaParametros[i] + " ";
                    break;
                }
                query += listaParametros[i] + "," + " ";
            }
            query += "FROM " + nombreTabla;

            return query;
        }

        public static DataTable EjecutarQuery(string query)
        {
            DataTable tabla = new DataTable();
            SqlConnection connection = DB.GetDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = query;
            SqlDataReader reader = cmd.ExecuteReader();
            tabla.Load(reader);
            return tabla;
        }

        private static SqlCommand Obtener_comando_para_sp(String nombreSP)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = nombreSP;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = DB.GetDB();
            return cmd;
        }

        public static bool Insertar_Publicacion(ItemPublicacion item_publicacion,bool publicaciones_gratis)
        {

            SqlCommand cmd = Obtener_comando_para_sp("Class.CrearPublicacion");

            DateTime fechaSistema = DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["FechaSistema"]);

            cmd.Parameters.AddWithValue("@rubro", item_publicacion.rubro);
            cmd.Parameters.AddWithValue("@id_User", item_publicacion.user_id);
            cmd.Parameters.AddWithValue("@tipoPubl", item_publicacion.tipo_publ);
            cmd.Parameters.AddWithValue("@tipoVisib", item_publicacion.visibilidad);
            cmd.Parameters.AddWithValue("@estado", item_publicacion.estado_publ);
            cmd.Parameters.AddWithValue("@descripcion", item_publicacion.descripcion);
            cmd.Parameters.AddWithValue("@fecha_Vencim", (fechaSistema).AddMonths(1)); //fecha Vencim en un mes, HAY QUE DEFINIR ESTO
            cmd.Parameters.AddWithValue("@fecha_Inicio", fechaSistema);
            cmd.Parameters.AddWithValue("@stock", item_publicacion.stock);
            cmd.Parameters.AddWithValue("@monto", item_publicacion.precio_por_unidad);
            cmd.Parameters.AddWithValue("@permiteEnvio", item_publicacion.permiteEnvio);
            cmd.Parameters.AddWithValue("@fechaSistema", fechaSistema);

            int parametro;
            if (publicaciones_gratis) { parametro = 1; } else { parametro = 0; }
            cmd.Parameters.AddWithValue("@publicaciones_gratis", parametro);

            int response = cmd.ExecuteNonQuery();

            if (response >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Modificar_Publicacion(int idpublicación, ItemPublicacion item_publicacion, bool publicaciones_gratis)
        {

            SqlCommand cmd = Obtener_comando_para_sp("Class.ModificarPublicacion");

            cmd.Parameters.AddWithValue("@idpublicación", idpublicación);
            cmd.Parameters.AddWithValue("@rubro", item_publicacion.rubro);
            cmd.Parameters.AddWithValue("@estado", item_publicacion.estado_publ);
            cmd.Parameters.AddWithValue("@descripcion", item_publicacion.descripcion);
            cmd.Parameters.AddWithValue("@stock", item_publicacion.stock);
            cmd.Parameters.AddWithValue("@monto", item_publicacion.precio_por_unidad);
            cmd.Parameters.AddWithValue("@fechaSistema", DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["FechaSistema"]));

            int parametro;
            if (publicaciones_gratis) { parametro = 1; } else { parametro = 0; }
            cmd.Parameters.AddWithValue("@publicaciones_gratis", parametro);

            int response = cmd.ExecuteNonQuery();

            if (response >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Nueva_oferta(int idpublicación, int idusuario, int monto)
        {

            SqlCommand cmd = Obtener_comando_para_sp("Class.NuevaOferta");

            cmd.Parameters.AddWithValue("@idpublicación", idpublicación);
            cmd.Parameters.AddWithValue("@idusuario", idusuario);
            cmd.Parameters.AddWithValue("@monto", monto);
            cmd.Parameters.AddWithValue("@fechaSistema", DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["FechaSistema"]));

            int response = cmd.ExecuteNonQuery();

            if (response >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Nueva_Calificacion(int usuarioComprador, int idcompra, int idpublicacion, int usuarioVendedor, int estrellas,string comentario)
        {
            
            SqlCommand cmd = Obtener_comando_para_sp("Class.Nueva_Calificacion");

            cmd.Parameters.AddWithValue("@idpublicación", idpublicacion);
            cmd.Parameters.AddWithValue("@idusuarioPub", usuarioVendedor);
            cmd.Parameters.AddWithValue("@idusuarioCom", usuarioComprador);
            cmd.Parameters.AddWithValue("@idcompra", idcompra);
            cmd.Parameters.AddWithValue("@calificacion", estrellas);
            cmd.Parameters.AddWithValue("@detalle", comentario);
            var dt = DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["FechaSistema"]);
            //var tm = DateTime.Now.ToString("hh:mm:ss");
            //var fullDt = dt + tm; 
            cmd.Parameters.AddWithValue("@fechaSistema", dt);

            int response = cmd.ExecuteNonQuery();

            if (response >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool Insertar_Compra(int idpublicación, int idusuario, int monto, int cantidad)
        {

            SqlCommand cmd = Obtener_comando_para_sp("Class.Insertar_Compra");

            cmd.Parameters.AddWithValue("@idpublicación", idpublicación);
            cmd.Parameters.AddWithValue("@idusuario", idusuario);
            cmd.Parameters.AddWithValue("@monto", monto);
            cmd.Parameters.AddWithValue("@cantidad", cantidad);
            cmd.Parameters.AddWithValue("@fechaSistema", DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["FechaSistema"]));

            int response = cmd.ExecuteNonQuery();

            if (response >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

         public static void Actualizar_Subastas()
         {
             SqlCommand cmd = Obtener_comando_para_sp("Class.Actulizar_Subastas");
             cmd.ExecuteNonQuery();
         }

         public static bool VerificarPublicacionesGratis(int idUser)
         {
             //Class.Verificar_Alta_De_Usuario_Con_Migracion(@id_Usuario int, @tipo int)
             SqlCommand cmd = Obtener_comando_para_sp("Class.VerificarPublicacionesGratis");
             cmd.Parameters.AddWithValue("@id_Usuario", idUser);
             //Agrego parametro de retorno
             SqlParameter parm = new SqlParameter("@parametro_retorno", SqlDbType.Int);
             parm.Direction = ParameterDirection.ReturnValue;
             cmd.Parameters.Add(parm);

             cmd.ExecuteNonQuery();

             int result = (int)parm.Value;

             if (result >= 1)
                 return true;
             return false;
         }
    }
}
