using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CapaNegocio
{
    public class MetodoParaGuardarEstudiante
    {
        private readonly string connectionString = "Server=.;Database=SistemaEvaluacionesDB;Integrated Security=true;TrustServerCertificate=True;";
        public void GuardarEstudiante(Estudiante estudiante)
        {
            if (string.IsNullOrWhiteSpace(estudiante.Nombres) || string.IsNullOrWhiteSpace(estudiante.Apellidos))
            {
                throw new ArgumentException("El nombre y los apellidos del estudiante son obligatorios.");
            }
            using (var conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string query = "INSERT INTO Estudiantes (Matricula, Nombres, Apellidos) VALUES (@Matricula, @Nombres, @Apellidos)";
                using (var cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Matricula", estudiante.Matricula);
                    cmd.Parameters.AddWithValue("@Nombres", estudiante.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", estudiante.Apellidos);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
