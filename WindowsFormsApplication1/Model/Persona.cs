using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Model
{
    class Persona : Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public DateTime FechaDeNacimiento { get; set; }

        public Persona(int IdUsuario, string Username, string Password, int RolId, string Nombre, string Apellido,
            string DNI, string TipoDeDocumento, string Email, string Telefono, string Calle, string Numero, 
            string Piso, string Depto, string Localidad, string CodigoPostal, DateTime FechaDeNacimiento, 
            DateTime FechaDeCreacion)
            : base(IdUsuario, Username, Password, RolId, TipoDeDocumento, Email, Telefono, Calle, Numero, Piso, Depto, Localidad,
            CodigoPostal, FechaDeCreacion)
        {
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.DNI = DNI;
            this.FechaDeNacimiento = FechaDeNacimiento;
        }
    }
}
