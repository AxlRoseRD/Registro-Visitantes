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
    public class D_visitas
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_visitas> ListarVisitas(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_VISITA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            LeerFilas = cmd.ExecuteReader();

            List<E_visitas> listar = new List<E_visitas>();
            while (LeerFilas.Read())
            {
                listar.Add(new E_visitas
                {
                    IdVisita = LeerFilas.GetInt32(0),
                    Nombre = LeerFilas.GetString(1),
                    Apellido = LeerFilas.GetString(2),
                    Carrera = LeerFilas.GetString(3),
                    Correo = LeerFilas.GetString(4),
                    IdEdificio = LeerFilas.GetInt32(5),
                    ShEntrada = LeerFilas.GetTimeSpan(6),
                    ShSalida = LeerFilas.GetTimeSpan(7),
                    Motivo = LeerFilas.GetString(8),
                    IdAula = LeerFilas.GetInt32(9)
                });
            }
            conexion.Close();
            LeerFilas.Close();
            return listar;
        }

        public List<E_visitas> ListarVisitas(int buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_VISITA_EDIFICIO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            LeerFilas = cmd.ExecuteReader();

            List<E_visitas> listar = new List<E_visitas>();
            while (LeerFilas.Read())
            {
                listar.Add(new E_visitas
                {
                    IdVisita = LeerFilas.GetInt32(0),
                    Nombre = LeerFilas.GetString(1),
                    Apellido = LeerFilas.GetString(2),
                    Carrera = LeerFilas.GetString(3),
                    Correo = LeerFilas.GetString(4),
                    IdEdificio = LeerFilas.GetInt32(5),
                    ShEntrada = LeerFilas.GetTimeSpan(6),
                    ShSalida = LeerFilas.GetTimeSpan(7),
                    Motivo = LeerFilas.GetString(8),
                    IdAula =LeerFilas.GetInt32(9)
                }); 
            }
            conexion.Close();
            LeerFilas.Close();
            return listar;
        }

        public void InsertarVisitas(E_visitas visita)
        {
            SqlCommand cmd = new SqlCommand("SP_CREAR_VISITA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", visita.Nombre);
            cmd.Parameters.AddWithValue("@APELLIDO", visita.Apellido);
            cmd.Parameters.AddWithValue("@CARRERA", visita.Carrera);
            cmd.Parameters.AddWithValue("@CORREO", visita.Correo);
            cmd.Parameters.AddWithValue("@IDEDIFICIO", visita.IdEdificio);
            cmd.Parameters.AddWithValue("@H_ENTRADA", visita.HEntrada);
            cmd.Parameters.AddWithValue("@H_SALIDA", visita.HSalida);
            cmd.Parameters.AddWithValue("@MOVIVOV", visita.Motivo);
            cmd.Parameters.AddWithValue("@IDAULA", visita.IdAula);


            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
