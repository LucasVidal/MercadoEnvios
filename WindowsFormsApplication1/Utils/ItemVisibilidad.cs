using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Utils
{
    public class ItemVisibilidad
    {
        //UTOPIA.TipoDeVisibilidad(codigo,descripcion,monto,porcentaje,puede_enviar)
        public string descripcion { get; set; }
        public decimal monto { get; set; }
        public decimal porcentaje { get; set; }
        public decimal precio_envio { get; set; }
        public string baja_logica { get; set; }
        public string codigo { get; set; }
    }
}
