using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jardines2022.Web.Helpers
{
    public static class HelperImagenes
    {
        public const string rutaPrincipal = "C:/Proyectos/Jardines2022FedericoL-master/Jardines2022.Web/Content/assets/img/";
        public const string rutaMuestra = "Muestra/";
        public const string rutaProductos = "Productos/";
        public const string rutaUsuarios = "Usuarios/";
        public const string imgProducto = "Imagen_no_disponible.png";
        public const string imgUsuario = "Usuarios/user.png";
        public static string Conversor(string ruta)
        {
            if (ruta == null)
            {
                ruta = rutaPrincipal+rutaMuestra+imgProducto;
            }
            else
            {
                ruta = rutaPrincipal + rutaProductos + ruta;
            }
            byte[] imgArray = System.IO.File.ReadAllBytes(ruta);
            string base64Imagen = Convert.ToBase64String(imgArray);
            return base64Imagen;
        }
    }
}