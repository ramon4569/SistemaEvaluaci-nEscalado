namespace CapaDatos
{
    using System;
    using System.Collections; // Necesario para ArrayList
    using System.Collections.Generic; // Aún necesario para el tipo de retorno de la lista interna si la usáramos, pero la quitamos
    using System.Data;
    using System.Data.SqlClient;
    using Microsoft.Data.SqlClient;




    public class Cadenadeconexion
    {
        public string connectionString = "Server=.;Database=SistemaEvaluacionesDB;Integrated Security=true" + " ;TrustServerCertificate=True;"; // Cadena de conexión con SQL SERVER

    }

    public abstract class BaseDatos
    {
        protected string ConnectionString { get; private set; }

        // Constructor de la clase base
        public BaseDatos()
        {
            Cadenadeconexion cadena = new Cadenadeconexion();
            ConnectionString = cadena.connectionString;
            Console.WriteLine("BaseDatos: Constructor ejecutado. Conexión lista."); // Para demostración
        }

        // Método Protegido Virtual: Puede ser sobrescrito por clases derivadas
        // Usaremos esto para una posible lógica de loggeo o validación de conexión pre-operación
        protected virtual SqlConnection GetConnection()
        {
            Console.WriteLine("BaseDatos: Obteniendo conexión a la base de datos."); // Para demostración
            return new SqlConnection(ConnectionString);
        }

        // Método Abstracto: Debe ser implementado por cualquier clase no abstracta que herede de BaseDatos
        // Esto obliga a las clases derivadas a definir cómo se "prepara" una operación
        public abstract void PrepararOperacion();

        protected int ExecuteNonQuery(SqlCommand command)
        {
            using (SqlConnection connection = GetConnection())
            {
                command.Connection = connection;
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        protected SqlDataReader ExecuteReader(SqlCommand command)
        {
            SqlConnection connection = GetConnection();
            command.Connection = connection;
            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
    
