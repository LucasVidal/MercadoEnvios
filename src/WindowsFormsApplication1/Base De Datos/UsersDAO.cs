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
            if (usuario.IdUsuario == null) {
                int newId = createCommon(usuario);
                usuario.IdUsuario = newId;
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
                String query = "select * from class.usuario, class.persona where " +
    "class.Usuario.IdUsuario = class.Persona.IdUsuario and class.Usuario.IdUsuario = " + userID.ToString();
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
                String query = "select * from class.usuario, class.empresa where " +
    "class.Usuario.IdUsuario = class.Empresa.IdUsuario and class.Usuario.IdUsuario = " + userID.ToString();
                DataTable result = Conexion.LeerTabla(query);
                DataRow row = result.Rows[0];
                if (result.Rows.Count == 0) return null;

                return new Empresa((int)row["IdUsuario"], row["Usuario"].ToString().Trim(), null,
                    (int)row["IdRol"], row["RazonSocial"].ToString(),
                    row["Cuit"].ToString(), row["Mail"].ToString().Trim(), row["Telefono"].ToString().Trim(),
                    row["Calle"].ToString().Trim(), row["Numero"].ToString().Trim(), row["Piso"].ToString().Trim(),
                    row["Depto"].ToString().Trim(), row["Localidad"].ToString().Trim(), row["CodigoPostal"].ToString().Trim(),
                    row["NombreContacto"].ToString().Trim(), row["Rubro"].ToString().Trim(), 
                    row.Field<DateTime>("FechaCreacion"), (bool)row["EstaHabilitado"]
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
            String query = "insert into class.usuario (Usuario, Clave, EstaHabilitado, IdRol, LoginFallidos, Mail, "
                + "Telefono, Ciudad, Calle, Numero, Piso, Depto, Localidad, CodigoPostal, FechaCreacion) " +
                " values(" + usuario.IdUsuario + ", " + hashClave(usuario.Password) + ", 1, " + usuario.RolId
                + ", 0, " + usuario.Email + ", " + usuario.Telefono + ", NULL, "
                + usuario.Calle + ", " + usuario.Numero + ", " + usuario.Piso + ", " + usuario.Depto + ", "
                + usuario.Localidad + ", " + usuario.CodigoPostal + ", " + usuario.FechaDeCreacion + ")";
            int newUserId = Conexion.EjecutarComando(query);
            return newUserId;
        }

        private int updateCommon(Usuario usuario)
        {
            String query = "update class.Usuario set " +
                "Usuario ='" + usuario.Username + "', " +
                "Clave ='" + hashClave(usuario.Password) + "', " +
                "EstaHabilitado =" + usuario.EstaHabilitado.ToString() + ", " +
                "IdRol =" + usuario.RolId.ToString() + ", " +
                "Mail ='" + usuario.Email + "', " +
                "Telefono ='" + usuario.Telefono + "', " +
                "Ciudad = NULL, " +
                "Calle ='" + usuario.Calle + "', " +
                "Numero ='" + usuario.Numero + "', " + 
                "Piso ='" + usuario.Piso + "', " +
                "Depto ='" + usuario.Depto + "', " +
                "Localidad ='" + usuario.Localidad + "', " +
                "CodigoPostal ='" + usuario.CodigoPostal + "', " +
                "FechaCreacion ='" + usuario.FechaDeCreacion + "' " +
                "where IdUsuario = " + usuario.IdUsuario.ToString() + ";";
            int newUserId = Conexion.EjecutarComando(query);
            return newUserId;
        }

        private void createPersona(Persona persona)
        {
            String query = "insert into class.persona (IdUsuario, Nombre, Apellido, DNI, FechaNac) " +
                " values(" + persona.IdUsuario + ", " + persona.Nombre + ", " + persona.Apellido + ", " 
                + persona.DNI + ", " + persona.FechaDeNacimiento + ")";
            int result = Conexion.EjecutarComando(query);
        }

        private void updatePersona(Persona persona)
        {
            String query = "update class.Persona set " +
                "Nombre ='" + persona.Nombre + "', " +
                "Apellido ='" + persona.Apellido + "', " +
                "DNI =" + persona.DNI + ", " +
                " where IdUsuario = " + persona.IdUsuario.ToString() + ";";
            int result = Conexion.EjecutarComando(query);
        }

        private void createEmpresa(Empresa empresa) 
        {
            String query = "insert into class.empresa (IdUsuario, RazonSocial, Cuit, NombreContacto, Rubro) " +
                " values(" + empresa.IdUsuario + ", " + empresa.RazonSocial + ", " + empresa.CUIT + ", " 
                + empresa.NombreDeContacto + ", " + empresa.Rubro + ")";
            int result = Conexion.EjecutarComando(query);
        }

        private void updateEmpresa(Empresa empresa) 
        {
            String query = "update class.Empresa set " +
                "RazonSocial ='" + empresa.RazonSocial + "'," +
                "Cuit ='" + empresa.CUIT + "'," +
                "NombreContacto =" + empresa.NombreDeContacto + "," +
                "Rubro =" + empresa.Rubro + "," +
                " where IdUsuario = " + empresa.IdUsuario + ";";
            int result = Conexion.EjecutarComando(query);
        }

        private string hashClave(string password) {
            return password; //TODO
        }
    }
}
