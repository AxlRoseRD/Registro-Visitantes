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

namespace CapaPresentacion.Vistas_inicio_sesion
{
    public partial class Nuevo_Usuario : Form
    {

        public Nuevo_Usuario()
        {
            InitializeComponent();

            lblErrorNombre.Visible = false;
            lblErrorApellido.Visible = false;
            lblErrorPassword.Visible = false;
            lblErrorPassword2.Visible = false;
            lblErrorUserName.Visible = false;
            lblErrorTipo.Visible = false;
        }

        private void btnRegistrarVisita_Click(object sender, EventArgs e)
        {
            N_usuario nu = new N_usuario();
            User_Validation uv = nu.validarUsuario(txtUserName.Text);


            if (txtNombre.Text.Length > 0 && txtApellido.Text.Length > 0 && txtPassword.Text.Length >= 4 && txtUserName.Text.Length > 0 && uv.Username == false && txtCPassword.Text == txtPassword.Text)
            {
                E_usuario user = new E_usuario();
                user.Name = txtNombre.Text;
                user.Lastname = txtApellido.Text;
                user.Birthdate = pickerBirthdate.Value;
                user.Nombre = txtUserName.Text;
                user.Password = txtPassword.Text;
                user.Tipo = comboTipo.SelectedItem.ToString();

                nu.CrearUsuario(user);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                if (uv.Username == true)
                {
                    lblErrorUserName.Text = "Este nombre de usuario ya existe";
                    lblErrorUserName.Visible = true;
                }
                if (txtUserName.Text == "")
                {
                    lblErrorUserName.Text = "Nombre de usuario invalido";
                    lblErrorUserName.Visible = true;
                }
                if (txtCPassword.Text != txtPassword.Text)
                {
                    lblErrorPassword2.Text = "Las contraseñas no coinciden";
                    lblErrorPassword2.Visible = true;
                }
                if (txtPassword.Text.Length < 4)
                {
                    lblErrorPassword.Text = "Minimo 4 caracteres";
                    lblErrorPassword.Visible = true;
                }
                if (comboTipo.SelectedIndex < 0)
                {
                    lblErrorTipo.Text = "debe seleccionar un tipo de usuario";
                    lblErrorTipo.Visible = true;
                }
                if (txtApellido.Text == "")
                {
                    lblErrorApellido.Text = "este campo es obligatorio";
                    lblErrorApellido.Visible = true;
                }
                if (txtApellido.Text == "")
                {
                    lblErrorNombre.Text = "este campo es obligatorio";
                    lblErrorNombre.Visible = true;
                }
            }
        }

        private void Nuevo_Usuario_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
