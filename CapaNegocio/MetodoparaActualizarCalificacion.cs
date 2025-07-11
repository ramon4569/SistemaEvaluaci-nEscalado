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
            // Ahora, en lugar de Console.WriteLine, usamos la propiedad MostrarMensajeUI.
            // Verificamos que no sea nula antes de usarla, por si no se ha "conectado" desde la UI.
            MostrarMensajeUI?.Invoke("MetodoparaActualizarCalificacion: Preparando operación para actualizar calificación.");
        }

        public bool ActualizarCalificacion(int idEvaluacion, decimal nuevaCalificacion)
        {
            try
            {
                PrepararOperacion();
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
