using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace CapaNegocio
{
    public class MetodoParaObtenerEvaluaciones
    {
        private readonly string connectionString = "Server=.;Database=SistemaEvaluacionesDB;Integrated Security=true;TrustServerCertificate=True;";
        public List<EvaluacionCompleta> ObtenerEvaluaciones(string matricula, string materia, DateTime? fechaDesde, DateTime? fechaHasta)
        {
            var listaEvaluaciones = new List<EvaluacionCompleta>();
            var queryBase = @"SELECT 
                                ev.ID, ev.MatriculaEstudiante, es.Nombres + ' ' + es.Apellidos AS NombreEstudiante, 
                                ev.Materia, ev.TipoEvaluacion, ev.Calificacion, ev.Comentario, ev.FechaEvaluacion 
                              FROM Evaluaciones ev
                              INNER JOIN Estudiantes es ON ev.MatriculaEstudiante = es.Matricula
                              WHERE 1=1";

            using (var conexion = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand();
                var parametros = new List<string>();

                if (!string.IsNullOrWhiteSpace(matricula))
                {
                    parametros.Add("ev.MatriculaEstudiante = @Matricula");
                    cmd.Parameters.AddWithValue("@Matricula", matricula);
                }
                if (!string.IsNullOrWhiteSpace(materia))
                {
                    parametros.Add("ev.Materia = @Materia");
                    cmd.Parameters.AddWithValue("@Materia", materia);
                }
                if (fechaDesde.HasValue)
                {
                    parametros.Add("ev.FechaEvaluacion >= @FechaDesde");
                    cmd.Parameters.AddWithValue("@FechaDesde", fechaDesde.Value.Date);
                }
                if (fechaHasta.HasValue)
                {
                    parametros.Add("ev.FechaEvaluacion <= @FechaHasta");
                    cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta.Value.Date);
                }

                if (parametros.Count > 0)
                {
                    queryBase += " AND " + string.Join(" AND ", parametros);
                }

                cmd.CommandText = queryBase + " ORDER BY ev.FechaEvaluacion DESC";
                cmd.Connection = conexion;

                conexion.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaEvaluaciones.Add(new EvaluacionCompleta
                        {
                            IDEvaluacion = Convert.ToInt32(reader["ID"]),
                            Matricula = reader["MatriculaEstudiante"].ToString(),
                            NombreEstudiante = reader["NombreEstudiante"].ToString(),
                            Materia = reader["Materia"].ToString(),
                            TipoEvaluacion = reader["TipoEvaluacion"].ToString(),
                            Calificacion = Convert.ToDecimal(reader["Calificacion"]),
                            Comentario = reader["Comentario"].ToString(),
                            FechaEvaluacion = Convert.ToDateTime(reader["FechaEvaluacion"])
                        });
                    }
                }
            }
            return listaEvaluaciones;
        }
    }
}
