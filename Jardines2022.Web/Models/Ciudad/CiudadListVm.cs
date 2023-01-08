using System.ComponentModel;

namespace Jardines2022.Web.Models.Ciudad
{
    public class CiudadListVm
    {
        public int CiudadId { get; set; }
        [DisplayName("Ciudad")]
        public string NombreCiudad { get; set; }
        [DisplayName("País")]
        public string Pais { get; set; }

    }
}