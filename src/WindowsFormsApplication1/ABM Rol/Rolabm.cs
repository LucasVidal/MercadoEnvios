using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoEnvio.Abm_Rol
{
    public partial class Rolabm : Form
    {
        public Rolabm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rol busqueda = new Rol();
            busqueda.listado();
            busqueda.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rol alta = new Rol();
            alta.alta();
            alta.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rol modi = new Rol();
            modi.modificacion();
            modi.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Roles_Sistema consulta = new Roles_Sistema();
            consulta.Show();
        }
    }
}
