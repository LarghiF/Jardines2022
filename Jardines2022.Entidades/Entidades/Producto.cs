﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Entidades.Entidades
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public string NombreLatin { get; set; }
        public int ProveedorId { get; set; }
        public int CategoriaId { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int UnidadesEnStock { get; set; }
        public int UnidadesEnPedido { get; set; }
        public int NivelDeReposicion { get; set; }
        public bool Suspendido { get; set; }
        public string Imagen { get; set; }
        public Proveedor Proveedor { get; set; }
        public Categoria Categoria { get; set; }
    }
}
