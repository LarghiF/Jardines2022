using Jardines2022.Servicios.Servicios;
using Jardines2022.Servicios.Servicios.IServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jardines2022.Web.Controllers
{
    public class TiendaController : Controller
    {
        private IProductoServicio servicio;
        private ICategoriaServicio categoriaServicio;
        public TiendaController(ProductoServicio servicio, CategoriaServicio categoriaServicio)
        {
            this.servicio = servicio;
            this.categoriaServicio = categoriaServicio;
        }
        // GET: Tienda
        public ActionResult Tienda()
        {
            return View();
        }
        [HttpGet]
        public JsonResult ListarCategorias()
        {
            var lista = categoriaServicio.GetLista();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ListarProductos(int categoriaID)
        {
            var lista = servicio.GetListaProductosPorCategorias(categoriaID);
            var jsonResultado = Json(new { data = lista }, JsonRequestBehavior.AllowGet);
            jsonResultado.MaxJsonLength = int.MaxValue;
            return jsonResultado;
        }
    }
}