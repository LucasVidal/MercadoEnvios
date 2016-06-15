using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Utils
{
    class SesionUsuario
    {
        private static Usuario usuario;

        public static Usuario GetUsuario()
        {
            if (usuario == null)
            {
                usuario = new Usuario();
                usuario.id = 3;//incializacion para pruebas
                return usuario;
            }
            return usuario;
        }
    }
}
