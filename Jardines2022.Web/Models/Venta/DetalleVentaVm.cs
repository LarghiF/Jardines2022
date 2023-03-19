using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jardines2022.Web.Models.Venta
{
    public class DetalleVentaVm
    {
        public int DetalleVentaId { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public List<Entidades.Entidades.Producto> Productos { get; set; }
        public List<Entidades.Entidades.Usuario> Usuarios { get; set; }
    }
}