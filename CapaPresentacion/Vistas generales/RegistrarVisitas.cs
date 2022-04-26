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
    public partial class RegistrarVisitas : Form
    {
        E_visitas objEntidad = new E_visitas();
        N_visitas objNegocio = new N_visitas();
        N_edificios objEdificioN = new N_edificios();
        N_Aulas objAulasN = new N_Aulas();

        List<E_edificios> listaEdificios;
        List<E_aulas> listaAulas;

        public RegistrarVisitas()
        {
            InitializeComponent();

            //error messages
            lblErrorApellido.Visible = false;
            lblErrorAula.Visible = false;
            lblErrorEdificio.Visible = false;
            lblErrorNombre.Visible = false;
        }
        #region my methods
        //my methods
        private void CargarEdificios()
        {
            listaEdificios = objEdificioN.ListarEdificios("");
            for (int i = 0; i < listaEdificios.Count(); i++)
            {
                comboEdificio.Items.Add(listaEdificios[i].IdEdificio + "-" + listaEdificios[i].Nombre);
            }
        }

        private void CargarAulas(int id) 
        {
            comboAula.Items.Clear();
            listaAulas = objAulasN.listandoAulasPorEdificio(id);
            for (int i = 0; i < listaAulas.Count(); i++)
            {
                comboAula.Items.Add(listaAulas[i].IdAula + "-" + listaAulas[i].Nombre);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtApellido.Text != "" && comboAula.SelectedIndex > -1 && comboEdificio.SelectedIndex > -1)
            {
                try
                {
                    string idE = comboEdificio.SelectedItem.ToString();
                    string idA = comboAula.SelectedItem.ToString();

                    objEntidad.Nombre = txtNombre.Text;
                    objEntidad.Apellido = txtApellido.Text;
                    objEntidad.Carrera = txtCarrera.Text;
                    objEntidad.Correo = txtCorreo.Text;
                    objEntidad.IdEdificio = Convert.ToInt32("" + idE[0]);
                    objEntidad.HEntrada = timePickerHentrada.Value;
                    objEntidad.HSalida = timePickerHsalida.Value;
                    objEntidad.Motivo = txtMotivo.Text;
                    objEntidad.IdAula = Convert.ToInt32("" + idA[0]);

                    objNegocio.InsertandoVisitas(objEntidad);
                    MessageBox.Show("Se ha insertado correctamente");
                    limpiarCajas();
                }
                catch (Exception E)
                {
                    MessageBox.Show("no se pudo guardar" + E);
                }
            }
            else 
            {
                if(txtNombre.Text == "")
                {
                    lblErrorNombre.Text = "Este campo es obligatorio";
                    lblErrorNombre.Visible = true;
                }
                if(txtApellido.Text == "")
                {
                    lblErrorApellido.Text = "Este campo es obligatorio";
                    lblErrorApellido.Visible = true;
                }
                if(comboAula.SelectedIndex < 0)
                {
                    lblErrorAula.Text = "debes selecciona un aula";
                    lblErrorAula.Visible = true;
                }
                if(comboEdificio.SelectedIndex < 0)
                {
                    lblErrorEdificio.Text = "debes seleccionar un edificio";
                    lblErrorEdificio.Visible = true;
                }
            }
        }

        private void limpiarCajas()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCarrera.Text = "";
            txtCorreo.Text = "";
            txtMotivo.Text = "";
            comboAula.SelectedIndex = -1;
            comboEdificio.SelectedIndex = -1;
        }
        #endregion

        #region Event Handlers
        //Event Handlers

        private void RegistrarVisitas_Load(object sender, EventArgs e)
        {
            CargarEdificios();
        }

        private void comboEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboAula.Items.Clear();
            if (comboEdificio.SelectedIndex > -1)
            {
                string id = comboEdificio.SelectedItem.ToString();
                CargarAulas(Convert.ToInt32("" + id[0]));
            }
        }
    }
    #endregion
}
