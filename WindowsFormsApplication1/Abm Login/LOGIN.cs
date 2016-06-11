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
using System.Diagnostics;

namespace MercadoCLass
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            progressBar1.Visible = false;
            label4.Visible = false;
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
            progressBar1.Visible = true;
            label4.Visible = true;
            this.timer1.Start(); 
            if (Conexion.conectar())
            {
                DataTable users = new DataTable();
                string cod = textBox1.Text;
                string pass = textBox2.Text;
                //string cadena = "select usuario as user_name,clave as contraseña ,loginfallidos as login_fallidos,IdRol as id_rol from Class.Usuario where clave=HASHBYTES('SHA2_256','" + pass.Trim() + "') and Usuario=('" + cod.Trim() + "')";
                string cadena = "select IdUsuario,usuario as user_name,clave as contraseña ,loginfallidos as login_fallidos from Class.Usuario where clave=convert(varbinary,convert(nvarchar(4000),Class.psencriptar('" + pass.Trim() + "'))) and Usuario=('" + cod.Trim() + "')";
                users = Conexion.LeerTabla(cadena);
                if (users.Rows.Count == 0)
                {
                    this.timer1.Stop(); 
                    progressBar1.Visible = false;
                    label4.Visible = false;
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
                            var value = System.Configuration.ConfigurationManager.AppSettings["FechaSistema"]; //ConfigurationSettings.AppSettings["FechaSistema"];
                            var appDate = DateTime.Parse(value);
                            cadena = "set dateformat dmy";
                            int resultado = Conexion.EjecutarComando(cadena);
                            //Actualizo las publicaciones activas por si se volvio para atras la fecha
                            cadena = "update Class.Publicacion set idestado=2 where fechavencimiento>='" + appDate.ToString().Trim() + "' and fechainicio<='"+ appDate.ToString().Trim() + "'";
                            resultado = Conexion.EjecutarComando(cadena);
                            //Actualizo las publicaciones vencidas
                            cadena = "update Class.Publicacion set idestado=4 where fechavencimiento<'" + appDate.ToString().Trim() + "'";
                            resultado = Conexion.EjecutarComando(cadena);

                            
                            AbmMenu menu = new AbmMenu();

                            //menu.CargarMenu(fila["IdUsuario"].ToString());
                            menu.CargarMenu(fila["IdUsuario"].ToString(), fila["user_name"].ToString(), appDate);
                            menu.Show();

                        }
                        else
                        {
                            this.timer1.Stop(); 
                            progressBar1.Visible = false;
                            label4.Visible = false;
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

        private void progressBar1_Click(object sender, EventArgs e)
        {
            ProgressBar pBar = new ProgressBar();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(1);
        }

        
        /*private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenido, ha ingresado como invitado");
            AbmMenu menu = new AbmMenu();
            menu.CargarMenu("2","",);
            menu.Show();
        }*/
    }
}
