using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Entidades.Entidades
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public bool Restablecer { get; set; }
        public bool Valido { get; set; }
        public Rol RolId { get; set; }
        
        // NUEVO INTENTO
        
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string CodigoPostal { get; set; }
        public string DNI { get; set; }
        public int PaisId { get; set; }
        public Pais Pais { get; set; }
        public int CiudadId { get; set; }
        public Ciudad Ciudad { get; set; }
    }
}
