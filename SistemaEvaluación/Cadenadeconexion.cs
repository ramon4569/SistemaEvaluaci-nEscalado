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

   
}
    
