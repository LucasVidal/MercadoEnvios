using MercadoEnvio.Base_De_Datos;
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
    public partial class Listado_publicaciones : Form
    {
        public Listado_publicaciones()
        {
            InitializeComponent();
        }

        private void Listado_publicaciones_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cadena = "select Publicacion.IdPublicacion Numero,Publicacion.Descripcion,Publicacion.Stock,Publicacion.FechaInicio,Publicacion.FechaVencimiento,Publicacion.Precio,";
            cadena=cadena+"Rubro.Desc_corta rubro,Visibilidad.Descripcion visibilidad,Usuario.Usuario,Estado.Descripcion estado,TipoPublicacion.Descripcion Tipo, case when envio=0 THEN 'NO' ELSE 'SI' END ENVIO ";
            cadena=cadena+"from class.Publicacion join class.Rubro on Publicacion.IdRubro=Rubro.IdRubro ";
            cadena=cadena+"join class.Visibilidad on Publicacion.IdVisibilidad=Visibilidad.IdVisibilidad ";
            cadena=cadena+"join class.Usuario on Publicacion.IdUsuario=Usuario.IdUsuario ";
            cadena=cadena+"join Class.Estado on Publicacion.IdEstado=Estado.IdEstado ";
            cadena = cadena + "join class.TipoPublicacion on Publicacion.IdTipo=TipoPublicacion.IdTipo";
            if (textBox1.Text.Trim().Length > 0)
            {
                cadena = cadena + " where Publicacion.descripcion like '%" + textBox1.Text.Trim() + "%'";
            }

            if (textBox2.Text.Trim().Length > 0)
            {
                if (textBox1.Text.Trim().Length > 0)
                {
                    cadena = cadena + " and Publicacion.idpublicacion like '%" + textBox2.Text.Trim() + "%'";
                }
                else
                {
                    cadena = cadena + " where Publicacion.idpublicacion like '%" + textBox2.Text.Trim() + "%'";
                }
            }

            DataTable publicaciones = new DataTable();
            publicaciones = Conexion.LeerTabla(cadena);
            if (publicaciones.Rows.Count <= 0)
            {
                MessageBox.Show("No existen publicaciones con esos filtros.");
            }
            else
            {
                dataGridView1.DataSource = publicaciones;
                dataGridView1.ReadOnly = true;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = " ";
            textBox1.Text = " ";
            textBox2.Text = " ";
        }

        public void listado()
        {
            dataGridView1.ReadOnly = true;
        }

        public void modificacion()
        {
            button1.Visible = true;
            dataGridView1.ReadOnly = false;
            seleccionar.ReadOnly = false;
            seleccionar.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                try
                {
                    string IdPublicacion = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    DAL da = new DAL();
                    DataTable publicacion = da.EjecutarComando("select idestado from class.Publicacion where Publicacion.idpublicacion =" + IdPublicacion.Trim());
                    DataRow publicacion_seleccionada = publicacion.Rows[0];
                    if (publicacion.Rows[0].ItemArray[0].ToString().Trim() != "4")
                    {
                        Publicacion modi = new Publicacion();
                        modi.modificacion(IdPublicacion);
                        modi.Show();
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("No se puede modificar una publicación finalizada.");
                    }
                }
                catch
                {
                    MessageBox.Show("No se seleccionó registro para modificar.");
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
