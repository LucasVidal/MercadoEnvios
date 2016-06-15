using MercadoEnvio.Base_De_Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MercadoEnvio.ALTA_Visibilidad
{
    public partial class Alta : Form
    {
        public Alta()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox3.Enabled = true;
            }
            else
            {
                textBox3.Text = " ";
                textBox3.Enabled = false;
            }
        }

        private void Alta_Load(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox3.Enabled = true;
            }
            else
            {
                textBox3.Enabled = false;
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        public bool validaCampoClave(TextBox campo)
        {
            if (campo.Text.Trim().Length > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim().Length == 0) //Es un alta
            {
                if (this.validaCampoClave(textBox1))
                {
                    MessageBox.Show("Todos los Campos son Obligatorios");
                    return;
                }
                if (this.validaCampoClave(textBox4))
                {
                    MessageBox.Show("Todos los Campos son Obligatorios");
                    return;
                }
                if (this.validaCampoClave(textBox7))
                {
                    MessageBox.Show("Todos los Campos son Obligatorios");
                    return;
                }
                if (this.validaCampoClave(textBox8))
                {
                    MessageBox.Show("Es Obligatorios seleccionar modelo");
                    return;
                }
                if (checkBox1.Checked)
                {
                    if (this.validaCampoClave(textBox3))
                    {
                        MessageBox.Show("Es Obligatorios cargar el costo de envío si posee.");
                        return;
                    }
                }
                DataTable visibilidadesexistentes = new DataTable();
                string cadena = "select 1 from Class.Visibilidad where descripcion='" + textBox4.Text.Trim() + "'";
                visibilidadesexistentes = Conexion.LeerTabla(cadena);
                if (visibilidadesexistentes.Rows.Count > 0)
                {
                    MessageBox.Show("Ya existe la visibilidad que intenta Ingresar");
                }
                else
                {

                    cadena = "begin tran; ";
                    if (checkBox1.Checked)
                    {
                        cadena = cadena + "insert into Class.Visibilidad(descripcion,grado,porcentaje,costo,tieneenvio,Costoenvio) ";
                        cadena = cadena + "values ('" + textBox4.Text.Trim() + "','" + textBox8.Text.Trim() + "'," + textBox1.Text.Trim().Replace(',', '.') + "," + textBox7.Text.Trim().Replace(',', '.') + ",'1'," + textBox3.Text.Trim().Replace(',', '.') + ");";
                    }
                    else
                    {
                        cadena = cadena + "insert into Class.Visibilidad(descripcion,grado,porcentaje,costo,tieneenvio) ";
                        cadena = cadena + "values ('" + textBox4.Text.Trim() + "','" + textBox8.Text.Trim() + "'," + textBox1.Text.Trim().Replace(',', '.') + "," + textBox7.Text.Trim().Replace(',', '.') + ",'0');";
                    }
                    cadena = cadena + " commit tran";
                    bool mexito = true;
                    try
                    {
                        Conexion.EjecutarComando(cadena);
                    }
                    catch (SqlException odbcEx)
                    {
                        MessageBox.Show("Error al Intentar Ingresar Visibilidad");
                        mexito = false;
                        this.Dispose();
                    }
                    if (mexito)
                    {
                        MessageBox.Show("Se ha ingresado la Visibilidad Exitosamente");
                    }
                    this.Dispose();
                }
            }
            else
            {
                //Modificacion o baja, por ahora solo modificacion
                string cadena = "";
                if (checkBox1.Checked)
                {
                    cadena = cadena + "update Class.visibilidad set descripcion='" + textBox4.Text.Trim() + "',Grado='" + textBox8.Text.Trim() + "',porcentaje= " + textBox1.Text.Trim().Replace(',', '.') + ",costo=" + textBox7.Text.Trim().Replace(',', '.') + ",Tieneenvio='1',costoenvio=" + textBox3.Text.Trim().Replace(',', '.');
                    cadena = cadena + " where idvisibilidad='" + textBox2.Text.Trim() + "'";
                }
                else
                {
                    cadena = cadena + "update Class.visibilidad set descripcion='" + textBox4.Text.Trim() + "',Grado='" + textBox8.Text.Trim() + "',porcentaje= " + textBox1.Text.Trim().Replace(',', '.') + ",costo=" + textBox7.Text.Trim().Replace(',', '.') + ",Tieneenvio='0',costoenvio=0";
                    cadena = cadena + " where idvisibilidad='" + textBox2.Text.Trim() + "'";
                }
                bool mexito = true;
                try
                {
                    Conexion.EjecutarComando(cadena);
                }
                catch (SqlException odbcEx)
                {
                    MessageBox.Show("Error al Intentar Actualizar la visibilidad");
                    mexito = false;
                    this.Dispose();
                }
                if (mexito)
                {
                    MessageBox.Show("Se ha actualizado la visibilidad Exitosamente");
                }
                this.Dispose();
            }
        }
        public void modificacion(string IdVisibilidad, string Descripcion, string Grado, string Porcentaje, string Costo, string Tieneenvio, string Costoenvio)
        {
            textBox2.Text = IdVisibilidad;
            textBox4.Text = Descripcion;
            textBox8.Text = Grado;
            textBox1.Text = Porcentaje;
            textBox2.ReadOnly = true;
            textBox7.Text = Costo;
            if (Convert.ToBoolean(Tieneenvio))
            {
                checkBox1.Checked = true;
                textBox3.Text = Costoenvio;
            }
            else
            {
                checkBox1.Checked = false;
                textBox3.Text = "";
            }
            button3.Visible = true;
            button2.Visible = false;

        }

        public void baja(string IdVisibilidad, string Descripcion, string Grado, string Porcentaje, string Costo, string Tieneenvio, string Costoenvio)
        {
            textBox2.Text = IdVisibilidad;
            textBox4.Text = Descripcion;
            textBox8.Text = Grado;
            textBox1.Text = Porcentaje;
            textBox2.ReadOnly = true;
            textBox7.Text = Costo;
            if (Convert.ToBoolean(Tieneenvio))
            {
                checkBox1.Checked = true;
                textBox3.Text = Costoenvio;
            }
            else
            {
                checkBox1.Checked = false;
                textBox3.Text = "";
            }
            textBox2.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox3.ReadOnly = true;
            checkBox1.Enabled = false;
            button2.Visible = true;
            button3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cadena = "";
            cadena = cadena + "DELETE FROM Class.visibilidad where idvisibilidad='" + textBox2.Text.Trim() + "'";
            bool mexito = true;
            try
            {
                Conexion.EjecutarComando(cadena);
            }
            catch (SqlException odbcEx)
            {
                MessageBox.Show("Error al Intentar Eliminar la visibilidad");
                mexito = false;
                this.Dispose();
            }
            if (mexito)
            {
                MessageBox.Show("Se ha Eliminado la visibilidad Exitosamente");
            }
            this.Dispose();
        }
    }
}
