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

namespace CapaPresentacion.Vistas_administrador
{
    public partial class Administrar_Aulas : Form
    {
        //instancias y entidades
        E_aulas objEntidad = new E_aulas();
        N_Aulas objNegocio = new N_Aulas();
        N_edificios objEdificioN = new N_edificios();
        List<E_edificios> listaEdificios;       

        //variables
        private bool editar = false;
        private string idaula;

        #region metodos utiles
        //Metodos utiles
        public Administrar_Aulas()
        {
            InitializeComponent();
        }

        private void accionesTabla()
        {
            tablaAula.Columns[0].Visible = false;
            tablaAula.ClearSelection();
        }

        private void mostrarBuscarTabla(string v)
        {
            tablaAula.DataSource = objNegocio.listandoAulas(v);
        }

        private void limpiarCajas()
        {
            txtNombre.Text = "";
            txtBuscar.Text = "";
        }

        private void CargarCombobox() 
        {
            listaEdificios = objEdificioN.ListarEdificios("");
            for (int i = 0; i < listaEdificios.Count(); i++)
            {
                comboEdificio.Items.Add(listaEdificios[i].IdEdificio + "-" + listaEdificios[i].Nombre);
            }
        }

        #endregion

        #region event handlers
        //event handlers
        private void Administrar_Aulas_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
            accionesTabla();

            CargarCombobox();
            lblErrorNombre.Visible = false;
        }

        private void comboEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btninsertar_Click(object sender, EventArgs e)
        {
            if (editar == false && txtNombre.Text != "" && comboEdificio.SelectedIndex > -1)
            {
                try
                {
                    string id = comboEdificio.SelectedItem.ToString();

                    objEntidad.IdEdificio = Convert.ToInt32("" + id[0]);
                    objEntidad.Nombre = txtNombre.Text;

                    objNegocio.insertandoAulas(objEntidad);
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
                    string id = comboEdificio.SelectedItem.ToString();

                    objEntidad.IdAula = Convert.ToInt32(idaula);
                    objEntidad.IdEdificio = Convert.ToInt32(""+id[0]);
                    objEntidad.Nombre = txtNombre.Text;

                    objNegocio.EditandoAulas(objEntidad);
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
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarBuscarTabla(txtBuscar.Text);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tablaAula.SelectedRows.Count > 0)
            {
                editar = true;                

                idaula = tablaAula.CurrentRow.Cells[0].Value.ToString();  
                txtNombre.Text = tablaAula.CurrentRow.Cells[2].Value.ToString();
            }
            else
            {
                MessageBox.Show("seleccione la fila que desea editar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaAula.SelectedRows.Count > 0)
            {
                objEntidad.IdAula = Convert.ToInt32(tablaAula.CurrentRow.Cells[0].Value.ToString());
                objNegocio.EliminandoAulas(objEntidad);

                MessageBox.Show("Se ha eliminado correctamente");
                mostrarBuscarTabla("");
            }
            else
            {
                MessageBox.Show("Selecciona las filas que quieres eliminar");

            }
        }
    } 
    #endregion
}
