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

namespace MercadoEnvio.ComprarOfertar
{
    public partial class Buscar_Publicaciones : Form
    {
        int idusuario; //Usuario que está utilizando la aplicación
        PaginationController controlador;
        bool controlesHabilitados;

        public void BuscarPublicacion()
        {
            InitializeComponent();
            controlesHabilitados = false;
        }

        public void setear_usuario(string unUsuario)
        {
            DAL da = new DAL();
            DataTable tipop = da.EjecutarComando("SELECT idusuario FROM Class.usuario WHERE usuario='" + unUsuario + "'");
            DataRow row = tipop.Rows[0];
            idusuario = int.Parse(row[0].ToString().Trim());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Llenar_ComboBox_Rubro();
            Crear_PaginationController();
        }

        private void Crear_PaginationController()
        {
            controlador = new PaginationController();
            controlador.Agregar_GridView(dataGridView1);
            controlador.Agregar_Label_NrosDePagina(labelNrosDePagina);
        }

        private void Llenar_ComboBox_Rubro()
        {
            DAL da = new DAL();
            comboBox_rubro.DataSource = da.EjecutarComando("SELECT IDRUBRO,desc_Corta FROM Class.Rubro");
            comboBox_rubro.ValueMember = "IDRUBRO";
            comboBox_rubro.DisplayMember = "desc_Corta";
            comboBox_rubro.SelectedItem = null;
        }

        private void btn_limpiar_Click_1(object sender, EventArgs e)
        {
            textBox_descr.Text = "";
            dataGridView1.DataSource = " ";
        }

        private void textBox_descr_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                try
                {
                    string IdPublicacion = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    Ver_publicacion ver = new Ver_publicacion();
                    ver.setear_valores(idusuario, int.Parse(IdPublicacion));
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

        private void btn_buscar_Click_1(object sender, EventArgs e)
        {
            string cadena = "select row_number() OVER(ORDER BY visibilidad.grado,publicacion.idpublicacion) numeracion,idpublicacion,publicacion.descripcion,";
            cadena = cadena + " case when exists(select top 1 monto from class.subasta where idpublicacion=Publicacion.IdPublicacion) then (select top 1 monto from class.subasta where idpublicacion=Publicacion.IdPublicacion order by subasta.monto desc) else Publicacion.Precio end costo,tipopublicacion.descripcion Tipo";
            cadena = cadena + " from class.publicacion join class.TipoPublicacion on publicacion.idtipo=TipoPublicacion.idtipo";
            cadena = cadena + " join class.visibilidad on publicacion.idvisibilidad=visibilidad.idvisibilidad";
            cadena = cadena + " where idestado=2 and publicacion.idusuario<>" + idusuario.ToString().Trim();
            if (textBox_descr.Text.Trim().Length > 0)
            {
                cadena = cadena + " and Publicacion.descripcion like '%" + textBox_descr.Text.Trim() + "%'";
            }

            if (comboBox_rubro.SelectedItem != null)
            {
                cadena = cadena + " and publicacion.idrubro= " + comboBox_rubro.SelectedValue.ToString().Trim();
            }

            cadena = cadena + " order by visibilidad.grado,publicacion.idpublicacion";

            DataTable publicaciones = new DataTable();
            publicaciones = Conexion.LeerTabla(cadena);
            if (publicaciones.Rows.Count <= 0)
            {
                MessageBox.Show("No existen publicaciones con esos filtros.");
                controlesHabilitados = false;
                return;
            }
            dataGridView1.DataSource = publicaciones;
            dataGridView1.ReadOnly = true;
            controlesHabilitados = true;
            controlador.Boton_Apretado_Buscar(publicaciones);
        }

        private void btn_siguiente_Click_1(object sender, EventArgs e)
        {
            if (controlesHabilitados == false)
                return;
            controlador.Boton_Apretado_Siguiente();
        }

        private void btn_ultima_pagina_Click_1(object sender, EventArgs e)
        {
            if (controlesHabilitados == false)
                return;
            controlador.Boton_Apretado_Ultima_Pagina();
        }

        private void btn_anterior_Click_1(object sender, EventArgs e)
        {
            if (controlesHabilitados == false)
                return;
            controlador.Boton_Apretado_Anterior();
        }

        private void btn_primera_pagina_Click_1(object sender, EventArgs e)
        {
            if (controlesHabilitados == false)
                return;
            controlador.Boton_Apretado_Primer_Pagina();
        }

    }
}
