using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class N_Aulas
    {
        D_aulas objDato = new D_aulas();

        public List<E_aulas> listandoAulas(string buscar)
        {
            return objDato.ListarAulas(buscar);
        }

        public List<E_aulas> listandoAulasPorEdificio(int buscar)
        {
            return objDato.ListarAulasPorEdificio(buscar);
        }

        public void insertandoAulas(E_aulas aula)
        {
            objDato.InsertarAula(aula);
        }

        public void EditandoAulas(E_aulas aulas)
        {
            objDato.EditarAulas(aulas);
        }

        public void EliminandoAulas(E_aulas aulas)
        {
            objDato.EliminarAulas(aulas);
        }
    }
}
