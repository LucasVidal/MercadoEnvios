using MercadoEnvio.ALTA_Visibilidad;
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

namespace MercadoEnvio.Visibilidad
{
    public partial class Visibilidad : Form
    {
        public Visibilidad()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void listado()
        {
            button2.Visible = false;
            dataGridView1.ReadOnly = true;
            dataGridView2.Visible = false;
        }

        private void Visibilidad_Load(object sender, EventArgs e)
        {
            //Seleccionar.Visible = false;
            //Seleccionar2.Visible = false;
        }

        public void modificacion()
        {
            dataGridView2.Visible = false;
            dataGridView1.Visible = true;
            Seleccionar.Visible = true;
            Seleccionar.ReadOnly = true;
            Seleccionar2.Visible = false;
            Seleccionar2.ReadOnly = false;
        }

        public void baja()
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            Seleccionar2.Visible = true;
            Seleccionar2.ReadOnly = true;
            Seleccionar.Visible = false;
            Seleccionar.ReadOnly = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cadena = "select IdVisibilidad,Descripcion,Grado,Porcentaje*100 Porcentaje,Costo,TieneEnvio,CostoEnvio from Class.visibilidad";
            if (textBox1.Text.Trim().Length > 0)
            {
                cadena = cadena + " where descripcion like '%" + textBox1.Text.Trim() + "%'";
                if (id.Value > 0)
                {
                    cadena = cadena + " and idvisibilidad =" + id.Value.ToString().Trim() + "";
                }
            }
            else
            {
                if (id.Value > 0)
                {
                    cadena = cadena + " where idvisibilidad =" + id.Value.ToString().Trim() + "";
                }
            }
            DataTable rol = new DataTable();
            rol = Conexion.LeerTabla(cadena);
            if (rol.Rows.Count <= 0)
            {
                MessageBox.Show("No existen Visibilidad con esos filtros.");
                //this.button2_Click(sender, e);
            }
            else
            {
                if (dataGridView1.Visible)
                {
                    dataGridView1.DataSource = rol;
                    dataGridView1.ReadOnly = true;
                    Seleccionar.ReadOnly = false;
                }
                else
                {
                    dataGridView2.DataSource = rol;
                    dataGridView2.ReadOnly = true;
                    Seleccionar2.ReadOnly = false;
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = " ";
            dataGridView2.DataSource = " ";
            textBox1.Text = " ";
            Seleccionar.ReadOnly = true;
            Seleccionar2.ReadOnly = true;
            id.Value = 0;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                try
                {
                    string IdVisibilidad = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    string Descripcion = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    string Grado = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    string Porcentaje = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    string Costo = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    string Tieneenvio = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    string Costoenvio = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    Alta modi = new Alta();
                    modi.modificacion(IdVisibilidad, Descripcion, Grado, Porcentaje, Costo, Tieneenvio, Costoenvio);
                    modi.Show();
                    this.Dispose();
                }
                catch
                {
                    MessageBox.Show("No se seleccionó registro para modificar.");
                }
            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                try
                {
                    string IdVisibilidad = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                    string Descripcion = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                    string Grado = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                    string Porcentaje = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                    string Costo = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                    string Tieneenvio = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                    string Costoenvio = dataGridView2.CurrentRow.Cells[7].Value.ToString();
                    Alta baja = new Alta();
                    baja.baja(IdVisibilidad, Descripcion, Grado, Porcentaje, Costo, Tieneenvio, Costoenvio);
                    baja.Show();
                    this.Dispose();
                }
                catch
                {
                    MessageBox.Show("No se seleccionó registro para eliminar.");
                }
            }
        }

    }
}
