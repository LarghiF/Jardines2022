using AutoMapper;
using Jardines2022.Entidades.Entidades;
using Jardines2022.Servicios.Servicios;
using Jardines2022.Servicios.Servicios.IServicios;
using Jardines2022.Web.App_Start;
using Jardines2022.Web.Models.Carrito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jardines2022.Web.Controllers
{
    public class CarritoController : Controller
    {
        private readonly ICarritoServicio servicio;
        private readonly IMapper mapper;
        public CarritoController(CarritoServicio servicio)
        {
            this.servicio = servicio;
            mapper = AutoMapperConfig.Mapper;
        }
        // GET: Carrito
        public ActionResult Carrito()
        {
            var usuarioId = ((Usuario)Session["User"]).UsuarioId;
            try
            {
                var lista = servicio.ListaCarrito(usuarioId);
                var listaVm = mapper.Map<List<CarritoListVm>>(lista);
                return View(listaVm);
            }
            catch (Exception e)
            {
                TempData["Error"] = "Se ha producido un error!";
                return RedirectToAction("Tienda", "Tienda");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(int productoId,string returnURL)
        {
            var usuarioId = ((Usuario)Session["User"]).UsuarioId;
            try
            {
                servicio.AgregarAlCarrito(usuarioId, productoId, 1);
                TempData["msg"] = "Producto Agregado";
                return Redirect(returnURL);
            }
            catch (Exception e)
            {
                TempData["msg"] = "Se ha producido un error!";
                return Redirect(returnURL);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarMultiple(int productoId,int cantidad)
        {
            var usuarioId = ((Usuario)Session["User"]).UsuarioId;
            try
            {
                servicio.AgregarAlCarrito(usuarioId, productoId, cantidad);
                TempData["msg"] = "Producto Agregado";
                return RedirectToAction("Carrito");
            }
            catch (Exception e)
            {
                TempData["msg"] = e.Message;
                return RedirectToAction("Carrito");
            }
        }
        public ActionResult QuitarDelCarrito(int productoId)
        {
            var usuarioId = ((Usuario)Session["User"]).UsuarioId;
            try
            {
                servicio.Quitar(usuarioId, productoId);
                TempData["msg"] = "Se ha quitado del carrito";
                return RedirectToAction("Carrito");
            }
            catch (Exception e)
            {
                TempData["msg"] = "Se ha producido un error";
                return RedirectToAction("Carrito");
            }
        }
        public ActionResult CancelarCompra()
        {
            var usuarioId = ((Usuario)Session["User"]).UsuarioId;
            try
            {
                servicio.QuitarTodo(usuarioId);
                return RedirectToAction("Carrito");
            }
            catch (Exception e)
            {
                TempData["User"] = "Se ha producido un error!";
                return RedirectToAction("Carrito");
            }
        }
        [HttpPost]
        public JsonResult AgregarJson(int productoId)
        {
            bool rta = false;
            string msj = string.Empty;
            var usuarioId = ((Usuario)Session["User"]).UsuarioId;
            try
            {
                servicio.AgregarAlCarrito(usuarioId, productoId, 1);
                rta = true;
                msj = "Producto Agregado!";
            }
            catch (Exception e)
            {
                rta = false;
                msj = e.Message;
            }
            return Json(new { resultado = rta, mensaje = msj }, JsonRequestBehavior.AllowGet);
        }
    }
}