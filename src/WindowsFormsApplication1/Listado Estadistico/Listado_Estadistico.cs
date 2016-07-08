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

namespace MercadoEnvio.Listado_Estadistico
{
    public partial class Listado_Estadistico : Form
    {
        List<string> años = new List<string> { "2015", "2016", "2017", "2018", "2019", "2020" };
        List<Trimestre> trimestres = new List<Trimestre>();
        List<Listados> listados = new List<Listados>();

        public Listado_Estadistico()
        {
            InitializeComponent();
            CargarCombos();
        }

        private void Listado_Estadistico_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbAño.SelectedValue.ToString()) || string.IsNullOrEmpty(cmbTrimestre.SelectedValue.ToString()))
            {
                MessageBox.Show("No hay filtros seleccionados");
                return;
            }
            if (string.IsNullOrEmpty(cmbListados.SelectedValue.ToString()))
            {
                MessageBox.Show("No hay listados seleccionados");
                return;
            }
            string sql = "";
            switch (cmbListados.SelectedValue.ToString())
            {
                case "1":// "Vendedores con Productos No Vendidos":
                    sql = "select top 5 Publicacion.IdUsuario,usuario.Usuario,isnull(empresa.RazonSocial,persona.nombre+' '+persona.Apellido) Nombre,count(*) 'Publicaciones No Vendidas' ";
                    sql = sql + " from class.Publicacion join class.usuario on publicacion.idusuario=usuario.idusuario left join class.persona on publicacion.idusuario=persona.idusuario left join class.empresa on publicacion.idusuario=empresa.idusuario ";
                    sql = sql + " where IdPublicacion not in (select IdPublicacion from class.Compra) ";
                    if (cmbVisibilidad.SelectedValue != null)
                    {
                        sql = sql + " and idVisibilidad=" + cmbVisibilidad.SelectedValue.ToString();
                    }
                    sql = sql + " and year(fechainicio)= " + cmbAño.SelectedValue.ToString() + " and ";
                    if (cmbTrimestre.Text.Equals("1er Trimestre"))
                        sql = sql + " month(fechainicio)<=3";
                    if (cmbTrimestre.Text.Equals("2do Trimestre"))
                        sql = sql + " month(fechainicio)>3 and month(fechainicio)<=6";
                    if (cmbTrimestre.Text.Equals("3er Trimestre"))
                        sql = sql + " month(fechainicio)>6 and month(fechainicio)<=9";
                    if (cmbTrimestre.Text.Equals("4to Trimestre"))
                        sql = sql + " month(fechainicio)>9 and month(fechainicio)<=12";
                    sql = sql + " group by Publicacion.IdUsuario,usuario.usuario,empresa.RazonSocial,persona.nombre,persona.Apellido order by 'Publicaciones No Vendidas' desc";
                    break;
                case "2":// "Clientes con Productos Comprados":
                    sql = "select top 5 compra.idusuario,usuario.Usuario,isnull(empresa.RazonSocial,persona.nombre+' '+persona.Apellido) Nombre,sum(cantidad) 'Productos Comprados' ";
                    sql=sql+"from class.compra join class.Publicacion on compra.idpublicacion=publicacion.idpublicacion ";
                    sql = sql + " join class.usuario on publicacion.idusuario=usuario.idusuario left join class.persona on publicacion.idusuario=persona.idusuario left join class.empresa on publicacion.idusuario=empresa.idusuario where ";
                    if (cmbRubro.SelectedValue == null)
                    {
                        sql = sql + " year(fechainicio)= " + cmbAño.SelectedValue.ToString() + " and ";
                    }
                    else
                    {
                        sql = sql + " idrubro=" + cmbRubro.SelectedValue.ToString() + " and year(fechainicio)= " + cmbAño.SelectedValue.ToString() + " and ";
                    }
                    if (cmbTrimestre.Text.Equals("1er Trimestre"))
                        sql = sql + " month(fechainicio)<=3";
                    if (cmbTrimestre.Text.Equals("2do Trimestre"))
                        sql = sql + " month(fechainicio)>3 and month(fechainicio)<=6";
                    if (cmbTrimestre.Text.Equals("3er Trimestre"))
                        sql = sql + " month(fechainicio)>6 and month(fechainicio)<=9";
                    if (cmbTrimestre.Text.Equals("4to Trimestre"))
                        sql = sql + " month(fechainicio)>9 and month(fechainicio)<=12";
                    sql = sql + " group by compra.idusuario,usuario.usuario,empresa.RazonSocial,persona.nombre,persona.Apellido order by 'Productos Comprados' desc ";
                    break;
                case "3":// "Vendedores con Facturas":
                    sql = "select top 5 publicacion.idusuario,usuario.Usuario,isnull(empresa.RazonSocial,persona.nombre+' '+persona.Apellido) Nombre,count(factura.idpublicacion) as 'Cantidad de Facturas'  from class.Publicacion join class.Factura on publicacion.IdPublicacion=factura.IdPublicacion  ";
                    sql = sql + " join class.usuario on publicacion.idusuario=usuario.idusuario left join class.persona on publicacion.idusuario=persona.idusuario left join class.empresa on publicacion.idusuario=empresa.idusuario ";
                    sql = sql + " where year(fechainicio)= " + cmbAño.SelectedValue.ToString() + " and ";
                    if (cmbTrimestre.Text.Equals("1er Trimestre"))
                        sql = sql + " month(fechainicio)<=3";
                    if (cmbTrimestre.Text.Equals("2do Trimestre"))
                        sql = sql + " month(fechainicio)>3 and month(fechainicio)<=6";
                    if (cmbTrimestre.Text.Equals("3er Trimestre"))
                        sql = sql + " month(fechainicio)>6 and month(fechainicio)<=9";
                    if (cmbTrimestre.Text.Equals("4to Trimestre"))
                        sql = sql + " month(fechainicio)>9 and month(fechainicio)<=12";
                    sql = sql + " group by publicacion.IdUsuario,usuario.usuario,empresa.RazonSocial,persona.nombre,persona.Apellido order by 'Cantidad de Facturas'  desc ";
                    break;
                case "4"://"Vendedores con Monto Facturado":
                    sql = "select top 5 publicacion.idusuario,usuario.Usuario,isnull(empresa.RazonSocial,persona.nombre+' '+persona.Apellido) Nombre,sum(total) 'Monto Facturadas' ";
                    sql = sql + "from class.factura join class.Publicacion on publicacion.idpublicacion=factura.idpublicacion join class.usuario on publicacion.idusuario=usuario.idusuario ";
                    sql = sql + "left join class.persona on publicacion.idusuario=persona.idusuario left join class.empresa on publicacion.idusuario=empresa.idusuario  ";
                    sql = sql + " where year(fechainicio)= " + cmbAño.SelectedValue.ToString() + " and";
                    if (cmbTrimestre.Text.Equals("1er Trimestre"))
                        sql = sql + " month(fechainicio)<=3";
                    if (cmbTrimestre.Text.Equals("2do Trimestre"))
                        sql = sql + " month(fechainicio)>3 and month(fechainicio)<=6";
                    if (cmbTrimestre.Text.Equals("3er Trimestre"))
                        sql = sql + " month(fechainicio)>6 and month(fechainicio)<=9";
                    if (cmbTrimestre.Text.Equals("4to Trimestre"))
                        sql = sql + " month(fechainicio)>9 and month(fechainicio)<=12";
                    sql = sql + " group by publicacion.IdUsuario,usuario.usuario,empresa.RazonSocial,persona.nombre,persona.Apellido order by 'Monto Facturadas'  desc ";
                    break;
            }

            DataTable listado = new DataTable();
            listado = Conexion.LeerTabla(sql);
            if (listado.Rows.Count <= 0)
            {
                dataGridView1.DataSource = "";
                MessageBox.Show("No existen listados con esos filtros.");
                return;
            }
            dataGridView1.DataSource = listado;
            dataGridView1.ReadOnly = true;
        }

        private void CargarCombos()
        {

            cmbAño.DataSource = años;
            cmbTrimestre.DataSource = new Trimestre().GetTrimestres();
            cmbTrimestre.ValueMember = "ID";
            cmbTrimestre.DisplayMember = "Descripcion";
            cmbListados.DataSource = new Listados().GetListado();
            cmbListados.ValueMember = "ID";
            cmbListados.DisplayMember = "Descripcion";
            Llenar_ComboBox_Visibilidades();
            Llenar_ComboBox_Rubro();
            cmbRubro.Text = "Seleccionar Rubro";
            cmbListados_SelectedIndexChanged(null, null);
        }

        private void Llenar_ComboBox_Visibilidades()
        {
            DAL da = new DAL();
            cmbVisibilidad.DataSource = da.EjecutarComando("SELECT idvisibilidad,descripcion FROM Class.Visibilidad");
            cmbVisibilidad.ValueMember = "idvisibilidad";
            cmbVisibilidad.DisplayMember = "descripcion";
            cmbVisibilidad.SelectedItem = null;
        }

        private void Llenar_ComboBox_Rubro()
        {
            DAL da = new DAL();
            cmbRubro.DataSource = da.EjecutarComando("SELECT IDRUBRO,desc_Corta FROM Class.Rubro");
            cmbRubro.ValueMember = "IDRUBRO";
            cmbRubro.DisplayMember = "desc_Corta";
            cmbRubro.SelectedItem = null;
        }

        private void Llenar_ComboBox_Rol()
        {
            DAL da = new DAL();
            cmbRubro.DataSource = da.EjecutarComando("SELECT IDROL,Nombre FROM Class.Rol");
            cmbRubro.ValueMember = "IDROL";
            cmbRubro.DisplayMember = "Nombre";
            cmbRubro.SelectedItem = null;
        }

        private void cmbListados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbListados.SelectedValue.ToString() == "2") //Filtro rubro
            {
                cmbRubro.Visible = true;
                lblRubro.Visible = true;
            }
            else
            {
                cmbRubro.Visible = false;
                lblRubro.Visible = false;
            }
            if (cmbListados.SelectedValue.ToString() == "1") //Filtro visibilidad
            {
                cmbVisibilidad.Visible = true;
                lblVisibilidad.Visible = true;
            }
            else
            {
                cmbVisibilidad.Visible = false;
                lblVisibilidad.Visible = false;
            }
        }
    }

    class Listados
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public Listados()
        {

        }

        public List<Listados> GetListado()
        {
            List<string> lista = new List<string> { "Vendedores con Productos No Vendidos", "Clientes con Productos Comprados ",
                                                "Vendedores con Facturas","Vendedores con Monto Facturado"};
            List<Listados> listados = new List<Listados>();
            Listados list;
            for (int i = 1; i <= lista.Count; i++)
            {
                list = new Listados();
                list.ID = i;
                list.Descripcion = lista[i - 1];
                listados.Add(list);
            }
            return listados;
        }

    }


    class Trimestre
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public Trimestre()
        {

        }

        public List<Trimestre> GetTrimestres()
        {
            List<string> lista = new List<string> { "1er Trimestre", "2do Trimestre", "3er Trimestre", "4to Trimestre" };
            List<Trimestre> listados = new List<Trimestre>();
            Trimestre list;
            for (int i = 1; i <= lista.Count; i++)
            {
                list = new Trimestre();
                list.ID = i;
                list.Descripcion = lista[i - 1];
                listados.Add(list);
            }
            return listados;
        }

    }
}
