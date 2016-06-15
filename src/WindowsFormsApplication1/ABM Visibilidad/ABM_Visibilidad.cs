using MercadoEnvio.ALTA_Visibilidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoEnvio.Visibilidad
{
    public partial class ABM_Visibilidad : Form
    {
        public ABM_Visibilidad()
        {
            InitializeComponent();
        }

        private void ABM_Visibilidad_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Visibilidad busqueda = new Visibilidad();
            busqueda.listado();
            busqueda.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Alta alta = new Alta();
            alta.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Visibilidad MODIFICACION = new Visibilidad();
            MODIFICACION.modificacion();
            MODIFICACION.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Visibilidad BAJA = new Visibilidad();
            BAJA.baja();
            BAJA.Show();
        }
    }
}
