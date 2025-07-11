using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string UsuarioNombre { get; set; } // Cambiado a UsuarioNombre para evitar conflicto con palabra clave 'Usuario'
        public string ContrasenaHash { get; set; } // Debería ser el hash de la contraseña
        public string Rol { get; set; }
    }
}
