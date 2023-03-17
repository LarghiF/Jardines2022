using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Entidades.Entidades
{
    public class Orden
    {
        public int OrdenId { get; set; }
        public string CodigoCliente { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime FechaEnvio { get; set; }
        public int PersonaId { get; set; }
    }
}
