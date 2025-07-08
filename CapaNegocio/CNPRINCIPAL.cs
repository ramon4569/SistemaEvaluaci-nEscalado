using System;
using Microsoft.Data.SqlClient;
using System.Collections;
using System.Data;
using CapaDatos;
using System.Collections.Generic;
using System.Runtime.CompilerServices;





namespace CapaNegocio
{
    // --- 1. CLASES DE MODELO (DEFINEN LA ESTRUCTURA DE TUS DATOS) ---

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

        // Constructor sin parámetros (opcional, si ya existe el constructor con parámetros)
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


    /// <summary>
    /// Representa la tabla 'Evaluaciones'.
    /// </summary>
    public class Evaluacion
    {
        public int ID { get; set; }
        public string MatriculaEstudiante { get; set; }
        public string Materia { get; set; }
        public string TipoEvaluacion { get; set; }
        public decimal Calificacion { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaEvaluacion { get; set; }

        // Constructor para inicializar una evaluación
        public Evaluacion(string matriculaEstudiante, string materia, string tipoEvaluacion, decimal calificacion, string comentario)
        {
            MatriculaEstudiante = matriculaEstudiante;
            Materia = materia;
            TipoEvaluacion = tipoEvaluacion;
            Calificacion = calificacion;
            Comentario = comentario;
            FechaEvaluacion = DateTime.Now; // Fecha actual por defecto
            Console.WriteLine($"Evaluacion: Objeto creado para {materia} ({tipoEvaluacion}) para el estudiante {matriculaEstudiante}.");
        }

        // Puedes añadir un constructor sin parámetros si es necesario
        public Evaluacion()
        {
            FechaEvaluacion = DateTime.Now;
        }
    }

    /// <summary>
    /// Clase auxiliar para llenar los ComboBox de estudiantes.
    /// </summary>
    public class EstudianteParaComboBox
    {
        public string Matricula { get; set; }
        public string NombreCompleto { get; set; }
        public override string ToString() => NombreCompleto;
    }

    /// <summary>
    /// Clase para mostrar los resultados combinados en el DataGridView.
    /// </summary>
    public class EvaluacionCompleta
    {
        public int IDEvaluacion { get; set; }
        public string Matricula { get; set; }
        public string NombreEstudiante { get; set; }
        public string Materia { get; set; }
        public string TipoEvaluacion { get; set; }
        public decimal Calificacion { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaEvaluacion { get; set; }
    }

    public class MateriaPromedio
    {
        public string NombreMateria { get; set; }
        public double PromedioCalificacion { get; set; }
    }

    // Clase para representar la distribución por tipo de evaluación
    public class TipoEvaluacionConteo
    {
        public string TipoEvaluacion { get; set; }
        public int Cantidad { get; set; }
    }

    // Clase para representar el desempeño detallado de un estudiante (reutiliza o adapta si ya tienes algo similar)
    public class EvaluacionDetalleEstudiante
    {
        public string NombreMateria { get; set; }
        public string TipoEvaluacion { get; set; }
        public double Calificacion { get; set; }
        public DateTime FechaEvaluacion { get; set; }
        public string Comentario { get; set; }


    }

    public class Usuario
    {
        public int Id { get; set; }
        public string UsuarioNombre { get; set; } // Cambiado a UsuarioNombre para evitar conflicto con palabra clave 'Usuario'
        public string ContrasenaHash { get; set; } // Debería ser el hash de la contraseña
        public string Rol { get; set; }
    }

    // --- 2. CLASE DE ACCESO A DATOS (ÚNICA CLASE PARA TODAS LAS OPERACIONES) ---

    /// <summary>
    /// Contiene todos los métodos para interactuar con la base de datos.
    /// </summary>

}




