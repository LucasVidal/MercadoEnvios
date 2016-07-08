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
using System.Text.RegularExpressions;
using WindowsFormsApplication1.Utils;
using MercadoEnvio.Base_De_Datos;

namespace MercadoEnvio.ComprarOfertar
{
    public partial class Ver_publicacion : Form
    {
        int idusuario;
        int publicacion;
        bool essubasta;
        int cantidad_maxima;
        int oferta_minima;

        public Ver_publicacion()
        {
            InitializeComponent();
        }

        public void setear_valores(int unUsuario, int unaPublicacion)
        {
            idusuario = unUsuario;
            publicacion = unaPublicacion;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Ver_publicacion_Load(object sender, EventArgs e)
        {

        }

        private void Ver_publicacion_Load_1(object sender, EventArgs e)
        {
            DAL da = new DAL();
            string cmd="select Publicacion.descripcion,stock,FechaVencimiento,precio,usuario,Publicacion.Envio,rubro.Desc_larga,TipoPublicacion.Descripcion,Visibilidad.CostoEnvio,Publicacion.idtipo,publicacion.idusuario ";
            cmd=cmd+"from class.publicacion join class.Usuario on Publicacion.IdUsuario=usuario.IdUsuario ";
            cmd=cmd+"join class.rubro on Publicacion.IdRubro=Rubro.IdRubro join class.TipoPublicacion on Publicacion.idtipo=TipoPublicacion.IdTipo ";
            cmd=cmd+"join class.Visibilidad on Publicacion.IdVisibilidad=Visibilidad.IdVisibilidad ";
            cmd=cmd+"where Publicacion.idpublicacion =" + publicacion.ToString().Trim();
            DataTable seleccion = da.EjecutarComando(cmd);
            DataRow publicacion_seleccionada = seleccion.Rows[0];
            essubasta = (publicacion_seleccionada[9].ToString().Trim() == "2");
            id.Text = publicacion.ToString().Trim();
            id.ReadOnly=true;
            usuario.Text = publicacion_seleccionada[4].ToString().Trim();
            usuario.ReadOnly = true;
            descripcion.Text = publicacion_seleccionada[0].ToString().Trim();
            descripcion.ReadOnly = true;
            rubro.Text = publicacion_seleccionada[6].ToString().Trim();
            rubro.ReadOnly = true;
            tipo.Text = publicacion_seleccionada[7].ToString().Trim();
            tipo.ReadOnly = true;
            stock.Text = publicacion_seleccionada[1].ToString().Trim();
            stock.ReadOnly = true;
            vencimiento.Text = publicacion_seleccionada[2].ToString().Trim();
            //vencimiento.Text = (DateTime.ParseExact(publicacion_seleccionada[2].ToString().Trim(), "dd--MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)).ToString().Trim();
            vencimiento.ReadOnly = true;
            if (Convert.ToBoolean(publicacion_seleccionada[5].ToString().Trim()))
            {
                checkBox1.Checked = true;
                costo_envio.Text = publicacion_seleccionada[8].ToString().Trim();
            }
            else
            {
                checkBox1.Checked = false;
            }
            checkBox1.Enabled = false;
            costo_envio.ReadOnly = true;
            if (essubasta)
            {
                label4.Text = "Oferta:";
                button3.Text = "Ofertar";
                cmd = "select top 1 monto from class.subasta ";
                cmd = cmd + "where idpublicacion =" + publicacion.ToString().Trim()+" order by monto desc";
                DataTable ultima_oferta = da.EjecutarComando(cmd);
                if (ultima_oferta.Rows.Count == 0)
                {
                    //precio.Text = publicacion_seleccionada[3].ToString().Trim();
                    precio.Value = Convert.ToDecimal(publicacion_seleccionada[3].ToString().Trim());
                }
                else
                {
                    DataRow precio_ultima_oferta = ultima_oferta.Rows[0];
                    //precio.Text = precio_ultima_oferta[0].ToString().Trim();
                    precio.Value = Convert.ToDecimal(precio_ultima_oferta[0].ToString().Trim());
                }
                precio.Minimum = Convert.ToInt32(precio.Value);
                Cantidad.Visible = false;
                numericUpDown_cantidad.Visible = false;
                //oferta_minima = Decimal.ToInt32(Convert.ToDecimal(precio.Text.Replace(',', '.')))/100;
                oferta_minima = Convert.ToInt32(precio.Value);
            }
            else
            {
                //precio.Text = publicacion_seleccionada[3].ToString().Trim();
                precio.Value = Convert.ToDecimal(publicacion_seleccionada[3].ToString().Trim());
                //precio.ReadOnly = true;
                precio.Enabled = false;
                precio.Minimum = Decimal.ToInt32(Convert.ToDecimal(publicacion_seleccionada[3].ToString().Trim()));
                numericUpDown_cantidad.Value = 1;
                numericUpDown_cantidad.Minimum = 1;
                cantidad_maxima = int.Parse(publicacion_seleccionada[1].ToString().Trim());
                numericUpDown_cantidad.Maximum = cantidad_maxima;
            }
            cmd = "select calificacion from class.calificaciones where idusuario=" + publicacion_seleccionada[10].ToString().Trim();
            DataTable calif = da.EjecutarComando(cmd);
            DataRow calificaciones = calif.Rows[0];
            calificacion.Text = calificaciones[0].ToString().Trim() ;
            calificacion.ReadOnly = true;
        }

        private Boolean ValidarCampos()
        {
            Boolean validacion = true;

            if (essubasta)
            {
                //int monto_oferta = Decimal.ToInt32(Convert.ToDecimal(precio.Text.Replace(',', '.')));
                int monto_oferta = Convert.ToInt32(precio.Value);
                if (monto_oferta == 0 || monto_oferta <= oferta_minima)
                {
                    MessageBox.Show("La oferta debe ser mayor a " + oferta_minima.ToString().Trim());
                    validacion = false;
                }
                return validacion;
            }
            else
            {
                if (numericUpDown_cantidad.Value == 0)
                {
                    MessageBox.Show("La cantidad a comprar debe ser mayor a 0.");
                    validacion = false;
                }
                return validacion;
            }
        }


        private Boolean PuedeComprar()
        {
            Boolean validacion = true;
            string cadena = "select count(*) sin_calificar from class.Compra ";
            cadena = cadena + " where IdCompra not in (select IdCompra from class.Calificacion) ";
            cadena = cadena + " and compra.idusuario = " + idusuario.ToString().Trim();
            DataTable compras_no_calificadas = Conexion.LeerTabla(cadena);
            DataRow cantidad = compras_no_calificadas.Rows[0];
            if (compras_no_calificadas.Rows.Count > 0)
            {
                if (int.Parse(cantidad[0].ToString().Trim())>3)
                {
                    validacion = false;
                    MessageBox.Show("No es posible realizar la compra por poseer mas de 3 compras sin calificar.");
                }
            }
            return validacion;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            if (!PuedeComprar())
                return;

            DAL da = new DAL();
            if (essubasta)
            {
                try
                {
                    bool response = DBService.Nueva_oferta(publicacion, idusuario, Convert.ToInt32(precio.Value));

                    if (response)
                    {
                        MessageBox.Show("Oferta ingresada con exito!");
                    }
                    else
                        MessageBox.Show("Hubo un error al ingresar la oferta");
                }
                catch
                {
                    MessageBox.Show("Hubo un error al ingresar la oferta");
                }
            }
            else
            {
                //bool response = DBService.Insertar_Compra(publicacion, idusuario, Decimal.ToInt32(Convert.ToDecimal(precio.Text)), Decimal.ToInt32(numericUpDown_cantidad.Value));
                bool response = DBService.Insertar_Compra(publicacion, idusuario, Convert.ToInt32(precio.Value), Decimal.ToInt32(numericUpDown_cantidad.Value));
                try
                {
                    if (response)
                    {
                        MessageBox.Show("Se ha realizado la compra con éxito");
                        Consulta_factura mostrar_factura = new Consulta_factura();
                        mostrar_factura.consultar(publicacion.ToString().Trim());
                        mostrar_factura.Show();
                    }
                    else
                        MessageBox.Show("Hubo un error al realizar la compra");
                }
                catch
                {
                    MessageBox.Show("Hubo un error al realizar la compra");
                }
            }
            this.Dispose();
        }

    }
}
