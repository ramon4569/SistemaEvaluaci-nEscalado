using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CapaNegocio
{
    public class MetodoparaobtenerTodosLosEstudiantes
    {
        private readonly string connectionString = "Server=.;Database=SistemaEvaluacionesDB;Integrated Security=true;TrustServerCertificate=True;";
        public List<Estudiante> ObtenerTodosLosEstudiantes()
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            string query = "SELECT ID, Nombre, Apellido, Matricula FROM Estudiantes ORDER BY Apellido, Nombre;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        estudiantes.Add(new Estudiante
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Nombres = reader["Nombre"].ToString(),
                            Apellidos = reader["Apellido"].ToString(),
                            Matricula = reader["Matricula"].ToString()
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener todos los estudiantes: " + ex.Message);
                }
            }
            return estudiantes;
        }
    }
}
