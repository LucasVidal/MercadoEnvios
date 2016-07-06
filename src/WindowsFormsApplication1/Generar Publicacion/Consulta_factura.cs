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

namespace MercadoEnvio.Generar_Publicacion
{
    public partial class Consulta_factura : Form
    {
        public Consulta_factura()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Consulta_factura_Load(object sender, EventArgs e)
        {
        }
        public void consultar(string unaPublicacion)
        {
            string cadena = "select Usuario.Usuario,factura.IdFactura,factura.Numero,TipoItem.Descripcion,Detalle.Cantidad,Detalle.Monto,Factura.Fecha,factura.FormaPago ";
            cadena= cadena + "from class.Factura join class.Detalle on factura.IdFactura=Detalle.IdFactura ";
            cadena= cadena + "join class.Publicacion on factura.IdPublicacion=Publicacion.IdPublicacion ";
            cadena= cadena + "join class.Usuario on Publicacion.IdUsuario=usuario.IdUsuario ";
            cadena= cadena + "join class.TipoItem on detalle.IdItem=TipoItem.IdItem ";
            cadena= cadena + "where Factura.IdPublicacion = "+unaPublicacion;

            cadena= cadena + " union all select Usuario.Usuario,factura.IdFactura,factura.Numero,'Total' as Descripcion,1,factura.total,Factura.Fecha,'' as FormaPago ";
            cadena= cadena + " from class.Factura join class.Publicacion on factura.IdPublicacion=Publicacion.IdPublicacion  ";
            cadena= cadena + " join class.Usuario on Publicacion.IdUsuario=usuario.IdUsuario  ";
            cadena= cadena + " where Factura.IdPublicacion = "+unaPublicacion;

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
    }
}
