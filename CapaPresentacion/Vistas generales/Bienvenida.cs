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
    public partial class Bienvenida : Form
    {
        public Bienvenida(string nombre)
        {
            InitializeComponent();
            lblSaludo.Text += nombre;
        }

        private void Bienvenida_Load(object sender, EventArgs e)
        {

        }
    }
}
