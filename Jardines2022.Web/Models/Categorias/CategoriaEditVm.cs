using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jardines2022.Web.Models.Categorias
{
    public class CategoriaEditVm
    {
        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        [DisplayName("Categoría")]
        public string NombreCategoria { get; set; }//100
        [DisplayName("Descripción")]
        [StringLength(225, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string Descripcion { get; set; }//225
    }
}