using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class E_usuario
    {
        private int idUsuario;
        private string name;
        private string lastname;
        private DateTime birthdate;
        private string nombre;
        private string password;
        private string tipo;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Password { get => password; set => password = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Name { get => name; set => name = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public DateTime Birthdate { get => birthdate; set => birthdate = value; }
    }
}
