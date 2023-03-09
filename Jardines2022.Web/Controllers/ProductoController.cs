using Jardines2022.Entidades.Entidades;
using Jardines2022.Servicios.Servicios;
using Jardines2022.Servicios.Servicios.IServicios;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Web.Mvc;

namespace Jardines2022.Web.Controllers
{
    public class ProductoController : Controller
    {
        private IProductoServicio servicio;
        private ICategoriaServicio categoriaServicio;
        public ProductoController(ProductoServicio servicio, CategoriaServicio categoriaServicio)
        {
            this.servicio = servicio;
            this.categoriaServicio = categoriaServicio;
        }
        // GET: Producto
        public ActionResult Index()
        {
            if (Session["Correo"]!=null)
            {
                if ((int)Session["Rol"]==1)
                {
                    return View();
                }
                return RedirectToAction("Tienda", "Tienda");
            }
            else
            {
                return RedirectToAction("Tienda", "Tienda");
            }
        }
        [HttpGet]
        public JsonResult ListarProductos()
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
                Producto productoRecibido = new Producto();
                productoRecibido = JsonConvert.DeserializeObject<Producto>(objeto);
                mensaje = Validar(productoRecibido);
                if (mensaje==String.Empty)
                {
                    if (!servicio.Existe(productoRecibido))
                    {
                        servicio.Guardar(productoRecibido);
                        resultado = productoRecibido.ProveedorId;
                        mensaje = "Producto agregado/editado con exito!";
                    }
                    else
                    {
                        resultado = 0;
                        mensaje = "Error - Producto existente!";
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

        private string Validar(Producto producto)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(producto.NombreProducto))
            {
                sb.AppendLine("El nombre del producto es requerido."+Environment.NewLine);
            }
            if (producto.ProveedorId==0)
            {
                sb.AppendLine("Debe seleccionar un proveedor." + Environment.NewLine);
            }
            if (producto.CategoriaId==0)
            {
                sb.AppendLine("Debe seleccionar una categoria." + Environment.NewLine);
            }

            if (producto.PrecioUnitario==0)
            {
                sb.AppendLine("Debe ingresar el precio." + Environment.NewLine);
            }

            if (producto.UnidadesEnStock==0)
            {
                sb.AppendLine("Debe ingresar la cantidad de unidades." + Environment.NewLine);
            }
            if (producto.NivelDeReposicion==0)
            {
                sb.AppendLine("Indique el nivel de reposición." + Environment.NewLine);
            }
            return sb.ToString();
        }
        [HttpPost]
        public JsonResult Eliminar(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            try
            {
                Producto p = servicio.GetProductoPorId(id);
                servicio.Borrar(p);
                respuesta = true;
                mensaje = "Registro eliminado de forma Exitosa!";
            }
            catch (Exception e)
            {
                respuesta = false;
                mensaje = e.Message;
            }
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

    }
}