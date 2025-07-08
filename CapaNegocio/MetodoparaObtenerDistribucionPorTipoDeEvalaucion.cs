using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CapaNegocio
{
    public class MetodoparaObtenerDistribucionPorTipoDeEvalaucion
    {
        private readonly string connectionString = "Server=.;Database=SistemaEvaluacionesDB;Integrated Security=true;TrustServerCertificate=True;";
        public List<TipoEvaluacionConteo> ObtenerDistribucionPorTipoEvaluacion()
        {
            List<TipoEvaluacionConteo> distribucion = new List<TipoEvaluacionConteo>();
            string query = @"
        SELECT 
            TipoEvaluacion,
            COUNT(ID) AS Cantidad 
        FROM 
            Evaluaciones
        GROUP BY 
            TipoEvaluacion
        ORDER BY
            TipoEvaluacion;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        distribucion.Add(new TipoEvaluacionConteo
                        {
                            TipoEvaluacion = reader["TipoEvaluacion"].ToString(),
                            Cantidad = Convert.ToInt32(reader["Cantidad"]) // Esto debe ser un conteo simple
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener distribución por tipo de evaluación (DatosManager): " + ex.Message);
                }
            }
            return distribucion;
        }
    }
}
