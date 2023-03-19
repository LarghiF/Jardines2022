using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Entidades.Entidades
{
    public class Venta
    {
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        public decimal Total { get; set; }
        public Usuario Usuario { get; set; }
    }
}
