using MercadoEnvio.Base_De_Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Utils
{
    public enum EditType { etNew, etEdit, etView };

    class UtilsForms
    {        
        public static void Limpiar(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control.GetType() == typeof(TextBox)) control.ResetText();
            }
        }

        public static void QueryAGrid(String query, DataGridView grid)
        {
            SqlConnection db = Conexion.conexion;

            SqlCommand cmd = new SqlCommand(query, db);
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);

            DataTable dtRecord = new DataTable();
            sqlDataAdap.Fill(dtRecord);
            grid.DataSource = dtRecord;
        }

        public static void AgregarSeleccionar(DataGridView grid)
        {
            DataGridViewButtonColumn colSeleccionar = new DataGridViewButtonColumn();
            colSeleccionar.HeaderText = "Seleccionar";
            grid.Columns.Add(colSeleccionar);
        }

        public static DialogResult MostrarAlerta(String mensaje)
        {
                string caption = "Atencion!";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(mensaje, caption, buttons);
                return result;
        }
    }
}
