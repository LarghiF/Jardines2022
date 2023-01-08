using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jardines2022.Web.Models.Paises
{
    public class PaisListVm
    {
        public int PaisId { get; set; }
        [DisplayName("País")]
        public string NombrePais { get; set; }


    }
}