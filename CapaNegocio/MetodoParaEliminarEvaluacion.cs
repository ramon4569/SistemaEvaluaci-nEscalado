using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CapaNegocio
{
    public class MetodoParaEliminarEvaluacion
    {
        private readonly string connectionString = "Server=.;Database=SistemaEvaluacionesDB;Integrated Security=true;TrustServerCertificate=True;";
        public bool EliminarEvaluacion(int idEvaluacion)
        {
            try
            {
                using (var conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    string query = "DELETE FROM Evaluaciones WHERE ID = @IDEvaluacion";
                    using (var cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@IDEvaluacion", idEvaluacion);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // Retorna true si se eliminó al menos una fila
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar la evaluación: " + ex.Message);
                // Puedes añadir un log más detallado aquí si lo necesitas
                return false; // Retorna false si hubo un error
            }
        }
    }

}
