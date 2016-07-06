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

namespace MercadoEnvio.Historial_Cliente
{
    public partial class Historial : Form
    {
        PaginationController controlador;
        bool controlesHabilitados;
        //PaginationController controlador2;
        //bool controlesHabilitados2;
        int idusuario;

        public Historial()
        {
            InitializeComponent();
            controlesHabilitados = false;
            //controlesHabilitados2 = false;
        }

        public void setear_usuario(string unUsuario)
        {
            DAL da = new DAL();
            DataTable tipop = da.EjecutarComando("SELECT idusuario FROM Class.usuario WHERE usuario='" + unUsuario + "'");
            DataRow row = tipop.Rows[0];
            idusuario = int.Parse(row[0].ToString().Trim());
        }

        private void btn_primera_pagina_Click(object sender, EventArgs e)
        {
            if (controlesHabilitados == false)
                return;
            controlador.Boton_Apretado_Primer_Pagina();
        }

        private void btn_anterior_Click(object sender, EventArgs e)
        {
            if (controlesHabilitados == false)
                return;
            controlador.Boton_Apretado_Anterior();
        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            if (controlesHabilitados == false)
                return;
            controlador.Boton_Apretado_Siguiente();
        }

        private void btn_ultima_pagina_Click(object sender, EventArgs e)
        {
            if (controlesHabilitados == false)
                return;
            controlador.Boton_Apretado_Ultima_Pagina();
        }
        /*
        private void button2_Click(object sender, EventArgs e)
        {
            if (controlesHabilitados2 == false)
                return;
            controlador2.Boton_Apretado_Ultima_Pagina();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (controlesHabilitados2 == false)
                return;
            controlador2.Boton_Apretado_Siguiente();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (controlesHabilitados2 == false)
                return;
            controlador2.Boton_Apretado_Anterior();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (controlesHabilitados2 == false)
                return;
            controlador2.Boton_Apretado_Primer_Pagina();
        }
        */
        private void Historial_Load(object sender, EventArgs e)
        {
            controlador = new PaginationController();
            controlador.Agregar_GridView(dataGridView1);
            controlador.Agregar_Label_NrosDePagina(labelNrosDePagina);
        }

        private void btn_compras_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = " ";
            Seleccionar.Visible = false;
            Titulo.Text = "Compras Realizadas";
            string cadena = "select idcompra,compra.IdPublicacion,Publicacion.Descripcion,compra.fecha,compra.cantidad,compra.Monto";
            cadena = cadena + " from class.compra join class.Publicacion on compra.IdPublicacion=Publicacion.IdPublicacion where compra.idusuario= " + idusuario.ToString().Trim();
            DataTable compras = new DataTable();
            compras = Conexion.LeerTabla(cadena);
            if (compras.Rows.Count > 0)
            {
                dataGridView1.DataSource = compras;
                dataGridView1.ReadOnly = true;
                controlesHabilitados = true;
                controlador.Boton_Apretado_Buscar(compras);
            }
            else
            {
                dataGridView1.DataSource = " ";
                MessageBox.Show("Usted no ha realizado ninguna compra.");
            }
        }

