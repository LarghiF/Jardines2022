using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jardines2022.Web.Models.Ciudad
{
    public class CiudadEditVm
    {
        public int CiudadId { get; set; }
        [DisplayName("Ciudad")]
        public string NombreCiudad { get; set; }
        [DisplayName("País")]
        [Required(ErrorMessage ="El campo {0} es requerido")]
        public int PaisId { get; set; }
        public List<Entidades.Entidades.Pais> Pais { get; set; }
    }
}