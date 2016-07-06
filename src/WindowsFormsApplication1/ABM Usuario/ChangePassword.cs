using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Base_De_Datos;

namespace MercadoEnvio.ABM_Usuario
{
    public partial class ChangePassword : Form
    {
        private int IdUsuario { get; set; }
        public ChangePassword(string IdUsuario)
        {
            InitializeComponent();
            this.IdUsuario = Int32.Parse(IdUsuario);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UsersDAO usersDAO = new UsersDAO();
            usersDAO.ChangePassword(this.IdUsuario, textBox1.Text);
            MessageBox.Show("El password fue modificado exitosamente");
            this.Close();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }
    }
}
