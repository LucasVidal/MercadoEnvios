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
using WindowsFormsApplication1.Base_De_Datos;
using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1.ABM_Usuario
{
    public partial class UserEdit : Form
    {
        public UserEdit()
        {
            InitializeComponent();
        }

        public UserEdit(int user_id)
        {
            InitializeComponent();
            loadUser(user_id);
        }

        private void loadUser(int user_id)
        {
            String query = "SELECT * FROM Class.Usuario WHERE idusuario = " + user_id.ToString();
            DataTable user = new DataTable();
            user = Conexion.LeerTabla(query);
        }

        private void UserEdit_Load(object sender, EventArgs e)
        {
            UsersDAO dao = new UsersDAO();
            Persona persona = dao.get(62);

            idLbl.Text = persona.IdUsuario.ToString();
            usernameTxt.Text = persona.Username;
            nombreTxt.Text = persona.Nombre;
            apellidoTxt.Text = persona.Apellido;
        }
    }
}
