using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class MetodoObtenerDesempenoPorEstudiante
    {
        private readonly string connectionString = "Server=.;Database=SistemaEvaluacionesDB;Integrated Security=true;TrustServerCertificate=True;";

        public List<EvaluacionDetalleEstudiante> ObtenerDesempenoPorEstudiante(string matriculaEstudiante = null) // Hacemos el parámetro opcional
        {
            List<EvaluacionDetalleEstudiante> evaluaciones = new List<EvaluacionDetalleEstudiante>();
            string query = @"
                SELECT 
                    E.Materia AS NombreMateria, 
                    E.TipoEvaluacion,
                    E.Calificacion,
                    E.Comentario,
                    E.FechaEvaluacion
                FROM 
                    Evaluaciones E
                JOIN 
                    Estudiantes Est ON E.MatriculaEstudiante = Est.Matricula";

            // Si se proporciona una matrícula, añade la cláusula WHERE
            if (!string.IsNullOrWhiteSpace(matriculaEstudiante))
            {
                query += " WHERE Est.Matricula = @MatriculaEstudiante";
            }

            query += " ORDER BY E.FechaEvaluacion ASC;"; // Ordenar siempre por fecha

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                // Solo añade el parámetro si la matrícula fue proporcionada
                if (!string.IsNullOrWhiteSpace(matriculaEstudiante))
                {
                    command.Parameters.AddWithValue("@MatriculaEstudiante", matriculaEstudiante);
                }

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        evaluaciones.Add(new EvaluacionDetalleEstudiante
                        {
                            NombreMateria = reader["NombreMateria"].ToString(),
                            TipoEvaluacion = reader["TipoEvaluacion"].ToString(),
                            Calificacion = Convert.ToDouble(reader["Calificacion"]),
                            FechaEvaluacion = Convert.ToDateTime(reader["FechaEvaluacion"]),
                            Comentario = reader["Comentario"].ToString()
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener desempeño por estudiante: " + ex.Message);
                    // IMPORTANTE: Revisa la ventana de SALIDA de VS para estos errores
                }
            }
            return evaluaciones;
        }



    }
}
