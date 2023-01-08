using Jardines2022.Servicios.Servicios;
using Jardines2022.Servicios.Servicios.IServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jardines2022.Web.Controllers
{
    public class ProductoController : Controller
    {
        private IProductoServicio servicio;
        public ProductoController(ProductoServicio servicio)
        {
            this.servicio = servicio;
        }
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult ListarProductos()
        {
            var lista = servicio.GetLista();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
    }
}