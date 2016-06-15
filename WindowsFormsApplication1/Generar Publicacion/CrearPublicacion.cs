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

namespace MercadoEnvio.Generar_Publicación
{
    public partial class Publicacion : Form
    {
        private string regEx_validation;
        public Publicacion()
        {
            InitializeComponent();
            regEx_validation = @"^\d{1,18}([,]\d{1,2})?$"; // En el comboBox se debe poner COMA(,)... con el PUNTO(.) hace mal el insert
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
            Llenar_ComboBox_Rubro();
            Llenar_ComboBox_Estado();
            Llenar_ComboBox_Tipo();
            Llenar_ComboBox_Preguntas();
            Llenar_ComboBox_Visibilidades();
            Llenar_ComboBox_Envio();

            comboBox_tipo_publ.SelectedIndexChanged += new EventHandler(comboBox_tipo_publ_SelectedIndexChanged);
            comboBox_tipo_publ_SelectedIndexChanged(new Object(), new EventArgs());

        }

        private void comboBox_tipo_publ_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = DBService.Obtener_Registro_Con_String(comboBox_tipo_publ.Text, "descripcion", "Class.TipoPublicacion");
            string puedeEnviar = dt.Rows[0]["envio"].ToString();

            if (puedeEnviar.Equals("S"))
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
            comboBox_rubro.DataSource = DBService.SelectDataTable("desc_Corta", "Class.Rubro");
            comboBox_rubro.ValueMember = "descripcionCorta";
        }

        private void Llenar_ComboBox_Tipo()
        {
            //Class.TipoDePublicacion(id_TipoPublicacion, descripcion, envio ('S','N')) 
            //Porque en Class.TipoDePublicacion esta el campo ENVIO ?? segun consigna el ENVIO corresponde cuando se elige la VISIBILIDAD
            comboBox_tipo_publ.DataSource = DBService.SelectDataTable("descripcion", "Class.TipoPublicacion");
            comboBox_tipo_publ.ValueMember = "descripcion";
        }

        private void Llenar_ComboBox_Estado()
        {
            comboBox_estado.DataSource = DBService.SelectDataTable("descripcion", "Class.Estado");
            comboBox_estado.ValueMember = "descripcion";
        }

        private void Llenar_ComboBox_Preguntas()
        {
            comboBox_preguntas.Items.Add("NO");
            comboBox_preguntas.Items.Add("SI");
            comboBox_preguntas.SelectedIndex = 0;
        }

        private void Llenar_ComboBox_Visibilidades()
        {
            comboBox_visibilidades.DataSource = DBService.SelectDataTable("descripcion", "Class.Visibilidad");
            comboBox_visibilidades.ValueMember = "descripcion";
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
                MessageBox.Show("Hey! El formato del campo Precio Por Unidad es incorrecto, vuelve a intentarlo.");
                validacion_precio_unidad = false;
            }

            if (numericUpDown_stock.Value == 0)
            {
                MessageBox.Show("Hey! El campo Stock debe ser mayor a 0 !");
                validacion_stock = false;
            }

            if (comboBox_visibilidades.Text.Equals(String.Empty))
            {
                MessageBox.Show("Hey! El campo Visibilidad esta vacio !");
                validacion_visibilidad = false;
            }

            if (textBox_descr.Text.Equals(String.Empty))
            {
                MessageBox.Show("Hey! Debes completar el campo descripcion !");
                validacion_descripcion = false;
            }

            return (validacion_visibilidad && validacion_stock && validacion_precio_unidad && validacion_descripcion);
        }

        private string GetPreguntasParameter(string preguntaValue)
        {
            if (preguntaValue.Equals("SI"))
                return "S";
            if (preguntaValue.Equals("NO"))
                return "N";

            return null;
        }

        private string GetEnvioParameter(string envio)
        {
            if (envio.Equals("SI"))
                return "S";
            if (envio.Equals("NO"))
                return "N";

            return null;
        }

        private ItemPublicacion Obtener_ItemPublicacion()
        {
            ItemPublicacion item_publicacion = new ItemPublicacion();

            item_publicacion.user_id = SesionUsuario.GetUsuario().id;
            item_publicacion.descripcion = textBox_descr.Text;
            item_publicacion.estado_publ = comboBox_estado.Text;
            item_publicacion.rubro = comboBox_rubro.Text;
            item_publicacion.stock = numericUpDown_stock.Value;
            item_publicacion.tipo_publ = comboBox_tipo_publ.Text;
            item_publicacion.visibilidad = comboBox_visibilidades.Text;
            item_publicacion.permite_preguntas = GetPreguntasParameter(comboBox_preguntas.Text);
            item_publicacion.precio_por_unidad = Convert.ToDecimal(textBox_precio_unidad.Text);
            item_publicacion.permiteEnvio = GetEnvioParameter(comboBox_envio.Text);

            return item_publicacion;
        }

        private bool Averiguar_Publicaciones_gratis()
        {
            bool response = DBService.VerificarPublicacionesGratis(SesionUsuario.GetUsuario().id);

            return response;
        }
        #endregion

        private void Btn_Crear_Click(object sender, EventArgs e)
        {
            if (ValidarCampos() == false)
                return;

            if (Averiguar_Publicaciones_gratis())
                MessageBox.Show("Como tienes saldo de publicaciones, no se te cobraran gastos por publicacion");

            ItemPublicacion item_publicacion = Obtener_ItemPublicacion();
            bool response = DBService.Insertar_Publicacion(item_publicacion, Averiguar_Publicaciones_gratis());

            if (response)
                MessageBox.Show("Publicacion insertada con exito!");
            else
                MessageBox.Show("Hubo un error al insertar la publicacion");
        }
    }
}
