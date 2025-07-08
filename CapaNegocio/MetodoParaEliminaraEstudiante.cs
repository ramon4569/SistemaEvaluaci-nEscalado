using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CapaNegocio
{
    public class MetodoParaEliminaraEstudiante
    {
        private readonly string connectionString = "Server=.;Database=SistemaEvaluacionesDB;Integrated Security=true;TrustServerCertificate=True;";

        public void EliminarEstudiante(string matricula)
        {
            if (string.IsNullOrWhiteSpace(matricula))
            {
                throw new ArgumentException("La matrícula no puede estar vacía para eliminar.");
            }

            using (var conexion = new SqlConnection(connectionString))
            {
                conexion.Open(); // Abre la conexión
                SqlTransaction transaction = conexion.BeginTransaction(); // Inicia una transacción

                try
                {
                    // 1. Eliminar las evaluaciones asociadas al estudiante
                    string deleteEvaluacionesQuery = "DELETE FROM Evaluaciones WHERE MatriculaEstudiante = @Matricula";
                    using (var cmdEvaluaciones = new SqlCommand(deleteEvaluacionesQuery, conexion, transaction))
                    {
                        cmdEvaluaciones.Parameters.AddWithValue("@Matricula", matricula);
                        int rowsAffectedEvaluaciones = cmdEvaluaciones.ExecuteNonQuery();
                        Console.WriteLine($"Se eliminaron {rowsAffectedEvaluaciones} evaluaciones para la matrícula {matricula}.");
                    }

                    // 2. Eliminar al estudiante
                    string deleteEstudianteQuery = "DELETE FROM Estudiantes WHERE Matricula = @Matricula";
                    using (var cmdEstudiante = new SqlCommand(deleteEstudianteQuery, conexion, transaction))
                    {
                        cmdEstudiante.Parameters.AddWithValue("@Matricula", matricula);
                        int rowsAffectedEstudiante = cmdEstudiante.ExecuteNonQuery();

                        if (rowsAffectedEstudiante == 0)
                        {
                            // Si no se afectó ninguna fila, podría ser que el estudiante no existía
                            // o ya había sido eliminado. Podrías lanzar una excepción o registrar esto.
                            throw new InvalidOperationException($"No se encontró ningún estudiante con la matrícula {matricula} para eliminar.");
                        }
                        Console.WriteLine($"Se eliminó el estudiante con matrícula {matricula}.");
                    }

                    // Si todo salió bien, confirma la transacción
                    transaction.Commit();
                    Console.WriteLine("Operación de eliminación completada con éxito.");
                }
                catch (Exception ex)
                {
                    // Si ocurre cualquier error, revierte la transacción
                    transaction.Rollback();
                    Console.WriteLine($"Error al eliminar el estudiante y/o sus evaluaciones: {ex.Message}");
                    // Propaga la excepción para que el llamador pueda manejarla
                    throw;
                }
            }
        }
    }
}
