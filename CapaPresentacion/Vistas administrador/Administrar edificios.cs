using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion.Vistas_administrador
{
    public partial class Administrar_edificios : Form
    {
        private bool editar = false;
        private string idEdificio;


        E_edificios objEntidad = new E_edificios();
        N_edificios objNegocio = new N_edificios();

        public Administrar_edificios()
        {
            InitializeComponent();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarBuscarTabla(txtBuscar.Text);
        }

        private void mostrarBuscarTabla(string v)
        {
            N_edificios objNegocio = new N_edificios();
            tablaEdificio.DataSource = objNegocio.ListarEdificios(v);
        }

        private void Administrar_edificios_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
            accionesTabla();
            lblErrorNombre.Visible = false;
        }

        private void accionesTabla()
        {
            tablaEdificio.Columns[0].Visible = false;
            tablaEdificio.ClearSelection();
        }

        private void btninsertar_Click(object sender, EventArgs e)
        {
            if (editar == false && txtNombre.Text != "")
            {
                try
                {
                    objEntidad.Nombre = txtNombre.Text;

                    objNegocio.InsertandoEdificio(objEntidad);
                    MessageBox.Show("Se ha insertado correctamente");
                    mostrarBuscarTabla("");
                    limpiarCajas();
                }
                catch (Exception E)
                {
                    MessageBox.Show("no se pudo guardar el registro " + E);
                }
            }
            if (editar == true && txtNombre.Text != "")
            {
                try
                {
                    objEntidad.IdEdificio = Convert.ToInt32(idEdificio);
                    objEntidad.Nombre = txtNombre.Text;

                    objNegocio.EditandoEdificio(objEntidad);
                    MessageBox.Show("Se ha editado correctamente");
                    mostrarBuscarTabla("");
                    editar = false;
                    limpiarCajas();
                }
                catch (Exception E)
                {
                    MessageBox.Show("no se pudo editar el registro " + E);
                }
            }
            else
            {
                if (txtNombre.Text == "")
                {
                    lblErrorNombre.Visible = true;
                    lblErrorNombre.Text = "este campo es obligatorio";
                }
            }
        }
        private void limpiarCajas()
        {
            txtBuscar.Text = "";
            txtNombre.Text = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tablaEdificio.SelectedRows.Count > 0)
            {
                editar = true;
                idEdificio = tablaEdificio.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = tablaEdificio.CurrentRow.Cells[1].Value.ToString();
            }
            else
            {
                MessageBox.Show("seleccione la fila que desea editar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaEdificio.SelectedRows.Count > 0)
            {
                objEntidad.IdEdificio = Convert.ToInt32(tablaEdificio.CurrentRow.Cells[0].Value.ToString());
                objNegocio.EliminandoEdificio(objEntidad);

                MessageBox.Show("Se ha eliminado correctamente");
                mostrarBuscarTabla("");
            }
            else
            {
                MessageBox.Show("Selecciona las filas que quieres eliminar");

            }
        }
    }
}
