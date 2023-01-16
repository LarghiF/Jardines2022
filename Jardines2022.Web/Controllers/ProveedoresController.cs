using Jardines2022.Entidades.Entidades;
using Jardines2022.Servicios.Servicios;
using Jardines2022.Servicios.Servicios.IServicios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Jardines2022.Web.Controllers
{
    public class ProveedoresController : Controller
    {
        private readonly IProveedorServicio servicio;
        public ProveedoresController(ProveedorServicio servicio)
        {
            this.servicio = servicio;
        }
        // GET: Proveedores
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult ListarProveedores()
        {
            var lista = servicio.GetLista();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Guardar(string objeto)
        {
            object resultado = null;
            string mensaje = string.Empty;
            try
            {
                Proveedor proveedorRecibido = new Proveedor();
                proveedorRecibido = JsonConvert.DeserializeObject<Proveedor>(objeto);
                mensaje = Validar(proveedorRecibido);
                if (mensaje==String.Empty)
                {
                    if (!servicio.Existe(proveedorRecibido))
                    {
                        servicio.Guardar(proveedorRecibido);
                        resultado = proveedorRecibido.ProveedorId;
                        mensaje = "Proveedor agregado/editado con exito!";
                    }
                    else
                    {
                        resultado = 0;
                        mensaje = "Error - Proveedor existente!";
                    }
                }
                else
                {
                    resultado = 0;
                }
            }
            catch (Exception e)
            {
                resultado = 0;
                mensaje = e.Message;
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Eliminar(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            try
            {
                Proveedor p = servicio.GetProveedorPorId(id);
                servicio.Borrar(p);
                respuesta = true;
                mensaje = "Registro eliminado de fomra Exitosa!";
            }
            catch (Exception e)
            {
                respuesta = false;
                mensaje = e.Message;
            }
            return Json(new { respuesta = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        private string Validar(Proveedor proveedor)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(proveedor.NombreProveedor))
            {
                sb.AppendLine("Debe de ingresar el nombre del Proveedor." + Environment.NewLine);
            }
            if (string.IsNullOrEmpty(proveedor.Direccion))
            {
                sb.AppendLine("Debe de ingresar la dirección" + Environment.NewLine);
            }
            if (string.IsNullOrEmpty(proveedor.CodigoPostal))
            {
                sb.AppendLine("Debe de ingresar el codigo postal." + Environment.NewLine);
            }
            if (proveedor.PaisId==0)
            {
                sb.AppendLine("Debe seleccionar de que país es el proveedor." + Environment.NewLine);
            }
            if (proveedor.CiudadId==0)
            {
                sb.AppendLine("Debe seleccionar la ciudad del proveedor." + Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}