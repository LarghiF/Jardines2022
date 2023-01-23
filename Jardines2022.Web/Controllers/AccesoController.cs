using AutoMapper;
using Jardines2022.Entidades.Entidades;
using Jardines2022.Servicios.Servicios;
using Jardines2022.Servicios.Servicios.IServicios;
using Jardines2022.Web.App_Start;
using Jardines2022.Web.Helpers;
using Jardines2022.Web.Models.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Jardines2022.Web.Controllers
{
    public class AccesoController : Controller
    {
        private readonly IClienteServicio servicio;
        private readonly IPaisesServicio paisesServicio;
        private readonly ICiudadServicio ciudadServicio;
        private readonly IMapper mapper;
        public AccesoController(ClienteServicio servicio)
        {
            this.servicio=servicio;
            paisesServicio = new PaisesServicio();
            ciudadServicio = new CiudadServicio();
            this.mapper = AutoMapperConfig.Mapper;
        }
        // GET: Acceso
        public ActionResult LogIn()
        {
            return View();
        }
        public ActionResult Registrarse()
        {
            var lista = servicio.GetLista();
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(string correo,string clave)
        {
            try
            {
                var claveEncriptada = HelperCliente.Encriptar(clave);
                Cliente cliente = servicio.GetClientePorCorreoYClave(correo, claveEncriptada);
                if (cliente==null)
                {
                    ViewBag.Error = "Error el usuario o la clave no coinciden";
                    return View();
                }
                else
                {
                    if (cliente.restablecer)
                    {
                        TempData["clienteId"] = cliente.ClienteId;
                        return RedirectToAction("CambiarClave");
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(cliente.correo, false);
                        Session["clienteId"] = cliente;
                        TempData["clienteId"] = null;
                        ViewBag.Error = null;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPost]
        public ActionResult Registrarse(ClienteEditVm clienteEditVm)
        {
            if (!ModelState.IsValid)
            {
                return View(clienteEditVm);
            }
            ViewData["Nombre"] = clienteEditVm.Nombre;
            ViewData["Apellido"] = clienteEditVm.Apellido;
            ViewData["Correo"] = clienteEditVm.Correo;
            try
            {
                if (clienteEditVm.Clave!=clienteEditVm.ConfirmarClave)
                {
                    ViewBag.Error = "Clave erronea!";
                    return View(clienteEditVm);
                }
                Cliente c = mapper.Map<Cliente>(clienteEditVm);
                if (servicio.ExisteCliente(c))
                {
                    ViewBag.Error = "Ya se encuentra registrado!";
                    return View(clienteEditVm);
                }
                if (servicio.ExisteCorreo(c.correo))
                {
                    ViewBag.Error = "Ya se encuentra registrado!";
                    return View(clienteEditVm);
                }
                c.clave = HelperCliente.Encriptar(c.clave);
                servicio.Guardar(c);
                ViewData["Nombre"] = null;
                ViewData["Apellido"] = null;
                ViewData["Correo"] = null;

                return RedirectToAction("LogIn");

            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(clienteEditVm);
            }
        }
    }
}