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
                envio.Enabled = true;
            }
            else
            {
                envio.Value = 0;
                envio.Enabled = false;
            }
        }

        private void Alta_Load(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                envio.Enabled = true;
            }
            else
            {
                envio.Enabled = false;
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = " ";
            textBox4.Text = "";
            porcentaje.Value = 0;
            ordenamiento.Value = 0;
            costo.Value = 0;
            envio.Value = 0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
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
            if (this.validaCampoClave(textBox4))
            {
                MessageBox.Show("Todos los Campos son Obligatorios");
                return;
            }
            if (ordenamiento.Value == 0)
            {
                MessageBox.Show("Es Obligatorios seleccionar Ordenamiento");
                return;
            }
            else
            {
                string cmd = "select 1 from class.visibilidad where grado=" + ordenamiento.Value.ToString().Trim().Replace(',', '.');
                DataTable nro_ordenamiento = new DataTable();
                nro_ordenamiento = Conexion.LeerTabla(cmd);
                if (nro_ordenamiento.Rows.Count != 0)
                {
                    MessageBox.Show("El ordenamiento seleccionado ya existe.");
                    return;
                }
            }
            if (checkBox1.Checked)
            {
                if (envio.Value == 0)
                {
                    MessageBox.Show("Es Obligatorios cargar el costo de envío si posee.");
                    return;
                }
            }
            if (textBox2.Text.Trim().Length == 0) //Es un alta
            {
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
                        //cadena = cadena + "values ('" + textBox4.Text.Trim() + "'," + ordenamiento.Value.ToString().Trim() + "," + textBox1.Text.Trim().Replace(',', '.') + "," + textBox7.Text.Trim().Replace(',', '.') + ",'1'," + textBox3.Text.Trim().Replace(',', '.') + ");";
                        cadena = cadena + "values ('" + textBox4.Text.Trim() + "'," + ordenamiento.Value.ToString().Trim().Replace(',', '.') + "," + (porcentaje.Value / 100).ToString().Trim().Replace(',', '.') + "," + costo.Value.ToString().Trim().Replace(',', '.') + ",'1'," + envio.Value.ToString().Trim().Replace(',', '.') + ");";
                    }
                    else
                    {
                        cadena = cadena + "insert into Class.Visibilidad(descripcion,grado,porcentaje,costo,tieneenvio,Costoenvio) ";
                        cadena = cadena + "values ('" + textBox4.Text.Trim().Replace(',', '.') + "'," + ordenamiento.Value.ToString().Trim().Replace(',', '.') + "," + (porcentaje.Value / 100).ToString().Trim().Replace(',', '.') + "," + costo.Value.ToString().Trim().Replace(',', '.') + ",'0','0');";
                    }
                    cadena = cadena + " commit tran";
                    bool mexito = true;
                    try
                    {
                        Conexion.EjecutarComando(cadena);
                    }
                    catch (SqlException)
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
                    cadena = cadena + "update Class.visibilidad set descripcion='" + textBox4.Text.Trim() + "',Grado=" + ordenamiento.Value.ToString().Trim().Replace(',', '.') + ",porcentaje= " + (porcentaje.Value / 100).ToString().Trim().Replace(',', '.') + ",costo=" + costo.Value.ToString().Trim().Replace(',', '.') + ",Tieneenvio='1',costoenvio=" + envio.Value.ToString().Trim().Replace(',', '.');
                    cadena = cadena + " where idvisibilidad='" + textBox2.Text.Trim() + "'";
                }
                else
                {
                    cadena = cadena + "update Class.visibilidad set descripcion='" + textBox4.Text.Trim() + "',Grado=" + ordenamiento.Value.ToString().Trim().Replace(',', '.') + ",porcentaje= " + (porcentaje.Value / 100).ToString().Trim().Replace(',', '.') + ",costo=" + costo.Value.ToString().Trim().Replace(',', '.') + ",Tieneenvio='0',costoenvio=0";
                    cadena = cadena + " where idvisibilidad='" + textBox2.Text.Trim() + "'";
                }
                bool mexito = true;
                try
                {
                    Conexion.EjecutarComando(cadena);
                }
                catch (SqlException)
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
            ordenamiento.Value = Convert.ToDecimal(Grado);
            porcentaje.Value = Convert.ToDecimal(Porcentaje);
            textBox2.ReadOnly = true;
            costo.Value = Convert.ToDecimal(Costo);

            if (Convert.ToBoolean(Tieneenvio))
            {
                checkBox1.Checked = true;
                envio.Value = Convert.ToDecimal(Costoenvio);
            }
            else
            {
                checkBox1.Checked = false;
                envio.Value = 0;
            }
            button3.Visible = true;
            button2.Visible = false;

        }

        public void baja(string IdVisibilidad, string Descripcion, string Grado, string Porcentaje, string Costo, string Tieneenvio, string Costoenvio)
        {
            textBox2.Text = IdVisibilidad;
            textBox4.Text = Descripcion;
            ordenamiento.Value = Convert.ToDecimal(Grado);
            porcentaje.Value = Convert.ToDecimal(Porcentaje);
            textBox2.ReadOnly = true;
            costo.Value = Convert.ToDecimal(Costo);
            if (Convert.ToBoolean(Tieneenvio))
            {
                checkBox1.Checked = true;
                costo.Value = Convert.ToDecimal(Costoenvio);
            }
            else
            {
                checkBox1.Checked = false;
                costo.Value = 0;
            }
            textBox2.ReadOnly = true;
            textBox4.ReadOnly = true;
            ordenamiento.Enabled = false;
            porcentaje.Enabled = false;
            textBox2.ReadOnly = true;
            costo.Enabled = false;
            costo.Enabled = false;
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
            catch (SqlException)
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
