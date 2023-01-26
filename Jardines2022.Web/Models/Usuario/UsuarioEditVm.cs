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
    }
}