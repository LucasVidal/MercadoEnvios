using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Utils
{
    class Usuario
    {
        public int id { set; get; }
        public string nombre { set; get; }
        public int tipo { set; get; } //1 == cliente, 2 == empresa, 3 == admin, etc
    }
}
