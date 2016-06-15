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
    class RoleDAO
    {
        public List<Rol> getAllRoles()
        {
            String query = "select * from class.Rol";
            DataTable result = Conexion.LeerTabla(query);
            List<Rol> list = new List<Rol>();

            foreach (DataRow row in result.Rows)
            {
                int id = Int32.Parse(row["IdRol"].ToString());
                string nombre = row["Nombre"].ToString();
                bool estaHabilitado = Boolean.Parse(row["EstaHabilitado"].ToString());
                list.Add(new Rol(id, nombre, estaHabilitado));       
            }

            return list;
        }
    }
}
