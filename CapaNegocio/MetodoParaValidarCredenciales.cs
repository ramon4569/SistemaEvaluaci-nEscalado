using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CapaNegocio
{
    public class MetodoParaValidarCredenciales
    {
        private readonly string connectionString = "Server=.;Database=SistemaEvaluacionesDB;Integrated Security=true;TrustServerCertificate=True;";

        public bool ValidarCredenciales(string usuario, string contrasena)
        {
            bool credencialesValidas = false;
            // ¡¡ALERTA DE SEGURIDAD!!: En una aplicación real, NO compares contraseñas en texto plano.
            // Almacena y compara HASHES de contraseñas con SAL y PEPPER.
            // Aquí, por simplicidad del ejemplo, consultamos directamente el texto plano.

            string query = "SELECT COUNT(1) FROM Usuarios WHERE Usuario = @Usuario AND Contrasena = @Contrasena";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Usuario", usuario);
                command.Parameters.AddWithValue("@Contrasena", contrasena); // ¡Aquí se usa la contraseña en texto plano!

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar(); // Devuelve el número de filas que coinciden
                    if (count > 0)
                    {
                        credencialesValidas = true; // Si count es mayor que 0, las credenciales son válidas
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al validar credenciales: " + ex.Message);
                    // Si ocurre un error de base de datos, lo registramos.
                    // En producción, esto podría ser un log más robusto.
                }
            }
            return credencialesValidas;
        }
    }
}
