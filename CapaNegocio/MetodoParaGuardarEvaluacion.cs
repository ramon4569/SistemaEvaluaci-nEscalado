using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CapaNegocio
{
    public class MetodoParaGuardarEvaluacion
    {
        private readonly string connectionString = "Server=.;Database=SistemaEvaluacionesDB;Integrated Security=true;TrustServerCertificate=True;";
        public void GuardarEvaluacion(Evaluacion evaluacion)
        {
            if (string.IsNullOrWhiteSpace(evaluacion.MatriculaEstudiante)) throw new ArgumentException("La matrícula del estudiante es obligatoria.");
            if (string.IsNullOrWhiteSpace(evaluacion.Materia)) throw new ArgumentException("El campo Materia es obligatorio.");
            if (string.IsNullOrWhiteSpace(evaluacion.TipoEvaluacion)) throw new ArgumentException("El campo Tipo de Evaluación es obligatorio.");

            using (var conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string query = @"INSERT INTO Evaluaciones 
                               (MatriculaEstudiante, Materia, TipoEvaluacion, Calificacion, Comentario, FechaEvaluacion) 
                             VALUES 
                               (@MatriculaEstudiante, @Materia, @TipoEvaluacion, @Calificacion, @Comentario, @FechaEvaluacion)";
                using (var cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@MatriculaEstudiante", evaluacion.MatriculaEstudiante);
                    cmd.Parameters.AddWithValue("@Materia", evaluacion.Materia);
                    cmd.Parameters.AddWithValue("@TipoEvaluacion", evaluacion.TipoEvaluacion);
                    cmd.Parameters.AddWithValue("@Calificacion", evaluacion.Calificacion);
                    cmd.Parameters.AddWithValue("@Comentario", string.IsNullOrWhiteSpace(evaluacion.Comentario) ? (object)DBNull.Value : evaluacion.Comentario);
                    cmd.Parameters.AddWithValue("@FechaEvaluacion", evaluacion.FechaEvaluacion);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
