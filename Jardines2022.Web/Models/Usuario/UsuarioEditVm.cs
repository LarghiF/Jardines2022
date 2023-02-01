using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jardines2022.Web.Models.Usuario
{
    public class UsuarioEditVm
    {
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(150, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string Clave { get; set; }
        [DisplayName("Confirmar Clave")]
        public string ConfirmarClave { get; set; }
        public bool Restablecer { get; set; }

        // NUEVO INTENTO

        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string Nombre { get; set; }
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string Apellido { get; set; }
        [DisplayName("Dirección")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string Direccion { get; set; }
        [DisplayName("Codigo Postal")]
        [StringLength(10, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string CodigoPostal { get; set; }
        [DisplayName("Documento")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string DNI { get; set; }
        [DisplayName("País")]
        //[Required(ErrorMessage = "El campo {0} es requerido")]
        public int PaisId { get; set; }
        public List<Entidades.Entidades.Pais> Pais { get; set; }
        [DisplayName("Ciudad")]
        //[Required(ErrorMessage = "El campo {0} es requerido")]
        public int CiudadId { get; set; }
        public List<Entidades.Dtos.CiudadListDto> Ciudades { get; set; }



    }
}