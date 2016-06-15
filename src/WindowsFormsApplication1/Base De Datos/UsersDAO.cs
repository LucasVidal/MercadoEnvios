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
        public Usuario get(int userID)
        {
            if (userIsPersona(userID))
            {
                String query = "select * from class.usuario, class.persona where " +
    "class.Usuario.IdUsuario = class.Persona.IdUsuario and class.Usuario.IdUsuario = " + userID.ToString();
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
            else
            {
                String query = "select * from class.usuario, class.empresa where " +
    "class.Usuario.IdUsuario = class.Empresa.IdUsuario and class.Usuario.IdUsuario = " + userID.ToString();
                DataTable result = Conexion.LeerTabla(query);
                DataRow row = result.Rows[0];
                return new Empresa((int)row["IdUsuario"], row["Usuario"].ToString().Trim(), null,
                    (int)row["IdRol"], row["RazonSocial"].ToString(),
                    row["Cuit"].ToString(), row["Mail"].ToString().Trim(), row["Telefono"].ToString().Trim(),
                    row["Calle"].ToString().Trim(), row["Numero"].ToString().Trim(), row["Piso"].ToString().Trim(),
                    row["Depto"].ToString().Trim(), row["Localidad"].ToString().Trim(), row["CodigoPostal"].ToString().Trim(),
                    row["NombreContacto"].ToString().Trim(), row["Rubro"].ToString().Trim()
                );
            }
        }

        private bool userIsPersona(int userID)
        {
            String query = "select IdUsuario from class.persona where IdUsuario = " + userID.ToString();
            DataTable result = Conexion.LeerTabla(query);
            return result.Rows.Count > 0;
        }

    }
}
