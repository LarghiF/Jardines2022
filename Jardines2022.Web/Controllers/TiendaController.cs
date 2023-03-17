using AutoMapper;
using Jardines2022.Entidades.Dtos;
using Jardines2022.Servicios.Servicios;
using Jardines2022.Servicios.Servicios.IServicios;
using Jardines2022.Web.App_Start;
using Jardines2022.Web.Models.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Jardines2022.Web.Helpers;

namespace Jardines2022.Web.Controllers
{
    public class TiendaController : Controller
    {
        private IProductoServicio servicio;
        private ICategoriaServicio categoriaServicio;
        private IMapper mapper;
        public TiendaController(ProductoServicio servicio, CategoriaServicio categoriaServicio)
        {
            this.servicio = servicio;
            this.categoriaServicio = categoriaServicio;
            mapper = AutoMapperConfig.Mapper;
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
            foreach (var producto in lista)
            {
                producto.Imagen = Helpers.HelperImagenes.Conversor(producto.Imagen);
            }
            var jsonResultado = Json(new { data = lista }, JsonRequestBehavior.AllowGet);
            jsonResultado.MaxJsonLength = int.MaxValue;
            return jsonResultado;
        }
        //private static string Conversor(string ruta)
        //{
        //    if (ruta==null)
        //    {
        //        ruta = "C:/Proyectos/Jardines2022FedericoL-master/Jardines2022.Web/Content/assets/img/Muestra/Imagen_no_disponible.png"; 
        //    }
        //    byte[] imgArray = System.IO.File.ReadAllBytes(ruta);
        //    string base64Imagen = Convert.ToBase64String(imgArray);
        //    return base64Imagen;
        //}

        [HttpGet]
        public ActionResult DetalleProducto(int productoID)
        {
            ProductoListDto p = mapper.Map<ProductoListDto>(servicio.GetProductoPorId(productoID));
            ProductoDetalleVm productoDetalleVm = mapper.Map<ProductoDetalleVm>(p);
            productoDetalleVm.Imagen = Helpers.HelperImagenes.Conversor(productoDetalleVm.Imagen);
            return View(productoDetalleVm);
        }


    }
}