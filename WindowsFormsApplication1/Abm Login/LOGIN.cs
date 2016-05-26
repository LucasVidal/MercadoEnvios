using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using MercadoEnvio.Abm_Menu;
using MercadoEnvio.Base_De_Datos;

namespace MercadoCLass
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Conexion.conectar())
            {
                DataTable users = new DataTable();
                string cod = textBox1.Text;
                string pass = textBox2.Text;
                //string cadena = "select usuario as user_name,clave as contraseña ,loginfallidos as login_fallidos,IdRol as id_rol from Class.Usuario where clave=HASHBYTES('SHA2_256','" + pass.Trim() + "') and Usuario=('" + cod.Trim() + "')";
                string cadena = "select IdUsuario,usuario as user_name,clave as contraseña ,loginfallidos as login_fallidos from Class.Usuario where clave=HASHBYTES('SHA2_256','" + pass.Trim() + "') and Usuario=('" + cod.Trim() + "')";
                users = Conexion.LeerTabla(cadena);
                if (users.Rows.Count == 0)
                {
                    MessageBox.Show("Error al ingresar el Usuario o Contraseña");
                    cadena = "update Class.Usuario set LoginFallidos=LoginFallidos+1 where Usuario=upper('" + cod.Trim() + "')";
                    int resultado = Conexion.EjecutarComando(cadena);
                }
                else
                {
                    foreach (DataRow fila in users.Rows)
                    {
                        if (int.Parse((fila["login_fallidos"].ToString())) < 3)
                        {
                            this.Hide();
                            MessageBox.Show("Bienvenido " + fila["user_name"].ToString());
                            AbmMenu menu = new AbmMenu();

                            //menu.CargarMenu(fila["IdUsuario"].ToString());
                            menu.CargarMenu(fila["IdUsuario"].ToString(), fila["user_name"].ToString());
                            menu.Show();

                        }
                        else
                        {
                            MessageBox.Show("El Usuario" + fila["user_name"].ToString() + " está Bloqueado");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Error al realizar conexion con el motor de Base de Datos");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenido, ha ingresado como invitado");
            AbmMenu menu = new AbmMenu();
            menu.CargarMenu("2","");
            menu.Show();
        }
    }
}
