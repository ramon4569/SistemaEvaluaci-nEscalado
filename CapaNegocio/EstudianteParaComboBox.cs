using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    /// <summary>
    /// Clase auxiliar para llenar los ComboBox de estudiantes.
    /// </summary>
    public class EstudianteParaComboBox
    {
        public string Matricula { get; set; }
        public string NombreCompleto { get; set; }
        public override string ToString() => NombreCompleto;
    }
}
