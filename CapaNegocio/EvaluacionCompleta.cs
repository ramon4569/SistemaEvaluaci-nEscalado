using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
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
}
