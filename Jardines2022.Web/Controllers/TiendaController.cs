using AutoMapper;
using Jardines2022.Entidades.Dtos;
using Jardines2022.Servicios.Servicios;
using Jardines2022.Servicios.Servicios.IServicios;
using Jardines2022.Web.App_Start;
using Jardines2022.Web.Models.Producto;
using System.Web.Mvc;
using Jardines2022.Entidades.Entidades;
using System.Collections.Generic;
using System.Linq;

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
            if (Session["Correo"]!=null)
            {
                if (((Usuario)Session["User"]).RolId==(Rol)1)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult GetData(int pag=1,int porPag = 10)
        {
            var data = servicio.GetLista();
            data = new List<Producto>();
            var result = new
            {
                ItemsTotales = data.Count,
                Items = data.Skip((pag - 1) * porPag).Take(porPag)
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ListarCategorias()
        {
            var lista = categoriaServicio.GetLista();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ListarProductos(int categoriaID,int porPag,int pag)
        {
            var lista = servicio.GetListaProductosPorCategorias(categoriaID);
            foreach (var producto in lista)
            {
                producto.Imagen = Helpers.HelperImagenes.Conversor(producto.Imagen);
            }
            var result = new
            {
                ItemsTotales = lista.Count,
                Items = lista.Skip((pag - 1) * porPag).Take(porPag)
            };
            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

            //var jsonResultado = Json(new { data = lista }, JsonRequestBehavior.AllowGet);
            //jsonResultado.MaxJsonLength = int.MaxValue;
            //return jsonResultado;
        }

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