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
using MercadoEnvio.ABM_Usuario;
using MercadoEnvio.Abm_Rol;
using MercadoEnvio.Visibilidad;
using MercadoEnvio.Listado_Estadistico;
using MercadoEnvio.Generar_Publicación;
using MercadoEnvio.Generar_Publicacion;
using MercadoEnvio.ComprarOfertar;
using MercadoEnvio.Facturas;
using MercadoEnvio.Historial_Cliente;
using MercadoEnvio.Calificar;


namespace MercadoEnvio.Abm_Menu
{
    public partial class AbmMenu : Form
    {
        public AbmMenu()
        {
            InitializeComponent();
            //
        }

        public void CargarMenu(string idusuario,string usuario, DateTime appDate)
        {
            textBox1.Text = usuario;
            textBox1.Enabled = false;
            textBox2.Text = appDate.ToShortDateString();//.Date.ToString().Trim();
            textBox2.Enabled = false;
            DataTable rolUsado = new DataTable();
            string cadena = "select ru.IdRol,r.nombre from Class.RolUsuario ru join Class.Rol r on ru.idrol=r.idrol where ru.IdUsuario='" + idusuario + "' order by Orden";
            rolUsado = Conexion.LeerTabla(cadena);
            
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "IdRol";
            comboBox1.DataSource = rolUsado;
            comboBox1.SelectedIndex = 0;
            //
            CargarMenu2();
            
        }
        public void CargarMenu2()
        {
            DataTable funcionalidades = new DataTable();
            //cadena = "select RolFuncionalidad.idFuncionalidad as id_func,nombre from Class.RolFuncionalidad join Class.Funcionalidad on RolFuncionalidad.idFuncionalidad=funcionalidad.idFuncionalidad where RolFuncionalidad.idRol=" + usuario + " and TienePermisos=1";            
            string cadena = "select RolFuncionalidad.idFuncionalidad as id_func,nombre from Class.RolFuncionalidad join Class.Funcionalidad on RolFuncionalidad.idFuncionalidad=funcionalidad.idFuncionalidad where RolFuncionalidad.idRol=" + comboBox1.SelectedValue.ToString().Trim() + " and TienePermisos=1";
            funcionalidades = Conexion.LeerTabla(cadena);
            //Inicializo todo inhabilitad
            button1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            if (funcionalidades.Rows.Count != 0)
            {
                foreach (DataRow fila in funcionalidades.Rows)
                {
                    int puntomenu = int.Parse(fila["id_func"].ToString());
                    switch (puntomenu)
                    {
                        case 1:
                            button1.Enabled = true;
                            break;
                        case 2:
                            button2.Enabled = true;
                            break;
                        case 3:
                            button3.Enabled = true;
                            break;
                        case 4:
                            button4.Enabled = true;
                            break;
                        case 5:
                            button5.Enabled = true;
                            break;
                        case 6:
                            button6.Enabled = true;
                            break;
                        case 7:
                            button7.Enabled = true;
                            break;
                        case 8:
                            button8.Enabled = true;
                            break;
                        case 9:
                            button9.Enabled = true;
                            break;
                        /*case 10:
                            button9.Enabled = true;
                            break;*/
                    }

                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AbmMenu_Load(object sender, EventArgs e)
        {
        }


        private void button7_Click(object sender, EventArgs e)
        {
            buscar_facturas ver_facturas = new buscar_facturas();
            ver_facturas.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UsuariosForm users = new UsuariosForm();
            users.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Historial ver_historial = new Historial();
            ver_historial.setear_usuario(textBox1.Text.Trim());
            ver_historial.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ABM_Visibilidad visibilidad = new ABM_Visibilidad();
            visibilidad.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Buscar_Publicaciones comprar = new Buscar_Publicaciones();
            comprar.BuscarPublicacion();
            comprar.setear_usuario(textBox1.Text.Trim());
            comprar.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Estadistica listado = new Estadistica();
            listado.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rolabm rol = new Rolabm();
            rol.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Calificaciones califcar = new Calificaciones();
            califcar.setear_usuario(textBox1.Text.Trim());
            califcar.Show();
        }


        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ABM_publicaciones publica = new ABM_publicaciones();
            publica.setear_usuario(textBox1.Text.Trim());
            publica.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMenu2();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void AbmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
