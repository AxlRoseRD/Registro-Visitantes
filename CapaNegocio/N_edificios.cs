using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class N_edificios
    {
        D_edificios objDato = new D_edificios();

        public List<E_edificios> ListarEdificios(string buscar)
        {
            return objDato.ListarEdificios(buscar);
        }

        public List<E_edificios> ListarEdificios(int buscar)
        {
            return objDato.ListarEdificios(buscar);
        }

        public void InsertandoEdificio(E_edificios edificio)
        {
            objDato.InsertarEdificio(edificio);
        }

        public void EditandoEdificio(E_edificios edificios)
        {
            objDato.EditarEdificio(edificios);
        }

        public void EliminandoEdificio(E_edificios edificios)
        {
            objDato.EliminarEdificio(edificios);
        }
    }
}
