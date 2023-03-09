using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jardines2022.Web.Models.Producto
{
    public class ProductoDetalleVm
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