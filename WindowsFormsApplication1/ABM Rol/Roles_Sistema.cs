using MercadoEnvio.Base_De_Datos;
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
    public partial class Roles_Sistema : Form
    {
        public Roles_Sistema()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Roles_Sistema_Load(object sender, EventArgs e)
        {
            string cadena = "select idrol,nombre,estahabilitado from Class.Rol";
            DataTable roles = new DataTable();
            roles = Conexion.LeerTabla(cadena);
            dataGridView1.DataSource = roles;
            dataGridView1.ReadOnly = true;
        }
    }
}
