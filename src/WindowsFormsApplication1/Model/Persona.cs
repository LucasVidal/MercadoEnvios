using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Model
{
    public class Persona : Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDeDocumento { get; set; }
        public string DNI { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public DateTime FechaDeCreacion { get; set; }

        public Persona(int IdUsuario, string Username, int RolId, string Nombre, string Apellido,
            string DNI, string TipoDeDocumento, string Email, string Telefono, string Calle, string Numero, 
            string Piso, string Depto, string Localidad, string CodigoPostal, DateTime FechaDeNacimiento, 
            DateTime FechaDeCreacion, bool EstaHabilitado)
            : base(IdUsuario, Username, RolId, Email, Telefono, Calle, Numero, Piso, Depto, Localidad,
            CodigoPostal, EstaHabilitado)
        {
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.TipoDeDocumento = TipoDeDocumento;
            this.DNI = DNI;
            this.FechaDeNacimiento = FechaDeNacimiento;
            this.FechaDeCreacion = FechaDeCreacion;
        }
    }
}
