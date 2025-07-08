using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Microsoft.Data.SqlClient;

namespace CapaNegocio
{
    public class MetodoparaActualizarCalificacion : BaseDatos
    {
        public override void PrepararOperacion()
        {
            // Implementación básica para cumplir con el contrato de la clase base.  
            // Puedes agregar lógica específica aquí si es necesario.  
            Console.WriteLine("Preparando operación en MetodoparaActualizarCalificacion.");
        }

        public bool ActualizarCalificacion(int idEvaluacion, decimal nuevaCalificacion)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "UPDATE Evaluaciones SET Calificacion = @NuevaCalificacion WHERE ID = @IDEvaluacion";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NuevaCalificacion", nuevaCalificacion);
                        command.Parameters.AddWithValue("@IDEvaluacion", idEvaluacion);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar la calificación: " + ex.Message);
                return false;
            }
        }
    }
}
