using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class N_visitas
    {
        D_visitas objDato = new D_visitas();

        public List<E_visitas> ListarVisitas(string buscar)
        {
            return objDato.ListarVisitas(buscar);
        }


        public List<E_visitas> ListarVisitas(int buscar)
        {
            return objDato.ListarVisitas(buscar);
        }

        public void InsertandoVisitas(E_visitas visita)
        {
            objDato.InsertarVisitas(visita);
        }

        //public void EditandoEdificio(E_edificios edificios)
        //{
        //    objDato.EditarEdificio(edificios);
        //}

        //public void EliminandoEdificio(E_edificios edificios)
        //{
        //    objDato.EliminarEdificio(edificios);
        //}
    }
}
