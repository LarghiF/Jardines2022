using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Jardines2022.Web.Models.Venta
{
    public class VentaVm
    {
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        public decimal Total { get; set; }
        public List<Entidades.Entidades.Usuario> Usuarios { get; set; }
    }
}