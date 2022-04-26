using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class N_usuario
    {
        D_usuario du = new D_usuario();

        public User_Validation validarUsuario(string username,string pass)
        {
            E_usuario user = new E_usuario();
            User_Validation uv = new User_Validation();
            user = du.obtenerUsuario(username);

            uv.Username = (username == user.Nombre) ? true : false;
            uv.Password = (pass == user.Password) ? true : false;
            uv.Admin = (user.Tipo == "administrador") ? true : false;

            return uv;
        }

        public User_Validation validarUsuario(string username)
        {
            E_usuario user = new E_usuario();
            User_Validation uv = new User_Validation();
            user = du.obtenerUsuario(username);

            uv.Username = (username == user.Nombre) ? true : false;

            return uv;
        }

        public void CrearUsuario(E_usuario user) 
        {
            du.InsertarUsuario(user);
        }

        public E_usuario obteniendoUsuario(string username)
        {
            return du.obtenerUsuario(username);
        }
    }
}
