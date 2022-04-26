using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class D_edificios
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public void InsertarEdificio(E_edificios edificio)
        {
            SqlCommand cmd = new SqlCommand("SP_CREAR_EDIFICIO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", edificio.Nombre);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public List<E_edificios> ListarEdificios(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_EDIFICIOS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", buscar);
            LeerFilas = cmd.ExecuteReader();

            List<E_edificios> listar = new List<E_edificios>();
            while (LeerFilas.Read())
            {
                listar.Add(new E_edificios
                {
                    IdEdificio = LeerFilas.GetInt32(0),
                    Nombre = LeerFilas.GetString(1),
                });
            }
            conexion.Close();
            LeerFilas.Close();
            return listar;
        }

        public List<E_edificios> ListarEdificios(int buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_EDIFICIO_POR_ID", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID", buscar);
            LeerFilas = cmd.ExecuteReader();

            List<E_edificios> listar = new List<E_edificios>();
            while (LeerFilas.Read())
            {
                listar.Add(new E_edificios
                {
                    IdEdificio = LeerFilas.GetInt32(0),
                    Nombre = LeerFilas.GetString(1),
                });
            }
            conexion.Close();
            LeerFilas.Close();
            return listar;
        }

        public void EditarEdificio(E_edificios edificio)
        {
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_EDIFICIO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID", edificio.IdEdificio);
            cmd.Parameters.AddWithValue("@NOMBRE", edificio.Nombre);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarEdificio(E_edificios edifico)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_EDIFICIO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID", edifico.IdEdificio);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
