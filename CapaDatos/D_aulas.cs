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
    public class D_aulas
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public void InsertarAula(E_aulas aula)
        {
            SqlCommand cmd = new SqlCommand("SP_CREAR_AULA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IDEDIFICIO", aula.IdEdificio);
            cmd.Parameters.AddWithValue("@NOMBRE", aula.Nombre);


            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public List<E_aulas> ListarAulas(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_AULA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            LeerFilas = cmd.ExecuteReader();

            List<E_aulas> listar = new List<E_aulas>();
            while (LeerFilas.Read())
            {
                listar.Add(new E_aulas
                {
                    IdAula = LeerFilas.GetInt32(0),
                    IdEdificio = LeerFilas.GetInt32(1),
                    Nombre = LeerFilas.GetString(2),
                });
            }
            conexion.Close();
            LeerFilas.Close();
            return listar;
        }

        public void EditarAulas(E_aulas aulas)
        {
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_AULA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID", aulas.IdAula);
            cmd.Parameters.AddWithValue("@IDEDIFICIO", aulas.IdEdificio); ;
            cmd.Parameters.AddWithValue("@NOMBRE", aulas.Nombre);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarAulas(E_aulas aulas)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_AULA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID", aulas.IdAula);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public List<E_aulas> ListarAulasPorEdificio(int buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_AULA_POR_EDIFICIO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@ID", buscar);
            LeerFilas = cmd.ExecuteReader();

            List<E_aulas> listar = new List<E_aulas>();
            while (LeerFilas.Read())
            {
                listar.Add(new E_aulas
                {
                    IdAula = LeerFilas.GetInt32(0),
                    IdEdificio = LeerFilas.GetInt32(1),
                    Nombre = LeerFilas.GetString(2),
                });
            }
            conexion.Close();
            LeerFilas.Close();
            return listar;
        }
    }
}
