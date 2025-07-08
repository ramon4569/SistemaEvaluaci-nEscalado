using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CapaNegocio
{
    public class MetodoParaObtenerEstudiantesActivos
    {
        private readonly string connectionString = "Server=.;Database=SistemaEvaluacionesDB;Integrated Security=true;TrustServerCertificate=True;";

        public List<Estudiante> ObtenerEstudiantesActivos()
        {
            var listaEstudiantes = new List<Estudiante>();
            using (var conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                // ¡MODIFICACIÓN CLAVE AQUÍ! Incluye 'id' en la consulta
                string query = "SELECT id, Matricula, Nombres, Apellidos, Activo FROM Estudiantes ORDER BY Apellidos, Nombres";

                using (var cmd = new SqlCommand(query, conexion))
                using (var reader = cmd.ExecuteReader())
                {
                    // Obtener los índices de las columnas para mayor eficiencia y seguridad
                    // (opcional, pero buena práctica)
                    int idOrdinal = reader.GetOrdinal("id");
                    int matriculaOrdinal = reader.GetOrdinal("Matricula");
                    int nombresOrdinal = reader.GetOrdinal("Nombres");
                    int apellidosOrdinal = reader.GetOrdinal("Apellidos");
                    int activoOrdinal = reader.GetOrdinal("Activo");


                    while (reader.Read())
                    {
                        listaEstudiantes.Add(new Estudiante
                        {
                            ID = reader.GetInt32(idOrdinal), // ¡Asigna el valor de la columna 'id'!
                            Matricula = reader.GetString(matriculaOrdinal),
                            Nombres = reader.GetString(nombresOrdinal),
                            Apellidos = reader.GetString(apellidosOrdinal),
                            Activo = reader.GetBoolean(activoOrdinal)
                        });
                    }
                }
            }
            return listaEstudiantes;
        }
    }
}