        private void btn_ofertas_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = " ";
            Seleccionar.Visible = false;
            Titulo.Text = "Ofertas Realizadas";
            string cadena = "select subasta.IdPublicacion,Publicacion.Descripcion,Monto Oferta,CONVERT(date,FechayHora) Fecha from class.Subasta join class.Publicacion on Subasta.IdPublicacion=Publicacion.IdPublicacion where subasta.idusuario= " + idusuario.ToString().Trim();
            DataTable ofertas = new DataTable();
            ofertas = Conexion.LeerTabla(cadena);
            if (ofertas.Rows.Count > 0)
            {
                dataGridView1.DataSource = ofertas;
                dataGridView1.ReadOnly = true;
                controlesHabilitados = true;
                controlador.Boton_Apretado_Buscar(ofertas);
            }
            else
            {
                dataGridView1.DataSource = " ";
                MessageBox.Show("Usted no ha participacipado en alguna subasta.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = " ";
            Seleccionar.Visible = false;
            Titulo.Text = "Compras no Calificadas";
            string cadena = "select idcompra,compra.IdPublicacion,Publicacion.Descripcion,compra.fecha,compra.cantidad,compra.Monto";
            cadena = cadena + " from class.compra join class.Publicacion on compra.IdPublicacion=Publicacion.IdPublicacion where compra.IdPublicacion not in (select idpublicacion from class.Calificacion)";
            cadena = cadena + " and compra.idusuario= " + idusuario.ToString().Trim();
            DataTable no_calificadas = new DataTable();
            no_calificadas = Conexion.LeerTabla(cadena);
            if (no_calificadas.Rows.Count > 0)
            {
                dataGridView1.DataSource = no_calificadas;
                dataGridView1.ReadOnly = true;
                controlesHabilitados = true;
                controlador.Boton_Apretado_Buscar(no_calificadas);
            }
            else
            {
                dataGridView1.DataSource = " ";
                MessageBox.Show("Usted no posee compras sin calificación.");
            }

        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            Seleccionar.Visible = false;
            dataGridView1.DataSource = " ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = " ";
            Seleccionar.Visible = false;
            Titulo.Text = "Resumen de calificaciones";
            string cadena = "select calificacion.IdPublicacion,Publicacion.Descripcion,usuario.Usuario Vendedor, compra.Monto,Calificacion";
            cadena = cadena + " from class.Calificacion join class.Publicacion on Calificacion.IdPublicacion=Publicacion.IdPublicacion join class.usuario on IdUsuarioPub=usuario.IdUsuario";
            cadena = cadena + " join class.Compra on Calificacion.IdCompra=compra.IdCompra";
            cadena = cadena + " where compra.idusuario= " + idusuario.ToString().Trim();
            DataTable calificaciones = new DataTable();
            calificaciones = Conexion.LeerTabla(cadena);
            if (calificaciones.Rows.Count > 0)
            {
                dataGridView1.DataSource = calificaciones;
                dataGridView1.ReadOnly = true;
                controlesHabilitados = true;
                controlador.Boton_Apretado_Buscar(calificaciones);
            }
            else
            {
                dataGridView1.DataSource = " ";
                MessageBox.Show("Usted no ha realizado calificaciones.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = " ";
            string cadena = "select Factura.Numero,Total,Fecha,FormaPago from class.factura join class.detalle on factura.idfactura=detalle.idfactura ";
            cadena = cadena + " join class.Publicacion on Factura.IdPublicacion=Publicacion.IdPublicacion ";
            cadena = cadena + " where publicacion.idusuario= " + idusuario.ToString().Trim();
            cadena = cadena + " group by Factura.Numero,Total,Fecha,FormaPago order by Numero ";

            DataTable facturas = new DataTable();
            facturas = Conexion.LeerTabla(cadena);
            if (facturas.Rows.Count <= 0)
            {
                MessageBox.Show("No existen facturas a su nombre.");
                controlesHabilitados = false;
                return;
            }
            Seleccionar.Visible = true;
            dataGridView1.DataSource = facturas;
            dataGridView1.ReadOnly = true;
            controlesHabilitados = true;
            controlador.Boton_Apretado_Buscar(facturas);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                try
                {
                    DAL da = new DAL();
                    string cmd = "select idpublicacion from class.factura where numero=" + dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    DataTable seleccion = da.EjecutarComando(cmd);
                    DataRow seleccionada = seleccion.Rows[0];
                    Consulta_factura ver = new Consulta_factura();
                    ver.consultar(seleccionada[0].ToString().Trim());
                    ver.Show();
                }
                catch
                {
                    MessageBox.Show("No se seleccionó registro para modificar.");
                }
            }
        }

    }
}
