using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class D_usuario
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public void InsertarUsuario(E_usuario user)
        {
            SqlCommand cmd = new SqlCommand("SP_CREARU_SUARIO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@NAME", user.Name);
            cmd.Parameters.AddWithValue("@LASTNAME", user.Lastname);
            cmd.Parameters.AddWithValue("@BIRTHDATE", user.Birthdate);
            cmd.Parameters.AddWithValue("@USERNAME", user.Nombre);
            cmd.Parameters.AddWithValue("@PASSWORD", user.Password);
            cmd.Parameters.AddWithValue("@USERTYPE", user.Tipo);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public E_usuario obtenerUsuario(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_CONSULTAR_USUARIO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@USERNAME", buscar);
            LeerFilas = cmd.ExecuteReader();

            E_usuario user = new E_usuario();
            while (LeerFilas.Read())
            {
                user.IdUsuario = LeerFilas.GetInt32(0);                
                user.Name = LeerFilas.GetString(1);
                user.Lastname = LeerFilas.GetString(2);
                user.Birthdate = LeerFilas.GetDateTime(3);
                user.Nombre = LeerFilas.GetString(4); 
                user.Password = LeerFilas.GetString(5);
                user.Tipo = LeerFilas.GetString(6);
            }
            conexion.Close();
            LeerFilas.Close();
            return user;
        }
    }
}
