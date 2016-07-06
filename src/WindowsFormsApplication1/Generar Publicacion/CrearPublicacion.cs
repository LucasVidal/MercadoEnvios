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
using System.Text.RegularExpressions;
using MercadoEnvio.Utils.AccesoDatos;
using MercadoEnvio.Generar_Publicacion;

namespace MercadoEnvio.Generar_Publicación
{
    public partial class Publicacion : Form
    {
        private bool esmodi = false;
        private string regEx_validation;
        private DataRow publicacion_seleccionada;
        private int idusuario;
        public Publicacion()
        {
            InitializeComponent();
            regEx_validation = @"^\d{1,18}([,]\d{1,2})?$"; // En el comboBox se debe poner COMA(,)... con el PUNTO(.) hace mal el insert
        }

        public void setear_usuario(int unUsuario)
        {
            idusuario = unUsuario;
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            UtilsForms.Limpiar(groupBox1);
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DAL da = new DAL();
            Llenar_ComboBox_Rubro();
            if (!(esmodi))
            {
                Llenar_ComboBox_Estado_alta();
                Llenar_ComboBox_Tipo();
                Llenar_ComboBox_Visibilidades();
            }
            else
            {
                comboBox_rubro.SelectedValue = int.Parse(publicacion_seleccionada[6].ToString().Trim());
                Llenar_ComboBox_Estado_modi(publicacion_seleccionada[9].ToString().Trim());
                comboBox_estado.SelectedValue = int.Parse(publicacion_seleccionada[9].ToString().Trim());
                Llenar_ComboBox_Tipo(publicacion_seleccionada[10].ToString().Trim());
                //
                comboBox_visibilidades.DataSource = da.EjecutarComando("SELECT idvisibilidad,descripcion FROM Class.Visibilidad where idvisibilidad=" + publicacion_seleccionada[7].ToString().Trim());
                comboBox_visibilidades.ValueMember = "idvisibilidad";
                comboBox_visibilidades.DisplayMember = "descripcion";
                comboBox_visibilidades.Enabled = false;
            }
            Llenar_ComboBox_Envio();
            if (esmodi)
            {
                if (Convert.ToBoolean(publicacion_seleccionada[11]))
                {
                    comboBox_envio.SelectedValue = 2;
                }
                else
                {
                    comboBox_envio.SelectedValue = 1;
                }
                comboBox_envio.Enabled = false;
                textBox_descr.Text = publicacion_seleccionada[1].ToString().Trim();
                numericUpDown_stock.Value = int.Parse(publicacion_seleccionada[2].ToString().Trim());
                textBox_precio_unidad.Text = publicacion_seleccionada[5].ToString().Trim();
            }

            comboBox_tipo_publ.SelectedIndexChanged += new EventHandler(comboBox_tipo_publ_SelectedIndexChanged);
            comboBox_tipo_publ_SelectedIndexChanged(new Object(), new EventArgs());

        }

        public void modificacion(string IdPublicacion)
        {
            esmodi = true;
            DAL da = new DAL();
            DataTable publicacion = da.EjecutarComando("select * from class.Publicacion where Publicacion.idpublicacion =" + IdPublicacion.Trim());
            publicacion_seleccionada = publicacion.Rows[0];
        }

        private void comboBox_tipo_publ_SelectedIndexChanged(object sender, EventArgs e)
        {
            DAL da = new DAL();
            DataTable tipop = da.EjecutarComando("SELECT tieneenvio FROM Class.visibilidad WHERE idvisibilidad=" + comboBox_visibilidades.SelectedValue.ToString().Trim() + "");
            DataRow row = tipop.Rows[0];

            if (Convert.ToBoolean(row[0]) )
                comboBox_envio.Enabled = true;
            else
            {
                comboBox_envio.Enabled = false;
                comboBox_envio.SelectedIndex = 0; //pongo la opcion seleccionada en NO
            }
        }

