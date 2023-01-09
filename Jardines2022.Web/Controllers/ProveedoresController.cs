using Jardines2022.Servicios.Servicios;
using Jardines2022.Servicios.Servicios.IServicios;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}