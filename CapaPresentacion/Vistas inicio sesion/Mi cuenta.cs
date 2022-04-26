using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;

namespace CapaPresentacion.Vistas_inicio_sesion
{
    public partial class Mi_cuenta : Form
    {        

        public Mi_cuenta(E_usuario user)
        {
            InitializeComponent();
            lblNombre.Text = user.Name;
            lblApellido.Text = user.Lastname;
            lblBirthDate.Text = user.Birthdate.ToString();
            lblTipo.Text = user.Tipo;
            lblUsername.Text = user.Nombre;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