        #region Load ComboBoxs
        private void Llenar_ComboBox_Rubro()
        {
            DAL da = new DAL();
            comboBox_rubro.DataSource = da.EjecutarComando("SELECT IDRUBRO,desc_Corta FROM Class.Rubro");
            comboBox_rubro.ValueMember = "IDRUBRO";
            comboBox_rubro.DisplayMember = "desc_Corta";
        }

        private void Llenar_ComboBox_Tipo(string untipo)
        {
            DAL da = new DAL();
            comboBox_tipo_publ.DataSource = da.EjecutarComando("SELECT idtipo,descripcion FROM Class.TipoPublicacion WHERE idtipo=" + untipo);
            comboBox_tipo_publ.ValueMember = "idtipo";
            comboBox_tipo_publ.DisplayMember = "descripcion";
            comboBox_tipo_publ.Enabled = false;
        }

        private void Llenar_ComboBox_Tipo()
        {
            DAL da = new DAL();
            comboBox_tipo_publ.DataSource = da.EjecutarComando("SELECT idtipo,descripcion FROM Class.TipoPublicacion");
            comboBox_tipo_publ.ValueMember = "idtipo";
            comboBox_tipo_publ.DisplayMember = "descripcion";
        }

        private void Llenar_ComboBox_Estado_modi(string estadoactual)
        {
            switch (estadoactual)
            {
                case "1":
                    {
                        Llenar_ComboBox_Estado_alta();
                        break;
                    }
                case "2":case "3":
                    {
                        DAL da = new DAL();
                        comboBox_estado.DataSource = da.EjecutarComando("SELECT idestado,descripcion FROM Class.Estado where idestado in (2,3,4)");
                        comboBox_estado.ValueMember = "idestado";
                        comboBox_estado.DisplayMember = "descripcion";
                        break;
                    }
                case "4":
                    {
                        DAL da = new DAL();
                        comboBox_estado.DataSource = da.EjecutarComando("SELECT idestado,descripcion FROM Class.Estado where idestado in (4)");
                        comboBox_estado.ValueMember = "idestado";
                        comboBox_estado.DisplayMember = "descripcion";
                        comboBox_estado.Enabled = false;
                        break;
                    }
            }
        }

        private void Llenar_ComboBox_Estado_alta()
        {
            DAL da = new DAL();
            comboBox_estado.DataSource = da.EjecutarComando("SELECT idestado,descripcion FROM Class.Estado where idestado in (1,2)");
            comboBox_estado.ValueMember = "idestado";
            comboBox_estado.DisplayMember = "descripcion";
        }


        private void Llenar_ComboBox_Visibilidades()
        {
            DAL da = new DAL();
            comboBox_visibilidades.DataSource = da.EjecutarComando("SELECT idvisibilidad,descripcion FROM Class.Visibilidad");
            comboBox_visibilidades.ValueMember = "idvisibilidad";
            comboBox_visibilidades.DisplayMember = "descripcion";
        }

        private void Llenar_ComboBox_Envio()
        {
            comboBox_envio.Items.Add("NO");
            comboBox_envio.Items.Add("SI");
            comboBox_envio.SelectedIndex = 0;
        }
        #endregion

        #region Local Methods
        private Boolean ValidarCampos()
        {
            Boolean validacion_precio_unidad = true;
            Boolean validacion_stock = true;
            Boolean validacion_visibilidad = true;
            Boolean validacion_descripcion = true;

            if (Regex.IsMatch(textBox_precio_unidad.Text, regEx_validation) == false)
            {
                MessageBox.Show("El formato del campo Precio Por Unidad es incorrecto, vuelve a intentarlo.");
                validacion_precio_unidad = false;
            }

            if (numericUpDown_stock.Value == 0)
            {
                MessageBox.Show("El campo Stock debe ser mayor a 0 !");
                validacion_stock = false;
            }

            if (comboBox_visibilidades.Text.Equals(String.Empty))
            {
                MessageBox.Show("El campo Visibilidad esta vacio !");
                validacion_visibilidad = false;
            }

            if (textBox_descr.Text.Equals(String.Empty))
            {
                MessageBox.Show("Debes completar el campo descripcion !");
                validacion_descripcion = false;
            }

            return (validacion_visibilidad && validacion_stock && validacion_precio_unidad && validacion_descripcion);
        }

