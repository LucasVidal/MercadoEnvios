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

        private void UserEdit_Load(object sender, EventArgs e)
        {
            if (this.User != null) {
                if (this.User.GetType() == typeof(Persona))
                {
                    showPersona((Persona)this.User);
                }
                else
                {
                    showEmpresa((Empresa)this.User);
                }
            }
        }

        private void showUsuario(Usuario user)
        {
            //common fields
            RoleDAO roleDao = new RoleDAO();
            idLbl.Text = user.IdUsuario.ToString();
            usernameTxt.Text = user.Username;
            emailTxt.Text = user.Email;
            phoneTxt.Text = user.Telefono;
            addressStreetTxt.Text = user.Calle;
            addressNumberTxt.Text = user.Numero;
            addressFloorTxt.Text = user.Depto;
            addressZipcodeTxt.Text = user.CodigoPostal;
            addressCityTxt.Text = user.Localidad;
            estaHabilitadoChk.Checked = user.EstaHabilitado;
            List<Rol> roles = roleDao.getAllRoles();
            foreach (Rol rol in roles)
            {
                rolCmb.Items.Add(rol);
                if (rol.IdRol == user.RolId)
                {
                    rolCmb.SelectedIndex = roles.IndexOf(rol);
                }
            }
        }

        private void showEmpresa(Empresa empresa)
        {
            showUsuario(empresa);
            companyRadioButton.Select();

            //Empresa fields
            companyNameTxt.Text = empresa.RazonSocial;
            companyIDTxt.Text = empresa.CUIT;
            contactNameTxt.Text = empresa.NombreDeContacto;
            mainActivityTxt.Text = empresa.Rubro;
        }

        private void showPersona(Persona persona)
        {
            showUsuario(persona);
            personRadioButton.Select();

            //Persona fields
            nameTxt.Text = persona.Nombre;
            surnameTxt.Text = persona.Apellido;
            IDTypeTxt.Text = persona.TipoDeDocumento;
            IDNumberTxt.Text = persona.DNI;
            birthdateTxt.Text = persona.FechaDeNacimiento.ToString();
            createdAtTxt.Text = persona.FechaDeCreacion.ToString();
        }

        private void personGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsersDAO usersDAO = new UsersDAO();
            int oldId = this.User == null ? -1 : this.User.IdUsuario;
            Rol rol = (Rol)rolCmb.SelectedItem;
            if (personRadioButton.Checked)
            {

                DateTime createdAt;
                DateTime birthDate;
                try
                {
                    createdAt = DateTime.Parse(createdAtTxt.Text);
                    birthDate = DateTime.Parse(birthdateTxt.Text);
                }
                catch
                {
                    MessageBox.Show("Error en uno de los campos").ToString();
                    return;
                }
                this.User = new Persona(oldId, usernameTxt.Text, passwordTxt.Text, rol.IdRol,
                    nameTxt.Text, surnameTxt.Text, IDNumberTxt.Text, IDTypeTxt.Text, emailTxt.Text, phoneTxt.Text,
                    addressStreetTxt.Text, addressNumberTxt.Text, addressFloorTxt.Text, addressDepartmentTxt.Text,
                    addressCityTxt.Text, addressZipcodeTxt.Text, birthDate,
                    createdAt, estaHabilitadoChk.Checked);
            }
            else
            {
                this.User = new Empresa(oldId, usernameTxt.Text, passwordTxt.Text, rol.IdRol,
                    companyNameTxt.Text, companyIDTxt.Text, emailTxt.Text, phoneTxt.Text, addressStreetTxt.Text,
                    addressNumberTxt.Text, addressFloorTxt.Text, addressDepartmentTxt.Text, addressCityTxt.Text,
                    addressZipcodeTxt.Text, contactNameTxt.Text, mainActivityTxt.Text, estaHabilitadoChk.Checked);
            }
            usersDAO.save(this.User);
        }
    }
}
