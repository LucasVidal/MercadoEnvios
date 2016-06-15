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

namespace MercadoEnvio.Abm_Rol
{
    public partial class Rol : Form
    {
        public Rol()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cadena = "select idrol,nombre,estahabilitado from Class.rol";
            if (textBox1.Text.Trim().Length > 0)
            {
                cadena = cadena + " where nombre like '%" + textBox1.Text.Trim() + "%'";
            }
            DataTable rol = new DataTable();
            rol = Conexion.LeerTabla(cadena);
            if (rol.Rows.Count <= 0)
            {
                MessageBox.Show("No existen perfil con ese nombre.");
                //this.button2_Click(sender, e);
            }
            else
            {
                foreach (DataRow fila in rol.Rows)
                {
                    textBox1.Text = fila["nombre"].ToString().Trim();
                    textBox2.Text=fila["idrol"].ToString().Trim();
                    if ((bool)fila["estahabilitado"])
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }
                }
                cadena = "select tienepermisos,funcionalidad.idfuncionalidad,funcionalidad.nombre ";
                cadena = cadena + "from Class.rol left join Class.RolFuncionalidad on rol.IdRol=RolFuncionalidad.IdRol ";
                cadena = cadena + "left join Class.Funcionalidad on RolFuncionalidad.IdFuncionalidad=funcionalidad.IdFuncionalidad ";
                cadena = cadena + "where rol.idrol='" + textBox2.Text.Trim() + "'";
                DataTable funcionalidades = new DataTable();
                funcionalidades = Conexion.LeerTabla(cadena);
                if (funcionalidades.Rows.Count > 0)
                {
                    dataGridView1.DataSource = funcionalidades;
                }
            }
        }

        private void Rol_Load(object sender, EventArgs e)
        {
            string cadena = "select idfuncionalidad,nombre from Class.Funcionalidad";
            DataTable funcionalidades = new DataTable();
            funcionalidades = Conexion.LeerTabla(cadena);
            if (funcionalidades.Rows.Count > 0)
            {
                dataGridView1.DataSource = funcionalidades;
            }
            textBox2.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        public void listado()
        {
            button4.Visible = false;
            checkBox1.Enabled = false;
            button2.Visible = false;
            dataGridView1.ReadOnly = true;
            seleccionar.ReadOnly = true;
        }

        public void alta()
        {
            button4.Visible = true;
            button2.Visible = false;
            button1.Visible = false;
            dataGridView1.ReadOnly = false;
            seleccionar.ReadOnly = false;
            checkBox1.Enabled = true;
        }
        public void modificacion()
        {
            button4.Visible = false;
            button1.Visible = true;
            checkBox1.Enabled = true;
            dataGridView1.ReadOnly = false;
            seleccionar.ReadOnly = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Es obligatorio cargar el nombre para dar el alta");
            }
            else
            {
                string valid = "select idrol,nombre,estahabilitado from Class.rol";
                valid = valid + " where nombre = '" + textBox1.Text.Trim() + "'";
                DataTable validacion = new DataTable();
                validacion = Conexion.LeerTabla(valid);
                if (validacion.Rows.Count > 0)
                {
                    MessageBox.Show("Ya existe un perfil con ese nombre.");
                }
                else
                {
                    DataTable idmaximo = new DataTable();
                    string cadena2 = "select max(idrol) maximo from Class.rol";
                    idmaximo = Conexion.LeerTabla(cadena2);
                    int idrolmaximo = 0;
                    foreach (DataRow fila in idmaximo.Rows)
                    {
                        idrolmaximo = int.Parse(fila["maximo"].ToString()) + 1;
                    }
                    string cadena = "begin tran; ";
                    if (checkBox1.Checked)
                    {
                        cadena = cadena + " insert into Class.rol (nombre, estahabilitado) values('" + textBox1.Text.Trim() + "','1'); ";
                    }
                    else
                    {
                        cadena = cadena + " insert into Class.rol (nombre, estahabilitado) values('" + textBox1.Text.Trim() + "','0'); ";
                    }
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (null != row.Cells[1] && null != row.Cells[1].Value)
                        {
                            var oCell = row.Cells[0] as DataGridViewCheckBoxCell;
                            bool bChecked = (null != oCell && null != oCell.Value && true == (bool)oCell.Value);
                            if (bChecked)//(String.IsNullOrEmpty(row.Cells[0].Value))
                            {
                                cadena = cadena + " insert into Class.RolFuncionalidad (idrol,idfuncionalidad,tienepermisos) ";
                                cadena = cadena + " values ('" + idrolmaximo + "','" + row.Cells[1].Value.ToString().Trim() + "','1');";
                            }
                            else
                            {
                                cadena = cadena + " insert into Class.RolFuncionalidad (idrol,idfuncionalidad,tienepermisos) ";
                                cadena = cadena + " values ('" + idrolmaximo + "','" + row.Cells[1].Value.ToString().Trim() + "','0');";
                            }
                        }
                    }

                    cadena = cadena + " commit tran";
                    bool mexito = true;
                    try
                    {
                        Conexion.EjecutarComando(cadena);
                    }
                    catch (SqlException odbcEx)
                    {
                        MessageBox.Show("Error al Intentar insertar Rol");
                        mexito = false;
                        this.Dispose();
                    }
                    if (mexito)
                    {
                        MessageBox.Show("Se ha ingresado el Rol Exitosamente");
                    }
                    this.Dispose();
                }
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Seleccione el Rol a Modificar");
            }
            else
            {
                string cadena = "begin tran; delete from Class.RolFuncionalidad where idrol='" + textBox2.Text.Trim() + "';";
                if (checkBox1.Checked)
                {
                    cadena = cadena + " update Class.rol set nombre='" + textBox1.Text.Trim() + "',estahabilitado='1' ";
                }
                else
                {
                    cadena = cadena + " update Class.rol set nombre='" + textBox1.Text.Trim() + "',estahabilitado='0' ";
                }
                cadena = cadena + " where idrol='" + textBox2.Text.Trim() + "';";
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (null != row.Cells[1] && null != row.Cells[1].Value)
                    {
                        var oCell = row.Cells[0] as DataGridViewCheckBoxCell;
                        bool bChecked = (null != oCell && null != oCell.Value && true == (bool)oCell.Value);
                        if (bChecked)//(String.IsNullOrEmpty(row.Cells[0].Value))
                        {
                            cadena = cadena + " insert into Class.RolFuncionalidad (idrol,idfuncionalidad,tienepermisos) ";
                            cadena = cadena + " values ('" + textBox2.Text.Trim() + "','" + row.Cells[1].Value.ToString().Trim() + "','1');";
                        }
                        else
                        {
                            cadena = cadena + " insert into Class.RolFuncionalidad (idrol,idfuncionalidad,tienepermisos) ";
                            cadena = cadena + " values ('" + textBox2.Text.Trim() + "','" + row.Cells[1].Value.ToString().Trim() + "','0');";
                        }
                    }
                }

                cadena = cadena + " commit tran";
                bool mexito = true;
                try
                {
                    Conexion.EjecutarComando(cadena);
                }
                catch (SqlException odbcEx)
                {
                    MessageBox.Show("Error al Intentar Actualizar el Rol");
                    mexito = false;
                    this.Dispose();
                }
                if (mexito)
                {
                    MessageBox.Show("Se ha Actualizado el Rol Exitosamente");
                }
                this.Dispose();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
