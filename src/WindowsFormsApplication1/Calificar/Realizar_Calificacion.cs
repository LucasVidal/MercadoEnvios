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
using WindowsFormsApplication1.Utils;

namespace MercadoEnvio.Calificar
{
    public partial class Realizar_Calificacion : Form
    {
        int idusuario;
        int compra;
        public Realizar_Calificacion()
        {
            InitializeComponent();
        }

        private void Realizar_Calificacion_Load(object sender, EventArgs e)
        {
            Titulo.Text = "Calificar Compra Número " + compra.ToString().Trim();
            Llenar_comboBox_estrellas();
        }

        private void Llenar_comboBox_estrellas()
        {
            comboBox_estrellas.Items.Add("1 ESTRELLA");
            comboBox_estrellas.Items.Add("2 ESTRELLAS");
            comboBox_estrellas.Items.Add("3 ESTRELLAS");
            comboBox_estrellas.Items.Add("4 ESTRELLAS");
            comboBox_estrellas.Items.Add("5 ESTRELLAS");
            comboBox_estrellas.SelectedIndex = 0;
        }

        public void setear_valores(int unUsuario, int unaCompra)
        {
            idusuario = unUsuario;
            compra = unaCompra;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int cantidad=255 - comentario.TextLength;
            restantes.Enabled = false;
            restantes.Text = "Caracteres restantes: " + cantidad.ToString().Trim();
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            comentario.Text = "";
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Btn_Crear_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = "select compra.idpublicacion,Publicacion.IdUsuario from class.Compra join class.Publicacion on compra.IdPublicacion=Publicacion.IdPublicacion where idcompra=" + compra.ToString().Trim();
                DataTable tabla = new DataTable();
                tabla = Conexion.LeerTabla(cmd);
                DataRow compra_realizada = tabla.Rows[0];
                int estrellas = 0;
                //int.Parse(comboBox_estrellas.SelectedValue.ToString().Trim());
                if (comboBox_estrellas.Text.Equals("1 ESTRELLA"))
                    estrellas=1;
                if (comboBox_estrellas.Text.Equals("2 ESTRELLAS"))
                    estrellas=2;
                if (comboBox_estrellas.Text.Equals("3 ESTRELLAS"))
                    estrellas = 3;
                if (comboBox_estrellas.Text.Equals("4 ESTRELLAS"))
                    estrellas = 4;
                if (comboBox_estrellas.Text.Equals("5 ESTRELLAS"))
                    estrellas = 5;
                string detalle = comentario.Text.Trim();
                bool response = DBService.Nueva_Calificacion(idusuario, compra, int.Parse(compra_realizada[0].ToString().Trim()), int.Parse(compra_realizada[1].ToString().Trim()), estrellas,detalle);
                if (response)
                {
                    MessageBox.Show("Calificacion ingresada con exito!");
                }
                else
                    MessageBox.Show("Hubo un error al ingresar la calificación");
            }
            catch
            {
                MessageBox.Show("Hubo un error al ingresar la calificación");
            }
        }
    }
}
