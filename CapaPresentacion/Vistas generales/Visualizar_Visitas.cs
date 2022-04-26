using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Vistas_generales
{
    public partial class Visualizar_Visitas : Form
    {
        N_visitas objNegocio = new N_visitas();
        N_edificios objEdificioN = new N_edificios();
        List<E_edificios> listaEdificios;

        public Visualizar_Visitas()
        {
            InitializeComponent();
        }

        private void accionesTabla()
        {
            tablaVisitas.Columns[0].Visible = false;
            tablaVisitas.Columns[6].Visible = false;
            tablaVisitas.Columns[7].Visible = false;
            tablaVisitas.ClearSelection();
        }

        private void mostrarBuscarTabla()
        {
            if (comboEdificio.SelectedIndex > -1)
            {
                string id = comboEdificio.SelectedItem.ToString();

                tablaVisitas.DataSource = objNegocio.ListarVisitas(Convert.ToInt32(""+id[0]));
                if (tablaVisitas.Columns.Count > -1)
                {
                    accionesTabla();
                }
            }
        }

        private void CargarCombobox()
        {
            listaEdificios = objEdificioN.ListarEdificios("");
            for (int i = 0; i < listaEdificios.Count(); i++)
            {
                comboEdificio.Items.Add(listaEdificios[i].IdEdificio + "-" + listaEdificios[i].Nombre);
            }
        }

        private void Visualizar_Visitas_Load(object sender, EventArgs e)
        {
            CargarCombobox();            
        }

        private void comboBoxEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarBuscarTabla();
        }
    }
}
