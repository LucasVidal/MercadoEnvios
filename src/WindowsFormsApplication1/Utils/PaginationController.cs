using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace WindowsFormsApplication1.Utils
{
    class PaginationController
    {
        private DataGridView dataGridView;
        private Label labelNrosDePagina;

        private DataTable tablaTemporal;
        private int totalPaginas;
        private int totalPublicaciones;
        private int publicacionesPorPagina = 10;
        private int paginaActual;
        private int ini;
        private int fin;

        public void Agregar_GridView(DataGridView dg)
        {
            dataGridView = dg;
        }

        public void Agregar_Label_NrosDePagina(Label labelNumPags)
        {
            labelNrosDePagina = labelNumPags;
        }

        public void Boton_Apretado_Buscar(DataTable busquedaTemporal)
        {
            int cantFilas = busquedaTemporal.Rows.Count;

            if (cantFilas == 0)
            {
                MessageBox.Show("No hay resultados");
                return;
            }
            else
            {
                tablaTemporal = busquedaTemporal;
                calcularPaginas();

                ini = 0;
                if (totalPublicaciones > 9)
                    fin = 9;
                else
                    fin = totalPublicaciones;

                //calcularPaginas();
                dataGridView.DataSource = paginarDataGridView(ini, fin);
                mostrarNrosPaginas(ini);
            }
        }

        public void Boton_Apretado_Siguiente()
        {
            if (sePuedeAvanzarPaginas())
            {
                ini += publicacionesPorPagina;

                if ((fin + publicacionesPorPagina) < totalPublicaciones)
                    fin += publicacionesPorPagina;
                else
                    fin = totalPublicaciones;

                dataGridView.DataSource = paginarDataGridView(ini, fin);
                mostrarNrosPaginas(ini);
            }
        }

        public void Boton_Apretado_Anterior()
        {
            if (sePuedeRetrocederPaginas())
                ini -= publicacionesPorPagina;

            if (fin != totalPublicaciones)
                fin -= publicacionesPorPagina;
            else
                fin = ini + 9;

            dataGridView.DataSource = paginarDataGridView(ini, fin);
            mostrarNrosPaginas(ini);
        }

        public void Boton_Apretado_Ultima_Pagina()
        {
            if (sePuedeAvanzarPaginas())
            {
                ini = (totalPaginas - 1) * publicacionesPorPagina;
                fin = totalPublicaciones;
                dataGridView.DataSource = paginarDataGridView(ini, fin);
                mostrarNrosPaginas(ini);
            }
        }

        public void Boton_Apretado_Primer_Pagina()
        {
            if (sePuedeRetrocederPaginas())
            {
                ini = 0;
                fin = 9;
                dataGridView.DataSource = paginarDataGridView(ini, fin);
                mostrarNrosPaginas(ini);
            }
        }

        private void calcularPaginas()
        {
            totalPublicaciones = tablaTemporal.Rows.Count - 1;
            totalPaginas = totalPublicaciones / publicacionesPorPagina;
            if ((totalPublicaciones / publicacionesPorPagina) > 0)
            {
                totalPaginas += 1;
            }
        }

        private DataTable paginarDataGridView(int ini, int fin)
        {
            DataTable publicacionesDeUnaPagina = new DataTable();
            publicacionesDeUnaPagina = tablaTemporal.Clone();
            for (int i = ini; i <= fin; i++)
            {
                publicacionesDeUnaPagina.ImportRow(tablaTemporal.Rows[i]);
            }
            return publicacionesDeUnaPagina;
        }

        private void mostrarNrosPaginas(int ini)
        {
            paginaActual = (ini / publicacionesPorPagina) + 1;
            labelNrosDePagina.Text = "Pagina " + paginaActual + "/" + totalPaginas;
        }

        private bool sePuedeRetrocederPaginas()
        {
            if (VerificarSiSeBusco() == false)
                return false;
            else
            {
                if (paginaActual == 1)
                {
                    MessageBox.Show("Ya estas en la 1º pagina");
                    return false;
                }
                else
                    return true;
            }
        }

        private bool sePuedeAvanzarPaginas()
        {
            if (VerificarSiSeBusco() == false)
                return false;
            else
            {
                if (paginaActual == totalPaginas)
                {
                    MessageBox.Show("Ya estas en la ultima pagina");
                    return false;
                }
                else
                    return true;
            }
        }

        private bool VerificarSiSeBusco()
        {
            if (totalPaginas == 0)
            {
                MessageBox.Show("Aun no buscaste nada");
                return false;
            }
            else
                return true;
        }
    }
}
