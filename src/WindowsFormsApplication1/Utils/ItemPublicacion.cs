using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Utils
{
    class ItemPublicacion
    {
        public string rubro { set; get; }
        public string tipo_publ { set; get; }
        public string estado_publ { set; get; }
        public string visibilidad { set; get; }
        public decimal stock { set; get; }
        public decimal precio_por_unidad { set; get; }
        public string permite_preguntas { set; get; }
        public string descripcion { set; get; }
        public int user_id { set; get; }
        public string permiteEnvio { set; get; }
    }
}
