﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jardines2022.Web.Models.Carrito
{
    public class CarritoListVm
    {
        public int CarritoId { get; set; }
        public int ProductoId { get; set; }
        public string Producto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Total => Precio * Cantidad;
    }
}