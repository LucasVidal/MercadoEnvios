using MercadoEnvio.ABM_Usuario;
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
            loadRoles();
            setUserTypeRadioButtonsEnabled(true);
            passwordTxt.Visible = true;
            label8.Visible = true;
            button3.Visible = false;
        }

        public UserEdit(int user_id)
        {
            InitializeComponent();
            UsersDAO usersDao = new UsersDAO();
            this.User = usersDao.get(user_id);
            loadRoles();
            setUserTypeRadioButtonsEnabled(false);
            passwordTxt.Visible = false;
            label8.Visible = false;
            button3.Visible = true;
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

        private void setUserTypeRadioButtonsEnabled(bool enabled)
        {
            personRadioButton.Enabled = enabled;
            companyRadioButton.Enabled = enabled;
        }

        private void loadRoles()
        {
            RoleDAO roleDao = new RoleDAO();
            List<Rol> roles = roleDao.getAllRoles();
            foreach (Rol rol in roles)
            {
                if (rol.IdRol != 1) //Hide admin role
                { 
                    rolCmb.Items.Add(rol);
                }
            }
        }

        private void showUsuario(Usuario user)
        {
            //common fields
            idLbl.Text = user.IdUsuario.ToString();
            usernameTxt.Text = user.Username;
            emailTxt.Text = user.Email;
            phoneTxt.Text = user.Telefono;
            addressStreetTxt.Text = user.Calle;
            addressNumberTxt.Text = user.Numero;
            addressFloorTxt.Text = user.Piso;
            addressDepartmentTxt.Text = user.Depto;
            addressZipcodeTxt.Text = user.CodigoPostal;
            addressCityTxt.Text = user.Localidad;
            estaHabilitadoChk.Checked = user.EstaHabilitado;
            foreach (Rol rol in rolCmb.Items)
            {
                if (rol.IdRol == user.RolId)
                {
                    rolCmb.SelectedIndex = rolCmb.Items.IndexOf(rol);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!FormIsValid()) {
                return;
            }
            UsersDAO usersDAO = new UsersDAO();
            int oldId = this.User == null ? -1 : this.User.IdUsuario;
            Rol rol = (Rol)rolCmb.SelectedItem;
            if (personRadioButton.Checked)
            {
                DateTime createdAt = DateTime.Parse(createdAtTxt.Text);
                DateTime birthDate = DateTime.Parse(birthdateTxt.Text);
                this.User = new Persona(oldId, usernameTxt.Text, rol.IdRol,
                    nameTxt.Text, surnameTxt.Text, IDNumberTxt.Text, IDTypeTxt.Text, emailTxt.Text, phoneTxt.Text,
                    addressStreetTxt.Text, addressNumberTxt.Text, addressFloorTxt.Text, addressDepartmentTxt.Text,
                    addressCityTxt.Text, addressZipcodeTxt.Text, birthDate,
                    createdAt, estaHabilitadoChk.Checked);
            }
            else
            {
                this.User = new Empresa(oldId, usernameTxt.Text, rol.IdRol,
                    companyNameTxt.Text, companyIDTxt.Text, emailTxt.Text, phoneTxt.Text, addressStreetTxt.Text,
                    addressNumberTxt.Text, addressFloorTxt.Text, addressDepartmentTxt.Text, addressCityTxt.Text,
                    addressZipcodeTxt.Text, contactNameTxt.Text, mainActivityTxt.Text, estaHabilitadoChk.Checked);
            }
            usersDAO.save(this.User, passwordTxt.Text);
            this.Close();
        }

        private bool FormIsValid()
        {
            if (!personRadioButton.Checked && !companyRadioButton.Checked)
            {
                MessageBox.Show("Seleccione el tipo de usuario").ToString();
                return false;
            }
            if (usernameTxt.Text.Length == 0)
            {
                MessageBox.Show("El nombre de usuario no puede ser blanco").ToString();
                return false;
            }
            if (this.User == null && passwordTxt.Text.Length == 0)
            {
                MessageBox.Show("El password no puede ser blanco").ToString();
                return false;
            }
            if (rolCmb.SelectedItem == null)
            {
                MessageBox.Show("Debe elegir un rol").ToString();
                return false;
            }
            UsersDAO usersDao = new UsersDAO();
            int existingId = usersDao.FindByUserName(usernameTxt.Text);
            if (existingId != -1 && 
                (this.User == null || existingId != this.User.IdUsuario)
                )
            {
                MessageBox.Show("El nombre de usuario esta en uso").ToString();
                return false;
            }

            if (personRadioButton.Checked)
            {
                try
                {
                    DateTime createdAt = DateTime.Parse(createdAtTxt.Text);
                    DateTime birthDate = DateTime.Parse(birthdateTxt.Text);
                }
                catch
                {
                    MessageBox.Show("Error en uno de los campos de fecha").ToString();
                    return false;
                }
                existingId = usersDao.FindByDNI(IDTypeTxt.Text.Trim(), IDNumberTxt.Text.Trim());
                if (existingId != -1 &&
                    (this.User == null || existingId != this.User.IdUsuario)
                    )
                {
                    MessageBox.Show("Ya existe un usuario con ese DNI").ToString();
                    return false;
                }
            }
            else
            {
                existingId = usersDao.FindByRazonSocialYCuit(companyNameTxt.Text.Trim(), companyIDTxt.Text.Trim());
                if (existingId != -1 &&
                    (this.User == null || existingId != this.User.IdUsuario)
                    )
                {
                    MessageBox.Show("Ya existe una empresa con esa razon social y CUIT").ToString();
                    return false;
                }
            }

            return true; //all clear
        }

        private void personRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            personGroupBox.Enabled = true;
            companyGroupBox.Enabled = false;

        }

        private void companyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            personGroupBox.Enabled = false;
            companyGroupBox.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(this.User.IdUsuario.ToString());
            changePassword.Show();
        }
    }
}
