using MercadoEnvio.Base_De_Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1.Base_De_Datos
{

    //It should be an interface and an implementation... but i'm lazy.
    class UsersDAO
    {
        public Persona get(int userID)
        {
            String query = "select * from class.usuario, class.persona where class.Usuario.IdUsuario = " + userID.ToString();
            DataTable result = Conexion.LeerTabla(query);
            DataRow row = result.Rows[0];
            return new Persona((int)row["IdUsuario"], row["Usuario"].ToString().Trim(), null, 
                (int)row["IdRol"], row["Nombre"].ToString(),
                row["Apellido"].ToString(), row["DNI"].ToString().Trim(), row["TipoDocumento"].ToString().Trim(),
                row["Mail"].ToString().Trim(), row["Telefono"].ToString().Trim(), row["Calle"].ToString().Trim(),
                row["Numero"].ToString().Trim(), row["Piso"].ToString().Trim(), row["Depto"].ToString().Trim(),
                row["Localidad"].ToString().Trim(), row["CodigoPostal"].ToString().Trim(),
                row.Field<DateTime>("FechaNac"), row.Field<DateTime>("FechaCreacion")
            );
        }
    }
}
