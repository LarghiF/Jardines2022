using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Jardines2022.Web.Models.Categorias
{
    public class CategoriaListVm
    {
        public int CategoriaId { get; set; }
        [DisplayName("Categoría")]
        public string NombreCategoria { get; set; }//100
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }//225
    }
}