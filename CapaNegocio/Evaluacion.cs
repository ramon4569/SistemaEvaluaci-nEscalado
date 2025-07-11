using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
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
}
