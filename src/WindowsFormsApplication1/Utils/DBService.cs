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
            SqlCommand cmd = new SqlCommand();
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
            SqlConnection connection = DB.GetDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = query;

            DataSet datos = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(datos);

            return datos.Tables[0];
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
            
            cmd.Parameters.AddWithValue("@rubro", item_publicacion.rubro);
            cmd.Parameters.AddWithValue("@id_User", item_publicacion.user_id);
            cmd.Parameters.AddWithValue("@tipoPubl", item_publicacion.tipo_publ);
            cmd.Parameters.AddWithValue("@tipoVisib", item_publicacion.visibilidad);
            cmd.Parameters.AddWithValue("@estado", item_publicacion.estado_publ);
            cmd.Parameters.AddWithValue("@descripcion", item_publicacion.descripcion);
            cmd.Parameters.AddWithValue("@fecha_Vencim", (DateTime.Now).AddMonths(1)); //fecha Vencim en un mes, HAY QUE DEFINIR ESTO
            cmd.Parameters.AddWithValue("@fecha_Inicio", DateTime.Now);
            cmd.Parameters.AddWithValue("@stock", item_publicacion.stock);
            cmd.Parameters.AddWithValue("@monto", item_publicacion.precio_por_unidad);
            cmd.Parameters.AddWithValue("@preguntas", item_publicacion.permite_preguntas);
            cmd.Parameters.AddWithValue("@permiteEnvio", item_publicacion.permiteEnvio);

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


        public static bool Verificar_existencia_visibilidad(string visibilidad)
        {
            SqlCommand cmd = Obtener_comando_para_sp("Class.Verificar_existencia_visibilidad");
            cmd.Parameters.AddWithValue("@visibilidad", visibilidad);
            
            cmd.ExecuteNonQuery();

            using (SqlDataReader reader_user_cant_publ = cmd.ExecuteReader())
            {
                while (reader_user_cant_publ.Read())
                {
                    if (reader_user_cant_publ[0].ToString().Equals("1"))
                        return true;
                    return false;
                }
                return false;
            }
        }


        public static List<ItemVisibilidad> Obtener_Visibilidades()
        {
            List<ItemVisibilidad> listaVisibilidades = new List<ItemVisibilidad>();

            SqlCommand cmd = Obtener_comando_para_sp("Class.ObtenerVisibilidades");
            
            using (SqlDataReader reader_tipos_de_visib = cmd.ExecuteReader())
            {
                while (reader_tipos_de_visib.Read())
                {
                    //Class.TipoDeVisibilidad(codigo,descripcion,monto,porcentaje,puede_enviar)
                    ItemVisibilidad item = new ItemVisibilidad();
                    item.monto = Convert.ToDecimal (reader_tipos_de_visib["monto"].ToString());
                    item.descripcion = reader_tipos_de_visib["descripcion"].ToString();
                    item.porcentaje = Convert.ToDecimal (reader_tipos_de_visib["porcentaje"].ToString());
                    item.precio_envio = Convert.ToDecimal(reader_tipos_de_visib["precio_envio"].ToString());
                    item.baja_logica = reader_tipos_de_visib["baja_logica"].ToString();
 
                    listaVisibilidades.Add(item);
               }
            }

            return listaVisibilidades;
        }

        public static bool Eliminar_Visibilidad(string codigo)
        {
            int _codigo = Convert.ToInt32(codigo);

            SqlCommand cmd = Obtener_comando_para_sp("Class.Eliminar_Visibilidad");
            cmd.Parameters.AddWithValue("@codigo", _codigo);
            
            int response = cmd.ExecuteNonQuery();

            if (response == 1) { return true; }
            return false;
        }

        public static bool Editar_Visibilidad(ItemVisibilidad item, string codigo)
        {
            //Class.Editar_Visibilidad(@codigo, @descripcion, @puede_enviar, @monto, @porcentaje)

            int _codigo = Convert.ToInt32(codigo);

            SqlCommand cmd = Obtener_comando_para_sp("Class.Editar_Visibilidad");
            
            cmd.Parameters.AddWithValue("@codigo", _codigo);
            cmd.Parameters.AddWithValue("@descripcion", item.descripcion);
            cmd.Parameters.AddWithValue("@precio_envio", item.precio_envio);       
            cmd.Parameters.AddWithValue("@monto", item.monto);
            cmd.Parameters.AddWithValue("@porcentaje", item.porcentaje);

            int response = cmd.ExecuteNonQuery();

            if (response == 1) { return true; }
            return false;
        }

        public static bool Insertar_Visibilidad(ItemVisibilidad item)
        {
            //Class.Insertar_Visibilidad(@descripcion,@monto,@porcentaje,@puede_enviar,@baja_logica )
            SqlCommand cmd = Obtener_comando_para_sp("Class.Insertar_Visibilidad");
            
            cmd.Parameters.AddWithValue("@descripcion", item.descripcion);
            cmd.Parameters.AddWithValue("@monto", item.monto);
            cmd.Parameters.AddWithValue("@porcentaje", item.porcentaje);
            cmd.Parameters.AddWithValue("@precio_envio", item.precio_envio);
            cmd.Parameters.AddWithValue("@baja_logica", "1");

            int response = cmd.ExecuteNonQuery();

            if (response == 1) { return true; }
            return false;
        }

        public static DataTable Obtener_Publicaciones_Filtradas_Por(string descripcion, string rubro, int user_id)
        {
            // Class.FiltrarPublicaciones(@rubro, @descripcion, @user_id)
            SqlCommand cmd = Obtener_comando_para_sp("Class.FiltrarPublicaciones");
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@rubro", rubro);
            cmd.Parameters.AddWithValue("@user_id", user_id);

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public static int Obtener_Stock_Comprado_de_publ(int publ_id)
        {
            string query = "SELECT SUM(i.cantidad) AS itemsComprados FROM Class.Item i JOIN Class.Factura f ON (i.id_Factura = f.id_Factura) JOIN Class.Publicacion p ON (f.id_Factura = p.id_Factura) WHERE p.id_Publicacion = " + publ_id;
            DataTable dt = EjecutarQuery(query);
            return Convert.ToInt32(dt.Rows[0]["itemsComprados"].ToString());
        }

        public static String Obtener_max_oferta_de_publicacion(int id_publ)
        {
            // Class.Obtener_max_oferta_de_publicacion(@id_publ)
            SqlCommand cmd = Obtener_comando_para_sp("Class.Obtener_max_oferta_de_publicacion");
            cmd.Parameters.AddWithValue("@id_publ", id_publ);
            
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt.Rows[0]["montoMax"].ToString();
        }

        public static bool Ofertar(int id_publ,int id_ofertante, int monto)
        {
            //Class.Ofertar(@id_publicacion, @idUser_ofertante ,@monto_ofertado)
            SqlCommand cmd = Obtener_comando_para_sp("Class.Ofertar");
            cmd.Parameters.AddWithValue("@id_publicacion", id_publ);
            cmd.Parameters.AddWithValue("@idUser_ofertante", id_ofertante);
            cmd.Parameters.AddWithValue("@monto_ofertado", monto);
            
            int response = cmd.ExecuteNonQuery();
            if (response == 1) { return true; }
            return false;
        }

        public static bool Comprar(int id_publ,int id_comprador, int cantidadComprada,string envio)
        {
            //CREATE PROCEDURE Class.Comprar(@idPublicacion int, @id_comprador int, @cantidadComprada int, @envio varchar(max))
            SqlCommand cmd = Obtener_comando_para_sp("Class.Comprar");
            cmd.Parameters.AddWithValue("@idPublicacion", id_publ);
            cmd.Parameters.AddWithValue("@id_comprador", id_comprador);
            cmd.Parameters.AddWithValue("@cantidadComprada", cantidadComprada);
            cmd.Parameters.AddWithValue("@envio", envio);
            int response = cmd.ExecuteNonQuery();
            
            if (envio.Equals("S") && response == 3) { return true; }
            if (envio.Equals("N") && response == 2) { return true; }
            return false;
        }
        
        public static DataTable Obtener_Contacto_Con_ID_Usuario(String id_usuario)
        {
            string query = "SELECT COUNT(*) FROM Class.Cliente WHERE id_Usuario = " + id_usuario;
            DataTable dt_query = EjecutarQuery(query);
            String result = dt_query.Rows[0][0].ToString();

            if(result.Equals("1"))
            {
                //es Cliente

                DataTable dt_cliente = Obtener_Registro_Con_ID(Convert.ToInt32(id_usuario), "id_Usuario", "Class.Cliente");
                int id_Contacto = Convert.ToInt32(dt_cliente.Rows[0]["id_Contacto"].ToString());
                DataTable dt = Obtener_Registro_Con_ID(id_Contacto, "id_Contacto", "Class.Contacto");
                return dt;
            }
            else
            { 
                // es Empresa

                DataTable dt_empresa = Obtener_Registro_Con_ID(Convert.ToInt32(id_usuario), "id_Usuario", "Class.Empresa");
                int id_Contacto = Convert.ToInt32(dt_empresa.Rows[0]["id_Contacto"].ToString());
                DataTable dt = Obtener_Registro_Con_ID(id_Contacto, "id_Contacto", "Class.Contacto"); 
                return dt;
            }
        }

        public static String Obtener_Tipo_Usuario_ID(String id)
        {

            DataTable dt_usuario = Obtener_Registro_Con_ID(Convert.ToInt32(id), "id_Usuario", "Class.Usuario");
            String tipo_numerico = dt_usuario.Rows[0]["tipo"].ToString();

            if (tipo_numerico.Equals("1"))
                return "Cliente";
            else
                return "Empresa";
        }

        public static int ValidarUsuario(string userName, string hashed_password)
        {

            //Class.ValidarUsuario(@userName ,@hashed_password)
            SqlCommand cmd = Obtener_comando_para_sp("Class.ValidarUsuario");
            cmd.Parameters.AddWithValue("@userName", userName);
            cmd.Parameters.AddWithValue("@hashed_password", hashed_password);

            //Agrego parametro de retorno
            SqlParameter parm = new SqlParameter("@parametroRetorno", SqlDbType.Int);
            parm.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(parm);
            
            cmd.ExecuteNonQuery();

            int result = (int)parm.Value;
            return result;
            //RETURN 4;--Existe pero esta INACTIVO
            //RETURN 3;--Fallo 3 veces, se inhabilita el usuario
            //RETURN 2;--Usuario existe, pero el passowrd es incorrecto
            //RETURN 1;--No existe usuario
            //RETURN 0;-- Usuario valido
        }

        public static DataTable Facturas_Realizadas_Al_Usuario(int id_usuario, DateTime fechaDesde, DateTime fechaHasta,String importeMinimo, String importeMaximo, String detalle, String destinatario)
        {
            string query = "select p.descripcion,f.numero, f.fecha, f.destinatario, f.detalle, f.monto from Class.Factura f JOIN Class.Publicacion p on (p.id_Factura = f.id_Factura) JOIN Class.Usuario u on (u.id_Usuario = p.id_Usuario) where ";

            if (fechaDesde != null && fechaHasta != null)
            {
                query += ("f.fecha BETWEEN '" + fechaDesde.ToString("yyyy-MM-dd") + "' AND '" + fechaHasta.ToString("yyyy-MM-dd") + "' AND ");
            }

            if (destinatario != "")
            {
                query += ("f.destinatario LIKE '%" + destinatario + "%' AND ");
            }

            if (detalle != "")
            {
                query += ("f.detalle LIKE '%" + detalle + "%' AND ");
            }

            if (importeMinimo != "")
            {
                query += ("f.monto > " + importeMinimo + " AND ");
            }

            if (importeMaximo != "")
            {
                query += ("f.monto < " + importeMaximo + " AND ");
            }

            query += ("u.id_Usuario =" + id_usuario);
            DataTable dt = EjecutarQuery(query);
            return dt;
        }

        public static DataTable Resumen_De_Estrellas_De_Usuario(int id_usuario)
        {
            string query = "select p.descripcion, cali.calificacion from Class.Calificacion cali JOIN Class.Compra comp on (cali.id_Compra = comp.id_Compra) JOIN Class.Publicacion p on (p.id_Publicacion = comp.id_Publicacion) JOIN Class.Cliente cli on (cli.id_Cliente = comp.id_Cliente) where cli.id_Usuario = " + id_usuario;
            DataTable dt = EjecutarQuery(query);
            return dt;
        }

        public static DataTable Obtener_Compras_No_Calificadas_De_Usuario(int id_usuario)
        {
            string query = "select p.descripcion as Publicacion,comp.fecha as FechaCompra, comp.cantidad as CantidadCompra from Class.Compra comp JOIN Class.Cliente cli on (cli.id_Cliente = comp.id_Cliente) JOIN Class.Publicacion p on (p.id_Publicacion = comp.id_Publicacion) LEFT JOIN Class.Calificacion on (comp.id_Compra = Class.Calificacion.id_Compra) where Class.Calificacion.id_Calificacion is Null and cli.id_Usuario =" + id_usuario;
            DataTable dt = EjecutarQuery(query);
            return dt;
        }

        public static DataTable Obtener_Compras_Calificadas_De_Usuario(int id_usuario)
        {
            string query = "select publicacion.descripcion, publicacion.monto, calificacion.calificacion, calificacion.detalleCalificacion, publicacion.descripcion from Class.Calificacion calificacion JOIN Class.Compra compra on (compra.id_Compra = calificacion.id_Compra) JOIN Class.Cliente cliente on (cliente.id_Cliente = compra.id_Cliente) JOIN Class.Publicacion publicacion on (publicacion.id_Publicacion = compra.id_Publicacion) where cliente.id_Usuario = " + id_usuario;
            DataTable dt = EjecutarQuery(query);
            return dt;
        }

        public static DataTable Obtener_LogSubastas_De_Usuario(int id_usuario)
        {
            string query = "SELECT p.descripcion, l.monto AS monto_ofertado,  p.stock, r.descripcionCorta, l.fecha FROM Class.LogSubasta l JOIN Class.Publicacion p ON (l.id_Publicacion = p.id_Publicacion) JOIN Class.Rubro r ON (r.id_Rubro = p.id_Rubro) WHERE l.idUser = " + id_usuario;
            DataTable dt = EjecutarQuery(query);
            return dt;
        }

         public static DataTable Obtener_Compras_De_Usuario(int id_Usuario)
        {
            DataTable dt_Cliente = Obtener_Registro_Con_ID(id_Usuario, "id_Usuario", "Class.Cliente");
            string id_Cliente = dt_Cliente.Rows[0]["id_Cliente"].ToString();
            string query = "SELECT p.descripcion, p.stock AS stockTotal, i.monto, i.cantidad AS cantidadComprada, r.descripcionCorta AS rubro FROM Class.Compra c JOIN Class.Publicacion p ON (p.id_Publicacion = c.id_Publicacion) JOIN Class.Rubro r ON (r.id_Rubro = p.id_Rubro) JOIN Class.Factura f ON (p.id_Factura = f.id_Factura) JOIN Class.Item i ON (i.id_Factura = f.id_Factura) WHERE c.id_Cliente = " + id_Cliente + " GROUP BY p.descripcion, p.stock,  i.monto, i.cantidad, r.descripcionCorta";
            DataTable dt = EjecutarQuery(query);
            return dt;
        }


         #region Francha Methods

        // *********** ABM USUARIO *************** //

         //Verificacion de existencia usuario 
         public static bool Verificar_existencia_usuario(string userName)
         {

             //Class.verificar_Existencia_Usuario(@nombre_A_Verificar)
             SqlCommand cmd = Obtener_comando_para_sp("Class.verificar_Existencia_Usuario");
             cmd.Parameters.AddWithValue("@nombre_A_Verificar", userName);

             //Agrego parametro de retorno
             SqlParameter parm = new SqlParameter("@parametroRetorno", SqlDbType.Int);
             parm.Direction = ParameterDirection.ReturnValue;
             cmd.Parameters.Add(parm);

             cmd.ExecuteNonQuery();

             int result = (int)parm.Value;

             if (result.ToString().Equals("0"))
                 return true;
             return false;
         }

         //Verificacion de existencia documento
         public static bool Verificar_existencia_documento(string tipoDoc, decimal numDoc)
         {

             //Class.verificar_Existencia_Documento(@tipo, @nro_doc)
             SqlCommand cmd = Obtener_comando_para_sp("Class.verificar_Existencia_Documento");
             cmd.Parameters.AddWithValue("@tipo", tipoDoc);
             cmd.Parameters.AddWithValue("@nro_doc", numDoc); // VERIFICAR TIPO DE DATO

             //Agrego parametro de retorno
             SqlParameter parm = new SqlParameter("@parametroRetorno", SqlDbType.Int);
             parm.Direction = ParameterDirection.ReturnValue;
             cmd.Parameters.Add(parm);

             cmd.ExecuteNonQuery();

             int result = (int)parm.Value;

             if (result.ToString().Equals("0"))
                 return true;
             return false;
         }

         //Verificacion de existencia CUIT
         public static bool Verificar_existencia_cuit(string cuit)
         {

             //Class.verificar_Existencia_Cuit(@nro_cuit)
             SqlCommand cmd = Obtener_comando_para_sp("Class.verificar_Existencia_Cuit");
             cmd.Parameters.AddWithValue("@nro_cuit", cuit);

             //Agrego parametro de retorno
             SqlParameter parm = new SqlParameter("@parametroRetorno", SqlDbType.Int);
             parm.Direction = ParameterDirection.ReturnValue;
             cmd.Parameters.Add(parm);

             cmd.ExecuteNonQuery();

             int result = (int)parm.Value;

             if (result.ToString().Equals("0"))
                 return true;
             return false;
         }

         //Verificacion de existencia RazonSocial
         public static bool Verificar_existencia_razon_social(string razonSocial)
         {

             //Class.Class.verificar_Existencia_RazonSocial(@nombre_A_Verificar)
             SqlCommand cmd = Obtener_comando_para_sp("Class.verificar_Existencia_RazonSocial");
             cmd.Parameters.AddWithValue("@nombre_A_Verificar", razonSocial);

             //Agrego parametro de retorno
             SqlParameter parm = new SqlParameter("@parametroRetorno", SqlDbType.Int);
             parm.Direction = ParameterDirection.ReturnValue;
             cmd.Parameters.Add(parm);

             cmd.ExecuteNonQuery();

             int result = (int)parm.Value;

             if (result.ToString().Equals("0"))
                 return true;
             return false;
         }


         public static bool Insertar_Cliente(ItemUsuario item_usuario, ItemCliente item_cliente)
         {
             /*Class.Class.CrearCliente(@userName nvarchar(max),@hashed_password nvarchar(max),@nombre nvarchar(max),
                     @apellido varchar(max),@nro_dni numeric(18,0),@tipo_doc varchar(max),@mail varchar(max),@tel numeric(18,0),
                     @direccion_calle varchar(max),@direccion_calle_nro numeric(18,0),@piso numeric(18,0),@depto varchar(max),
                     @localidad varchar(max),@codigoPostal varchar(max),@fechaNac datetime) */

             SqlCommand cmd = Obtener_comando_para_sp("Class.CrearCliente");

             cmd.Parameters.AddWithValue("@userName", item_usuario.nombre);
             cmd.Parameters.AddWithValue("@hashed_password", item_usuario.pass);
             cmd.Parameters.AddWithValue("@nombre", item_cliente.nombre);
             cmd.Parameters.AddWithValue("@apellido", item_cliente.apellido);
             cmd.Parameters.AddWithValue("@nro_dni", item_cliente.numeroDoc);
             cmd.Parameters.AddWithValue("@tipo_doc", item_cliente.tipoDoc);
             cmd.Parameters.AddWithValue("@mail", item_cliente.mail);
             cmd.Parameters.AddWithValue("@tel", item_cliente.telefono);
             cmd.Parameters.AddWithValue("@direccion_calle", item_cliente.calle);
             cmd.Parameters.AddWithValue("@direccion_calle_nro", item_cliente.numCalle);
             cmd.Parameters.AddWithValue("@piso", item_cliente.piso);
             cmd.Parameters.AddWithValue("@depto", item_cliente.depto);
             cmd.Parameters.AddWithValue("@localidad", item_cliente.localidad);
             cmd.Parameters.AddWithValue("@codigoPostal", item_cliente.codPostal);
             cmd.Parameters.AddWithValue("@fechaNac", item_cliente.fechaDeNacimiento);

             //Agrego parametro de retorno
             SqlParameter parm = new SqlParameter("@parametroRetorno", SqlDbType.Int);
             parm.Direction = ParameterDirection.ReturnValue;
             cmd.Parameters.Add(parm);

             cmd.ExecuteNonQuery();

             int result = (int)parm.Value;

             if (result.ToString().Equals("0"))
                 return true;
             return false;
         }

         public static bool Insertar_Empresa(ItemUsuario item_usuario, ItemEmpresa item_empresa)
         {
             /* Class.CrearEmpresa(@userName nvarchar(max),@hashed_password nvarchar(max),@mail varchar(max),@tel numeric(18,0),
                     @direccion_calle varchar(max),@direccion_calle_nro numeric(18,0),@piso numeric(18,0),@depto varchar(max),
                     @codigoPostal varchar(max),@razonSocial varchar(max),@cuit varchar(max),@nombreContacto varchar(max),
                     @rubro varchar(max)) */

             SqlCommand cmd = Obtener_comando_para_sp("Class.CrearEmpresa");

             cmd.Parameters.AddWithValue("@userName", item_usuario.nombre);
             cmd.Parameters.AddWithValue("@hashed_password", item_usuario.pass);
             cmd.Parameters.AddWithValue("@mail", item_empresa.mail);
             cmd.Parameters.AddWithValue("@tel", item_empresa.telefono);
             cmd.Parameters.AddWithValue("@direccion_calle", item_empresa.calle);
             cmd.Parameters.AddWithValue("@direccion_calle_nro", item_empresa.numCalle);
             cmd.Parameters.AddWithValue("@piso", item_empresa.piso);
             cmd.Parameters.AddWithValue("@depto", item_empresa.depto);
             cmd.Parameters.AddWithValue("@codigoPostal", item_empresa.codPostal);
             cmd.Parameters.AddWithValue("@razonSocial", item_empresa.razonSocial);
             cmd.Parameters.AddWithValue("@cuit", item_empresa.cuit);
             cmd.Parameters.AddWithValue("@nombreContacto", item_empresa.contacto);
             cmd.Parameters.AddWithValue("@rubro", item_empresa.rubro);

             //Agrego parametro de retorno
             SqlParameter parm = new SqlParameter("@parametroRetorno", SqlDbType.Int);
             parm.Direction = ParameterDirection.ReturnValue;
             cmd.Parameters.Add(parm);

             cmd.ExecuteNonQuery();

             int result = (int)parm.Value;

             if (result.ToString().Equals("0"))
                 return true;
             return false;
         }

         public static DataTable Traer_Clientes(ItemBuscadorUsuario item_buscador)
         {
             SqlCommand cmd = Obtener_comando_para_sp("Class.traerClientes");

             cmd.Parameters.AddWithValue("@nombre", item_buscador.nombre);
             cmd.Parameters.AddWithValue("@apellido", item_buscador.apellido);
             cmd.Parameters.AddWithValue("@mail", item_buscador.mail);
             cmd.Parameters.AddWithValue("@dni", item_buscador.numeroDoc);
                
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;

         }

         public static DataTable Traer_Empresas(ItemBuscadorUsuario item_buscador)
         {
             SqlCommand cmd = Obtener_comando_para_sp("Class.traerEmpresas");

             cmd.Parameters.AddWithValue("@razonSocial", item_buscador.razonSocial);
             cmd.Parameters.AddWithValue("@cuit", item_buscador.cuit);
             cmd.Parameters.AddWithValue("@mail", item_buscador.mail);

             DataTable dt = new DataTable();
             SqlDataAdapter adapter = new SqlDataAdapter(cmd);
             adapter.Fill(dt);
             return dt;
         }

         public static bool borrar_Usuario(int id_Usuario)
         {
             SqlCommand cmd = Obtener_comando_para_sp("Class.deshabilitarUsuario");
             cmd.Parameters.AddWithValue("@id_usuario", id_Usuario);

             //Agrego parametro de retorno
             SqlParameter parm = new SqlParameter("@parametroRetorno", SqlDbType.Int);
             parm.Direction = ParameterDirection.ReturnValue;
             cmd.Parameters.Add(parm);

             cmd.ExecuteNonQuery();

             int result = (int)parm.Value;

             if (result.ToString().Equals("0"))
                 return true;
             return false;
         }

         public static bool modificarCliente(ItemCliente item_cliente)
         {
             bool validacion = true;
             if(item_cliente.pass != "")
             {
                 SqlCommand cmd = Obtener_comando_para_sp("Class.actualizarPass");
                 cmd.Parameters.AddWithValue("@id_usuario", item_cliente.idUsuario);
                 cmd.Parameters.AddWithValue("@pass", item_cliente.pass);

                 //Agrego parametro de retorno
                 SqlParameter parm = new SqlParameter("@parametroRetorno", SqlDbType.Int);
                 parm.Direction = ParameterDirection.ReturnValue;
                 cmd.Parameters.Add(parm);

                 cmd.ExecuteNonQuery();

                 int result = (int)parm.Value;

                 if (result.ToString().Equals("0"))
                     validacion= true;
                 validacion= false;
             }

             string query = "UPDATE Class.Contacto c SET";

             if (item_cliente.calle != "")
                 query += ("domicilio = " + item_cliente.calle + ",");
             

             if (item_cliente.codPostal != "")
                 query += ("codigoPostal = " + item_cliente.codPostal + ",");

             if (item_cliente.depto != "")
                 query += ("depto = " + item_cliente.depto + ",");

             if (item_cliente.mail != "")
                 query += ("email = " + item_cliente.mail + ",");

             if (item_cliente.numCalle != null)
                 query += ("nro_Calle" + item_cliente.numCalle + ",");

             if (item_cliente.piso != null)
                 query += ("piso" + item_cliente.piso + ",");

             if (item_cliente.telefono != null)
                 query += ("telefono" + item_cliente.telefono + ",");

             query += ("WHERE c.id_Contacto =" + item_cliente.idContacto);
             DataTable dt = EjecutarQuery(query);

             return validacion;
         }

         public static bool modificarEmpresa(ItemEmpresa item_cliente)
         {
             bool validacion = true;
             if (item_cliente.pass != "")
             {
                 SqlCommand cmd = Obtener_comando_para_sp("Class.actualizarPass");
                 cmd.Parameters.AddWithValue("@id_usuario", item_cliente.idUsuario);
                 cmd.Parameters.AddWithValue("@pass", item_cliente.pass);

                 //Agrego parametro de retorno
                 SqlParameter parm = new SqlParameter("@parametroRetorno", SqlDbType.Int);
                 parm.Direction = ParameterDirection.ReturnValue;
                 cmd.Parameters.Add(parm);

                 cmd.ExecuteNonQuery();

                 int result = (int)parm.Value;

                 if (result.ToString().Equals("0"))
                     validacion = true;
                 validacion = false;
             }

             string query = "UPDATE Class.Contacto c SET";

             if (item_cliente.calle != "")
                 query += ("domicilio = " + item_cliente.calle + ",");


             if (item_cliente.codPostal != "")
                 query += ("codigoPostal = " + item_cliente.codPostal + ",");

             if (item_cliente.depto != "")
                 query += ("depto = " + item_cliente.depto + ",");

             if (item_cliente.mail != "")
                 query += ("email = " + item_cliente.mail + ",");

             if (item_cliente.numCalle != null)
                 query += ("nro_Calle" + item_cliente.numCalle + ",");

             if (item_cliente.piso != null)
                 query += ("piso" + item_cliente.piso + ",");

             if (item_cliente.telefono != null)
                 query += ("telefono" + item_cliente.telefono + ",");

             query += ("WHERE c.id_Contacto =" + item_cliente.idContacto);
             DataTable dt = EjecutarQuery(query);

             string query2 = "UPDATE Class.Empresa e SET";

             if (item_cliente.rubro != "")
                 query2 += ("rubro" + item_cliente.rubro + ",");

             if (item_cliente.contacto != "")
                 query2 += ("nombreContacto" + item_cliente.contacto + ","); // PREGUNTAR COMO SACAR LA UKTIMA ,

             query2 += ("WHERE c.id_Contacto =" + item_cliente.idContacto);
             DataTable dt2 = EjecutarQuery(query2);

             return validacion;
         }

#endregion

         #region ListadoEstadistico

         public static DataTable Traer_vendedores_max_prod_no_vendidos(ItemFecha item_fecha)
         {
             SqlCommand cmd = Obtener_comando_para_sp("Class.Traer_vendedores_max_prod_no_vendidos");

             cmd.Parameters.AddWithValue("@anio", item_fecha.anio);
             cmd.Parameters.AddWithValue("@mes1", item_fecha.mes1);
             cmd.Parameters.AddWithValue("@mes2", item_fecha.mes2);
             cmd.Parameters.AddWithValue("@mes3", item_fecha.mes3);

             DataTable dt = new DataTable();
             SqlDataAdapter adapter = new SqlDataAdapter(cmd);
             adapter.Fill(dt);
             return dt;
         }


#endregion
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
