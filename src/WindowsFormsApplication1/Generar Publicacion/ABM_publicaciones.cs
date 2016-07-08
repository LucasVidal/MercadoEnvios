using MercadoEnvio.Generar_Publicación;
using MercadoEnvio.Utils.AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoEnvio.Generar_Publicacion
{
    public partial class ABM_publicaciones : Form
    {
        int idusuario; //Usuario que está utilizando la aplicación

        public ABM_publicaciones()
        {
            InitializeComponent();
        }

        private void ABM_publicaciones_Load(object sender, EventArgs e)
        {
        }

        public void setear_usuario(string unUsuario)
        {
            DAL da = new DAL();
            DataTable tipop = da.EjecutarComando("SELECT idusuario FROM Class.usuario WHERE usuario='" + unUsuario + "'");
            DataRow row = tipop.Rows[0];
            idusuario = int.Parse(row[0].ToString().Trim());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Publicacion publica = new Publicacion();
            publica.setear_usuario(idusuario);
            publica.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listado_publicaciones busqueda = new Listado_publicaciones();
            busqueda.listado();
            busqueda.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Listado_publicaciones modi = new Listado_publicaciones();
            modi.modificacion();
            modi.setear_usuario(idusuario);
            modi.Show();
        }
    }
}
