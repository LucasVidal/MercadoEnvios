using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Model
{
    class Usuario
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RolId { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Piso { get; set; }
        public string Depto { get; set; }
        public string Localidad { get; set; }
        public string CodigoPostal { get; set; }
        public DateTime FechaDeCreacion { get; set; }

        public Usuario(int IdUsuario, string Username, string Password, int RolId, string Email,
            string Telefono, string Calle, string Numero, string Piso, string Depto, string Localidad,
            string CodigoPostal, DateTime FechaDeCreacion)
        {
            this.IdUsuario = IdUsuario;
            this.Username = Username;
            this.Password = Password;
            this.RolId = RolId;
            this.Email = Email;
            this.Telefono = Telefono;
            this.Calle = Calle;
            this.Piso = Piso;
            this.Depto = Depto;
            this.Localidad = Localidad;
            this.CodigoPostal = CodigoPostal;
            this.FechaDeCreacion = FechaDeCreacion;
        }
    }
}
