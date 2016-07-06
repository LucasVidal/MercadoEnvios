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

        private void searchPersona()
        {
            String query = "SELECT u.IdUsuario, u.Usuario, p.Nombre, p.Apellido, p.DNI, u.Mail " +
                "FROM Class.Usuario u, Class.Persona p WHERE u.IdUsuario = p.IdUsuario";
            query += textBox1.Text.Length > 0 ? " AND p.Nombre like '%" + textBox1.Text.Trim() + "%'" : "";
            query += textBox2.Text.Length > 0 ? " AND p.Apellido like '%" + textBox2.Text.Trim() + "%'" : "";
            query += textBox3.Text.Length > 0 ? " AND p.DNI like '%" + textBox3.Text.Trim() + "%'" : "";
            query += textBox4.Text.Length > 0 ? " AND u.Mail like '%" + textBox4.Text.Trim() + "%'" : "";

            DataTable users = new DataTable();
            users = Conexion.LeerTabla(query);
            dataGridView1.DataSource = users;
            dataGridView1.ReadOnly = true;
        }

        private void searchEmpresa()
        {
            String query = "SELECT u.IdUsuario, u.Usuario, e.RazonSocial, e.CUIT, u.Mail " +
                "FROM Class.Usuario u, Class.Empresa e WHERE u.IdUsuario = e.IdUsuario";
            query += textBox5.Text.Length > 0 ? " AND e.RazonSocial like '%" + textBox5.Text.Trim() + "%'" : "";
            query += textBox6.Text.Length > 0 ? " AND e.CUIT like '%" + textBox6.Text.Trim() + "%'" : "";
            query += textBox7.Text.Length > 0 ? " AND u.Mail like '%" + textBox7.Text.Trim() + "%'" : "";

            DataTable users = new DataTable();
            users = Conexion.LeerTabla(query);
            dataGridView1.DataSource = users;
            dataGridView1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserEdit userEdit = new UserEdit();
            userEdit.Show();
        }

        private void editUserBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells["IdUsuario"].FormattedValue.ToString());
            UserEdit userEdit = new UserEdit(id);
            userEdit.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchPersona();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            searchPersona();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            searchPersona();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            searchPersona();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            searchEmpresa();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            searchEmpresa();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            searchEmpresa();
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            editUserBtn.Enabled = true;
            removeUserBtn.Enabled = true;
        }

    }
}
