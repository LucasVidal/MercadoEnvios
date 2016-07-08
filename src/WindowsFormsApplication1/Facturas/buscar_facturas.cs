using MercadoEnvio.Base_De_Datos;
using MercadoEnvio.Generar_Publicacion;
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

namespace MercadoEnvio.Facturas
{
    public partial class buscar_facturas : Form
    {
        PaginationController controlador;
        bool controlesHabilitados;

        public buscar_facturas()
        {
            InitializeComponent();
            controlesHabilitados = false;
        }

        private void buscar_facturas_Load(object sender, EventArgs e)
        {
            Llenar_ComboBox_Item();
            Llenar_ComboBox_Usuario();
            Crear_PaginationController();
            dateTime_desde.Visible = true;
            int currentYear = DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["FechaSistema"]).Year;
            dateTime_desde.Value = new DateTime(currentYear, 1, 1);
            dateTime_desde.Format = DateTimePickerFormat.Custom;
            dateTime_desde.CustomFormat = "dd/MM/yyyy";
            dateTime_hasta.Visible = true;
            dateTime_hasta.Value = new DateTime(currentYear, 12, 13);
            dateTime_hasta.Format = DateTimePickerFormat.Custom;
            dateTime_hasta.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTime_desde_ValueChanged(object sender, EventArgs e)
        {
            //dateTime_desde.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTime_hasta_ValueChanged(object sender, EventArgs e)
        {
            //dateTime_hasta.CustomFormat = "dd/MM/yyyy";
        }

        private void Crear_PaginationController()
        {
            controlador = new PaginationController();
            controlador.Agregar_GridView(dataGridView1);
            controlador.Agregar_Label_NrosDePagina(labelNrosDePagina);
        }

        private void Llenar_ComboBox_Item()
        {
            DAL da = new DAL();
            comboBox_item.DataSource = da.EjecutarComando("SELECT IDITEM,descripcion FROM Class.TipoItem order by iditem");
            comboBox_item.ValueMember = "IDITEM";
            comboBox_item.DisplayMember = "descripcion";
            comboBox_item.SelectedItem = null;
        }

        private void Llenar_ComboBox_Usuario()
        {
            DAL da = new DAL();
            comboBox_usuario.DataSource = da.EjecutarComando("SELECT IDUSUARIO,usuario FROM Class.usuario order by idusuario");
            comboBox_usuario.ValueMember = "IDUSUARIO";
            comboBox_usuario.DisplayMember = "usuario";
            comboBox_usuario.SelectedItem = null;
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            dateTime_desde.CustomFormat = "    ";
            dateTime_desde.Format = DateTimePickerFormat.Custom;
            dateTime_hasta.CustomFormat = "    ";
            dateTime_hasta.Format = DateTimePickerFormat.Custom;
            monto_desde.Value = 0;
            monto_hasta.Value = 0;
            factura_numero.Value = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                try
                {
                    //string numero_factura = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    DAL da = new DAL();
                    string cmd = "select idpublicacion from class.factura where numero=" + dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    DataTable seleccion = da.EjecutarComando(cmd);
                    DataRow seleccionada = seleccion.Rows[0];
                    Consulta_factura ver = new Consulta_factura();
                    ver.consultar(seleccionada[0].ToString().Trim());
                    ver.Show();
                    //this.Dispose();
                    //Actualizar grilla
                }
                catch
                {
                    MessageBox.Show("No se seleccionó registro para modificar.");
                }
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            string cadena = "select Factura.Numero,Total,Fecha,FormaPago from class.factura join class.detalle on factura.idfactura=detalle.idfactura ";
            cadena = cadena + " join class.Publicacion on Factura.IdPublicacion=Publicacion.IdPublicacion ";
            //cadena = cadena + " join class.usuario on Publicacion.IdUsuario=usuario.IdUsuario ";
            cadena = cadena + " where factura.fecha >='" + dateTime_desde.Value.ToString("dd/MM/yyyy").Trim() + "'";
            cadena = cadena + " and factura.fecha <='" + dateTime_hasta.Value.ToString("dd/MM/yyyy").Trim() + "'";
            if (monto_desde.Value > 0)
            {
                cadena = cadena + " and factura.total >=" + monto_desde.Value.ToString().Trim();
            }
            if (monto_hasta.Value > 0)
            {
                cadena = cadena + " and factura.total <=" + monto_hasta.Value.ToString().Trim();
            }
            if (factura_numero.Value > 0)
            {
                cadena = cadena + " and factura.numero =" + factura_numero.Value.ToString().Trim();
            }
            if (comboBox_item.SelectedItem != null)
            {
                cadena = cadena + " and detalle.iditem= " + comboBox_item.SelectedValue.ToString().Trim();
            }
            if (comboBox_usuario.SelectedItem != null)
            {
                cadena = cadena + " and publicacion.idusuario= " + comboBox_usuario.SelectedValue.ToString().Trim();
            }
            cadena = cadena + " group by Factura.Numero,Total,Fecha,FormaPago order by Numero ";

            DataTable facturas = new DataTable();
            facturas = Conexion.LeerTabla(cadena);
            if (facturas.Rows.Count <= 0)
            {
                MessageBox.Show("No existen publicaciones con esos filtros.");
                controlesHabilitados = false;
                return;
            }
            dataGridView1.DataSource = facturas;
            dataGridView1.ReadOnly = true;
            controlesHabilitados = true;
            controlador.Boton_Apretado_Buscar(facturas);
        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            if (controlesHabilitados == false)
                return;
            controlador.Boton_Apretado_Siguiente();
        }

        private void btn_anterior_Click_1(object sender, EventArgs e)
        {
            if (controlesHabilitados == false)
                return;
            controlador.Boton_Apretado_Anterior();
        }

        private void btn_ultima_pagina_Click_1(object sender, EventArgs e)
        {
            if (controlesHabilitados == false)
                return;
            controlador.Boton_Apretado_Ultima_Pagina();
        }

        private void btn_primera_pagina_Click(object sender, EventArgs e)
        {
            if (controlesHabilitados == false)
                return;
            controlador.Boton_Apretado_Primer_Pagina();
        }

        private void groupBox_filtro_Enter(object sender, EventArgs e)
        {

        }



    }
}
