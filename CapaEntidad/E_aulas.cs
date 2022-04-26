using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class E_aulas
    {
        private int idAula;
        private int idEdificio;
        private string nombre;

        public int IdAula { get => idAula; set => idAula = value; }
        public int IdEdificio { get => idEdificio; set => idEdificio = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
