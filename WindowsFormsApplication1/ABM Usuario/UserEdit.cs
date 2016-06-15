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
        private Usuario User;

        public UserEdit()
        {
            InitializeComponent();
        }

        public UserEdit(int user_id)
        {
            InitializeComponent();
            UsersDAO usersDao = new UsersDAO();
            this.User = usersDao.get(user_id);
        }

        private void loadUser(int user_id)
        {
            String query = "SELECT * FROM Class.Usuario WHERE idusuario = " + user_id.ToString();
            DataTable user = new DataTable();
            user = Conexion.LeerTabla(query);
        }

        private void UserEdit_Load(object sender, EventArgs e)
        {
            //common fields
            RoleDAO roleDao = new RoleDAO();
            Usuario user = this.User;
            idLbl.Text = user.IdUsuario.ToString();
            usernameTxt.Text = user.Username;
            emailTxt.Text = user.Email;
            phoneTxt.Text = user.Telefono;
            addressStreetTxt.Text = user.Calle;
            addressNumberTxt.Text = user.Numero;
            addressFloorTxt.Text = user.Depto;
            addressZipcodeTxt.Text = user.CodigoPostal;
            addressCityTxt.Text = user.Localidad;

            List<Rol> roles = roleDao.getAllRoles();
            foreach (Rol rol in roles)
            {
                rolCmb.Items.Add(rol);
                if (rol.IdRol == user.RolId)
                {
                    rolCmb.SelectedIndex = roles.IndexOf(rol);
                }
            }
            
            if (this.User.GetType() == typeof(Persona))
            {
                personRadioButton.Select();
                Persona persona = (Persona)this.User;

                //Persona fields
                nameTxt.Text = persona.Nombre;
                surnameTxt.Text = persona.Apellido;
                IDTypeTxt.Text = persona.TipoDeDocumento;
                IDNumberTxt.Text = persona.DNI;
                birthdateTxt.Text = persona.FechaDeNacimiento.ToString();
                createdAtTxt.Text = persona.FechaDeCreacion.ToString();
            }
            else
            {
                companyRadioButton.Select();
                Empresa empresa = (Empresa)this.User;

                //Empresa fields
                companyNameTxt.Text = empresa.RazonSocial;
                companyIDTxt.Text = empresa.CUIT;
                contactNameTxt.Text = empresa.NombreDeContacto;
                mainActivityTxt.Text = empresa.Rubro;
            }

        }
    }
}
