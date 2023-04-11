using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jardines2022.Web.Models.Paginacion
{
    public class Paginacion<p>where p:class
    {
        public int PaginaActual { get; set; }
        public int ElementosPorPagina { get; set; }
        public int ElementosTotales { get; set; }
        public int PaginasTotales { get; set; }
        public List<p> Productos { get; set; }
    }
}