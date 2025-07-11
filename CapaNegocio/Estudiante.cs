using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    /// <summary>
    /// Representa la tabla 'Estudiantes'.
    /// </summary>

    public class Estudiante
    {
        public string Matricula { get; set; }
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public bool Activo { get; set; }

        // Constructor sin parámetros 
        public Estudiante()
        {
            Activo = true; // Por defecto, un estudiante es activo al crearse
            Console.WriteLine("Estudiante: Objeto creado (constructor sin parámetros).");
        }

        // Constructor con parámetros para facilitar la creación de objetos
        public Estudiante(string matricula, string nombres, string apellidos)
        {
            Matricula = matricula;
            Nombres = nombres;
            Apellidos = apellidos;
            Activo = true; // Por defecto
            Console.WriteLine($"Estudiante: Objeto creado para {Nombres} {Apellidos} con matrícula {Matricula}.");
        }
    }
}
