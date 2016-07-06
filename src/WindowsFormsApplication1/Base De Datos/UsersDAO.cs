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

        public void save(Usuario usuario)
        {
            if (usuario.IdUsuario == -1) {
                int newId = createCommon(usuario);
                usuario.IdUsuario =  newId;
                if (usuario.GetType() == typeof(Persona)) {
                    createPersona((Persona)usuario);
                } else {
                    createEmpresa((Empresa)usuario);
                }
            } else {
                updateCommon(usuario);
                if (usuario.GetType() == typeof(Persona)) {
                    updatePersona((Persona)usuario);
                } else {
                    updateEmpresa((Empresa)usuario);
                }
            }
        }

        public Usuario get(int userID)
        {
            if (userIsPersona(userID))
            {
                String query = "select * from class.usuario, class.persona, class.rolUsuario where " +
    "class.Usuario.IdUsuario = class.Persona.IdUsuario and class.Usuario.IdUsuario = " + userID.ToString() +
    " and class.rolUsuario.IdUsuario = class.Usuario.IdUsuario";
                DataTable result = Conexion.LeerTabla(query);
                DataRow row = result.Rows[0];
                if (result.Rows.Count == 0) return null;

                return new Persona((int)row["IdUsuario"], row["Usuario"].ToString().Trim(), null,
                    (int)row["IdRol"], row["Nombre"].ToString(),
                    row["Apellido"].ToString(), row["DNI"].ToString().Trim(), row["TipoDocumento"].ToString().Trim(),
                    row["Mail"].ToString().Trim(), row["Telefono"].ToString().Trim(), row["Calle"].ToString().Trim(),
                    row["Numero"].ToString().Trim(), row["Piso"].ToString().Trim(), row["Depto"].ToString().Trim(),
                    row["Localidad"].ToString().Trim(), row["CodigoPostal"].ToString().Trim(),
                    row.Field<DateTime>("FechaNac"), row.Field<DateTime>("FechaCreacion"), (bool)row["EstaHabilitado"]
                );
            }
            else
            {
                String query = "select * from class.usuario, class.empresa, class.rolUsuario where " +
    "class.Usuario.IdUsuario = class.Empresa.IdUsuario and class.Usuario.IdUsuario = " + userID.ToString() +
    " and class.rolUsuario.IdUsuario = class.Usuario.IdUsuario";
                DataTable result = Conexion.LeerTabla(query);
                DataRow row = result.Rows[0];
                if (result.Rows.Count == 0) return null;

                return new Empresa((int)row["IdUsuario"], row["Usuario"].ToString().Trim(), null,
                    (int)row["IdRol"], row["RazonSocial"].ToString(),
                    row["Cuit"].ToString(), row["Mail"].ToString().Trim(), row["Telefono"].ToString().Trim(),
                    row["Calle"].ToString().Trim(), row["Numero"].ToString().Trim(), row["Piso"].ToString().Trim(),
                    row["Depto"].ToString().Trim(), row["Localidad"].ToString().Trim(), row["CodigoPostal"].ToString().Trim(),
                    row["NombreContacto"].ToString().Trim(), row["Rubro"].ToString().Trim(), (bool)row["EstaHabilitado"]
                );
            }
        }

        private bool userIsPersona(int userID)
        {
            String query = "select IdUsuario from class.persona where IdUsuario = " + userID.ToString();
            DataTable result = Conexion.LeerTabla(query);
            return result.Rows.Count > 0;
        }


        private int createCommon(Usuario usuario)
        {
            String query = "insert into class.usuario (Usuario, Clave, EstaHabilitado, LoginFallidos, Mail, "
                + "Telefono, Ciudad, Calle, Numero, Piso, Depto, Localidad, CodigoPostal, PublicacionesGratuitas) values (" +
                "'" + usuario.Username + "', " + 
                "convert(varbinary,convert(nvarchar(4000),Class.psencriptar('" + usuario.Password + "'))), " +
                (usuario.EstaHabilitado ? "1" : "0") + ", " +
                "0, " + 
                "'" + usuario.Email + "', " + 
                "'" + usuario.Telefono + "', " +
                "NULL, " +
                "'" + usuario.Calle + "', " + 
                "'" + usuario.Numero + "', " + 
                "'" + usuario.Piso + "', " + 
                "'" + usuario.Depto + "', " +
                "'" + usuario.Localidad + "', " + 
                "'" + usuario.CodigoPostal + "', " +
                "0)";
            int newUserId = Conexion.ExecuteAndReturnId(query);

            query = "insert into class.rolUsuario (Orden, IdUsuario, IdRol) values (" +
                "1, " +
                newUserId + ", " +
                usuario.RolId + ");";

            int result = Conexion.EjecutarComando(query);
            return newUserId;
        }

        private void updateCommon(Usuario usuario)
        {
            String query = "update class.Usuario set " +
                "Usuario ='" + usuario.Username + "', " +
                "Clave =convert(varbinary,convert(nvarchar(4000),Class.psencriptar('" + usuario.Password + "'))), " +
                "EstaHabilitado =" + (usuario.EstaHabilitado ? "1" : "0") + ", " +
                "Mail ='" + usuario.Email + "', " +
                "Telefono ='" + usuario.Telefono + "', " +
                "Ciudad = NULL, " +
                "Calle ='" + usuario.Calle + "', " +
                "Numero ='" + usuario.Numero + "', " + 
                "Piso ='" + usuario.Piso + "', " +
                "Depto ='" + usuario.Depto + "', " +
                "Localidad ='" + usuario.Localidad + "', " +
                "CodigoPostal ='" + usuario.CodigoPostal + "' " +
                "where IdUsuario = " + usuario.IdUsuario.ToString() + ";";
            int result = Conexion.EjecutarComando(query);

            query = "update class.rolUsuario set " +
               " IdRol = " + usuario.RolId.ToString() + " " +
               "where IdUsuario = " + usuario.IdUsuario.ToString() + ";";
            result = Conexion.EjecutarComando(query);
        }

        private void createPersona(Persona persona)
        {
            String query = "insert into class.persona (IdUsuario, Nombre, Apellido, TipoDocumento, DNI, FechaNac, FechaCreacion) " +
                " values (" + 
                "'" + persona.IdUsuario + "', " +
                "'" + persona.Nombre + "', " +
                "'" + persona.Apellido + "', " +
                "'" + persona.TipoDeDocumento + "', " +
                "'" + persona.DNI + "', " +
                "'" + persona.FechaDeNacimiento + "', " +
                "'" + persona.FechaDeCreacion + "' )";
            int result = Conexion.EjecutarComando(query);
        }

        private void updatePersona(Persona persona)
        {
            String query = "update class.Persona set " +
                "Nombre ='" + persona.Nombre + "', " +
                "Apellido ='" + persona.Apellido + "', " +
                "DNI ='" + persona.DNI + "', " +
                "FechaCreacion ='" + persona.FechaDeCreacion + "' " +
                " where IdUsuario = " + persona.IdUsuario.ToString() + ";";
            int result = Conexion.EjecutarComando(query);
        }

        private void createEmpresa(Empresa empresa) 
        {
            String query = "insert into class.empresa (IdUsuario, RazonSocial, Cuit, NombreContacto, Rubro) " +
                " values(" +
                empresa.IdUsuario + ", " +
                "'" + empresa.RazonSocial + "', " +
                "'" + empresa.CUIT + "', " +
                "'" + empresa.NombreDeContacto + "', " +
                "'" + empresa.Rubro + "')";
            int result = Conexion.EjecutarComando(query);
        }

        private void updateEmpresa(Empresa empresa) 
        {
            String query = "update class.Empresa set " +
                "RazonSocial ='" + empresa.RazonSocial + "'," +
                "Cuit ='" + empresa.CUIT + "'," +
                "NombreContacto ='" + empresa.NombreDeContacto + "'," +
                "Rubro ='" + empresa.Rubro + "'" +
                " where IdUsuario = " + empresa.IdUsuario + ";";
            int result = Conexion.EjecutarComando(query);
        }
    }
}
