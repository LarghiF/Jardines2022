using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Entidades.Entidades
{
    public class Carrito
    {
        public int CarritoId { get; set; }
        public int UsuarioId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public Producto Producto { get; set; }
        public Usuario Usuario { get; set; }
    }
}
