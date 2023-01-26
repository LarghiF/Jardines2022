using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Entidades.Dtos
{
    public class UsuarioListDto
    {
        public int UsuarioId { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public int RolId { get; set; }
    }
}
