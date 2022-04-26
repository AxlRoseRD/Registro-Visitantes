using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public  class E_visitas
    {
        private int idVisita;
        private string nombre;
        private string apellido;
        private string carrera;
        private string correo;
        private int idEdificio;
        private DateTime hEntrada;
        private DateTime hSalida;
        private string motivo;
        private int idAula;

        private TimeSpan shEntrada;
        private TimeSpan shSalida;

        public int IdVisita { get => idVisita; set => idVisita = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Carrera { get => carrera; set => carrera = value; }
        public string Correo { get => correo; set => correo = value; }
        public int IdEdificio { get => idEdificio; set => idEdificio = value; }
        public DateTime HEntrada { get => hEntrada; set => hEntrada = value; }
        public DateTime HSalida { get => hSalida; set => hSalida = value; }
        public string Motivo { get => motivo; set => motivo = value; }
        public int IdAula { get => idAula; set => idAula = value; }
        public TimeSpan ShEntrada { get => shEntrada; set => shEntrada = value; }
        public TimeSpan ShSalida { get => shSalida; set => shSalida = value; }
    }
}
