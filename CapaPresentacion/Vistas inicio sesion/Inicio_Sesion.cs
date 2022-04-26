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
using CapaEntidad;
using CapaPresentacion.Vistas_inicio_sesion;

namespace CapaPresentacion
{
    public partial class Inicio_Sesion : Form
    {
        private string errorMessage1 = "Contraseña incorrecta";
        private string errorMessage3 = "Usuario inexistente";
        private N_usuario nu = new N_usuario();

        public Inicio_Sesion()
        {
            InitializeComponent();
            
            //errors
            lblErrorPassword.Visible = false;
            lblErrorUsuario.Visible = false;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            User_Validation u = nu.validarUsuario(txtUsername.Text,txtPassword.Text);


            if (u.Password == true && u.Username == true && u.Admin == true) 
            {
                Main_Menu mm = new Main_Menu(nu.obteniendoUsuario(txtUsername.Text));
                mm.Show();
                this.Hide();
            }
            else if (u.Password == true && u.Username == true && u.Admin == false) 
            {
                Main_Menu_General mmg = new Main_Menu_General(nu.obteniendoUsuario(txtUsername.Text));
                mmg.Show();
                this.Hide();
            }
            if(u.Password == false)
            {
                lblErrorPassword.Text = errorMessage1;
                lblErrorPassword.Visible = true;
            }
            if (u.Username == false)
            {
                lblErrorUsuario.Text = errorMessage3;
                lblErrorUsuario.Visible = true;
            }
        }

        private void Inicio_Sesion_Load(object sender, EventArgs e)
        {

        }
    }
}
