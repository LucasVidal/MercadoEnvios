﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Model
{
    public class Empresa : Usuario
    {
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public string NombreDeContacto { get; set; }
        public string Rubro { get; set; }

        public Empresa(int IdUsuario, string Username, int RolId, string RazonSocial, 
            string CUIT, string Email, string Telefono, string Calle, string Numero,
            string Piso, string Depto, string Localidad, string CodigoPostal, string NombreDeContacto,
            string Rubro, bool EstaHabilitado)
            : base(IdUsuario, Username, RolId, Email, Telefono, Calle, Numero, Piso, Depto, Localidad,
            CodigoPostal, EstaHabilitado)
        {
            this.RazonSocial = RazonSocial;
            this.CUIT = CUIT;
            this.NombreDeContacto = NombreDeContacto;
            this.Rubro = Rubro;
        }
    }
}
