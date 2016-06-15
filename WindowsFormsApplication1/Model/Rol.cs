using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Model
{
    public class Rol
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public bool EstaHabilitado { get; set; }

        public Rol(int IdRol, string Nombre, bool EstaHabilitado)
        {
            this.IdRol = IdRol;
            this.Nombre = Nombre;
            this.EstaHabilitado = EstaHabilitado;
        }

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
