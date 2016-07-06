using MercadoEnvio.Base_De_Datos;
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
using WindowsFormsApplication1.Utils;

namespace MercadoEnvio.Calificar
{
    public partial class Calificaciones : Form
    {
        int idusuario; //Usuario que está utilizando la aplicación

        public Calificaciones()
        {
            InitializeComponent();
        }

        public void setear_usuario(string unUsuario)
        {
            DAL da = new DAL();
            DataTable tipop = da.EjecutarComando("SELECT idusuario FROM Class.usuario WHERE usuario='" + unUsuario + "'");
            DataRow row = tipop.Rows[0];
            idusuario = int.Parse(row[0].ToString().Trim());
        }

        private void Factura_Click(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            btn_calificar.Visible = true;
            string cmd="select top 5 Publicacion.IdPublicacion,Publicacion.Descripcion,usuario.Usuario Vendedor,Calificacion,isnull(Detalle,'') Detalle,Fechayhora from class.Calificacion ";
            cmd = cmd + " join class.Publicacion on Calificacion.IdPublicacion=Publicacion.IdPublicacion ";
            cmd = cmd + " join class.Usuario on IdUsuarioPub=usuario.IdUsuario ";
            cmd = cmd + " where idusuariocom = " + idusuario.ToString().Trim();
            cmd = cmd + " order by fechayhora desc,idcompra desc ";
            DataTable calificaciones_anteriores = new DataTable();
            calificaciones_anteriores = Conexion.LeerTabla(cmd);
            dataGridView2.DataSource = calificaciones_anteriores;
            dataGridView2.ReadOnly = true;
            //
            cmd = "select count(*) cantidad from class.Calificacion where idusuariocom=" + idusuario.ToString().Trim();
            DataTable tabla = new DataTable();
            tabla = Conexion.LeerTabla(cmd);
            DataRow cantidad = tabla.Rows[0];
            total.Text = "0";
            if (tabla.Rows.Count > 0)
            {
                total.Text = cantidad[0].ToString().Trim();
            }
            //
            cmd = "select count(*) cantidad from class.Calificacion where calificacion=1 and idusuariocom=" + idusuario.ToString().Trim();
            tabla = new DataTable();
            tabla = Conexion.LeerTabla(cmd);
            cantidad = tabla.Rows[0];
            estrellas_1.Text = "0";
            if (tabla.Rows.Count > 0)
            {
                estrellas_1.Text = cantidad[0].ToString().Trim();
            }
            //
            cmd = "select count(*) cantidad from class.Calificacion where calificacion=2 and idusuariocom=" + idusuario.ToString().Trim();
            tabla = new DataTable();
            tabla = Conexion.LeerTabla(cmd);
            cantidad = tabla.Rows[0];
            estrellas_2.Text = "0";
            if (tabla.Rows.Count > 0)
            {
                estrellas_2.Text = cantidad[0].ToString().Trim();
            }
            //
            cmd = "select count(*) cantidad from class.Calificacion where calificacion=3 and idusuariocom=" + idusuario.ToString().Trim();
            tabla = new DataTable();
            tabla = Conexion.LeerTabla(cmd);
            cantidad = tabla.Rows[0];
            estrellas_3.Text = "0";
            if (tabla.Rows.Count > 0)
            {
                estrellas_3.Text = cantidad[0].ToString().Trim();
            }
            //
            cmd = "select count(*) cantidad from class.Calificacion where calificacion=4 and idusuariocom=" + idusuario.ToString().Trim();
            tabla = new DataTable();
            tabla = Conexion.LeerTabla(cmd);
            cantidad = tabla.Rows[0];
            estrellas_4.Text = "0";
            if (tabla.Rows.Count > 0)
            {
                estrellas_4.Text = cantidad[0].ToString().Trim();
            }
            //
            cmd = "select count(*) cantidad from class.Calificacion where calificacion=5 and idusuariocom=" + idusuario.ToString().Trim();
            tabla = new DataTable();
            tabla = Conexion.LeerTabla(cmd);
            cantidad = tabla.Rows[0];
            estrellas_5.Text = "0";
            if (tabla.Rows.Count > 0)
            {
                estrellas_5.Text = cantidad[0].ToString().Trim();
            }
            //
            total.ReadOnly=true;
            estrellas_1.ReadOnly=true;
            estrellas_2.ReadOnly=true;
            estrellas_3.ReadOnly=true;
            estrellas_4.ReadOnly=true;
            estrellas_5.ReadOnly = true;
            //
            string cadena = "select idcompra,publicacion.IdPublicacion,Publicacion.Descripcion,usuario.usuario Vendedor,compra.Fecha 'Fecha de Compra',compra.Cantidad,compra.Monto";
            cadena = cadena + " from class.Compra join class.Publicacion on compra.IdPublicacion=Publicacion.IdPublicacion ";
            cadena = cadena + " join class.Usuario on Publicacion.IdUsuario=usuario.IdUsuario ";
            cadena = cadena + " where IdCompra not in (select IdCompra from class.Calificacion) ";
            cadena = cadena + " and compra.idusuario = " + idusuario.ToString().Trim();
            cadena = cadena + " order by fecha";

            DataTable compras = new DataTable();
            compras = Conexion.LeerTabla(cadena);
            if (compras.Rows.Count <= 0)
            {
                dataGridView1.DataSource = "";
                btn_calificar.Visible = false;
                MessageBox.Show("No existen compras sin calificar.");
                return;
            }
            dataGridView1.DataSource = compras;
            dataGridView1.ReadOnly = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                try
                {
                    string Idcompra = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    Realizar_Calificacion ver = new Realizar_Calificacion();
                    ver.setear_valores(idusuario, int.Parse(Idcompra));
                    ver.Show();
                    this.Dispose();
                }
                catch
                {
                    MessageBox.Show("No se seleccionó registro para calificar.");
                }
            }
        }

    }
}
