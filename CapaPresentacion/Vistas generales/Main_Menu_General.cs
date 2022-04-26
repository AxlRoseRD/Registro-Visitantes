using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaPresentacion.Vistas_administrador;
using CapaPresentacion.Vistas_generales;
using CapaPresentacion.Vistas_inicio_sesion;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    public partial class Main_Menu_General : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        private E_usuario usuario;

        public Main_Menu_General()
        {
            InitializeComponent();

            //borde del boton
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(8, 60);
            PanelMenu.Controls.Add(leftBorderBtn);
            //fomr
            this.Text = String.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        public Main_Menu_General(E_usuario user)
        {
            InitializeComponent();

            usuario = user;

            //borde del boton
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(8, 60);
            PanelMenu.Controls.Add(leftBorderBtn);
            //fomr
            this.Text = String.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            //home
            OpenChildForm(new Bienvenida(user.Name)); //lanza la bienvenida al usuario
        }
        //metodos
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton(); //quita la animacion al boton que estaba presionado
                //boton
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = RGBcolors.azul_Itla_sombreado;
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                //borde izquierdo del boton
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                //cambiar el icono por ventana actual
                iconCurrent.IconChar = currentBtn.IconChar;
                iconCurrent.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(0, 112, 187);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childrenForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childrenForm;
            childrenForm.TopLevel = false;
            childrenForm.FormBorderStyle = FormBorderStyle.None;
            childrenForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childrenForm);
            panelChildForm.Tag = childrenForm;
            childrenForm.BringToFront();
            childrenForm.Show();
            lblTitle.Text = childrenForm.Text;
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            //cambiar el icono por ventana actual
            iconCurrent.IconChar = IconChar.Home;
            iconCurrent.IconColor = Color.White;
            lblTitle.Text = "home";
        }


        //estructras
        private struct RGBcolors
        {
            public static Color azul_Itla_oscuro = Color.FromArgb(2, 56, 119);
            public static Color azul_Itla = Color.FromArgb(0, 112, 187);
            public static Color azul_Itla_claro = Color.FromArgb(17, 119, 209);
            public static Color azul_Verdoso_Boton_Itla = Color.FromArgb(35, 192, 162);
            public static Color rojo_Itla = Color.FromArgb(229, 34, 41);
            public static Color azul_Itla_sombreado = Color.FromArgb(11, 79, 138);
        }

        //drag form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void PanelHead_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //senders

        private void Main_Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrarVisita_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.azul_Verdoso_Boton_Itla); //agrega animacion al boton
            OpenChildForm(new RegistrarVisitas()); //abre el nuevo formulario
        }

        private void btnVerVisitas_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.rojo_Itla); //agrega animacion al boton
            OpenChildForm(new Visualizar_Visitas()); //abre el nuevo formulario
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            currentChildForm.Close(); //cierra el formulario actual
            Reset();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnCuenta_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.rojo_Itla); //agrega animacion al boton
            OpenChildForm(new Mi_cuenta(usuario)); //abre el nuevo formulario
        }
    }
}