        private string GetEnvioParameter(string envio)
        {
            if (envio.Equals("SI"))
                return "S";
            if (envio.Equals("NO"))
                return "N";

            return null;
        }

        private ItemPublicacion Obtener_ItemPublicacion(int idusuario)
        {
            ItemPublicacion item_publicacion = new ItemPublicacion();
            item_publicacion.descripcion = textBox_descr.Text;
            item_publicacion.estado_publ = comboBox_estado.SelectedValue.ToString().Trim();
            item_publicacion.rubro = comboBox_rubro.SelectedValue.ToString().Trim();
            item_publicacion.stock = numericUpDown_stock.Value;
            item_publicacion.precio_por_unidad = Convert.ToDecimal(textBox_precio_unidad.Text);
            if (!esmodi)
            {
                item_publicacion.user_id = idusuario;
                item_publicacion.tipo_publ = comboBox_tipo_publ.SelectedValue.ToString().Trim();
                item_publicacion.visibilidad = comboBox_visibilidades.SelectedValue.ToString().Trim();
                item_publicacion.permiteEnvio = GetEnvioParameter(comboBox_envio.Text);
            }

            return item_publicacion;
        }



        private bool Averiguar_Publicaciones_gratis()
        {
            bool response = DBService.VerificarPublicacionesGratis(idusuario);

            return response;
        }
        #endregion

        private void Btn_Crear_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;
            DAL da = new DAL();

            if (esmodi)
            {
                ItemPublicacion item_publicacion = Obtener_ItemPublicacion(idusuario);
                bool response = DBService.Modificar_Publicacion(int.Parse(publicacion_seleccionada[0].ToString().Trim()), item_publicacion, Averiguar_Publicaciones_gratis());

                if (response)
                {
                    MessageBox.Show("Publicacion modificada con exito!");

                    DataTable idpubli = da.EjecutarComando("SELECT 1 FROM Class.factura where idpublicacion="+publicacion_seleccionada[0].ToString().Trim());
                    if (idpubli.Rows.Count != 0)
                    {
                        Consulta_factura mostrar_factura = new Consulta_factura();
                        mostrar_factura.consultar(publicacion_seleccionada[0].ToString().Trim());
                        mostrar_factura.Show();
                    }
                }
                else
                    MessageBox.Show("Hubo un error al modificar la publicación");
            }
            else
            {
                if (Averiguar_Publicaciones_gratis())
                    MessageBox.Show("Como tienes saldo de publicaciones, no se te cobraran gastos por publicacion");

                ItemPublicacion item_publicacion = Obtener_ItemPublicacion(idusuario);
                bool response = DBService.Insertar_Publicacion(item_publicacion, Averiguar_Publicaciones_gratis());

                if (response)
                {
                    MessageBox.Show("Publicacion insertada con exito!");
                    DataTable idpubli = da.EjecutarComando("SELECT top 1 idpublicacion,idestado FROM Class.publicacion order by idpublicacion desc");
                    DataRow row = idpubli.Rows[0];
                    if (row[1].ToString().Trim() == "2")
                    {
                        Consulta_factura mostrar_factura = new Consulta_factura();
                        mostrar_factura.consultar(row[0].ToString().Trim());
                        mostrar_factura.Show();
                    }
                }
                else
                    MessageBox.Show("Hubo un error al insertar la publicacion");
            }
            this.Dispose();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox_tipo_publ_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox_estado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_visibilidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DAL da = new DAL();
                DataTable tipop = da.EjecutarComando("SELECT tieneenvio FROM Class.visibilidad WHERE idvisibilidad=" + comboBox_visibilidades.SelectedValue.ToString().Trim() + "");
                DataRow row = tipop.Rows[0];

                if (Convert.ToBoolean(row[0]))
                    comboBox_envio.Enabled = true;
                else
                {
                    comboBox_envio.Enabled = false;
                    comboBox_envio.SelectedIndex = 0; //pongo la opcion seleccionada en NO
                }
            }
            catch
            {
            }
        }

        private void textBox_descr_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_envio_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
