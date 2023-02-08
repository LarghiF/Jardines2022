using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Entidades.Dtos
{
    public class ProductoListDto
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public string NombreLatin { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int UnidadesEnStock { get; set; }
        public bool Suspendido { get; set; }
        public string Imagen { get; set; }
        public string Categoria { get; set; }
    }
}
