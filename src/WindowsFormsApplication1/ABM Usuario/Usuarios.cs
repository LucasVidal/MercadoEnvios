using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MercadoEnvio.Base_De_Datos;
using WindowsFormsApplication1.ABM_Usuario;

namespace MercadoEnvio.ABM_Usuario
{
    public partial class UsuariosForm : Form
    {
        public UsuariosForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String text = ((TextBox)sender).Text;
            String query = "SELECT IdUsuario, Usuario FROM Class.Usuario WHERE usuario like '%" + text + "%'";
            DataTable users = new DataTable();
            users = Conexion.LeerTabla(query);
            dataGridView1.DataSource = users;
            dataGridView1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void editUserBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells["IdUsuario"].FormattedValue.ToString());
            UserEdit userEdit = new UserEdit(id);
            userEdit.Show();
        }
    }
}
