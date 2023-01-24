using AutoMapper;
using Jardines2022.Entidades.Entidades;
using Jardines2022.Servicios.Servicios.IServicios;
using Jardines2022.Web.App_Start;
using Jardines2022.Web.Helpers;
using Jardines2022.Web.Models.Usuario;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace Jardines2022.Web.Controllers
{
    public class AccesoController : Controller
    {
        private readonly IUsuarioServicio servicio;
        private readonly IMapper mapper;
        public AccesoController(UsuarioServicio servicio)
        {
            this.servicio=servicio;
            this.mapper = AutoMapperConfig.Mapper;
        }
        // GET: Acceso
        public ActionResult LogIn()
        {
            return View();
        }
        public ActionResult Registrarse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(string correo,string clave)
        {
            try
            {
                var claveEncriptada = HelperCliente.Encriptar(clave);
                Usuario usuario = servicio.GetUsuarioCorreoYClave(correo, claveEncriptada);
                if (usuario==null)
                {
                    ViewBag.Error = "Error el usuario o la clave no coinciden";
                    return View();
                }
                else
                {
                    if (usuario.Restablecer)
                    {
                        TempData["UsuarioId"] = usuario.UsuarioId;
                        return RedirectToAction("CambiarClave");
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(usuario.Correo, false);
                        Session["UsuarioId"] = usuario;
                        TempData["UsuarioId"] = null;
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
        public ActionResult Registrarse(UsuarioEditVm usuarioEditVm)
        {
            if (!ModelState.IsValid)
            {
                return View(usuarioEditVm);
            }
            ViewData["Correo"] = usuarioEditVm.Correo;
            try
            {
                if (usuarioEditVm.Clave!= usuarioEditVm.ConfirmarClave)
                {
                    ViewBag.Error = "Clave erronea!";
                    return View(usuarioEditVm);
                }
                Usuario usuario = mapper.Map<Usuario>(usuarioEditVm);
                if (servicio.ExisteCorreo(usuario.Correo))
                {
                    ViewBag.Error = "Ya se encuentra registrado!";
                    return View(usuarioEditVm);
                }
                usuario.Clave = HelperCliente.Encriptar(usuario.Clave);
                string asunto = "Registro Exitoso";
                string mensaje = $"<h3>Se ha registrado exitosamente en Jardines Verdes<h3><br/><p>Gracias por elegirnos</p>";
                bool respuesta = HelperCliente.EnviarCorreo(usuario.Correo, asunto, mensaje);
                servicio.Guardar(usuario);
                ViewData["Correo"] = null;
                return RedirectToAction("LogIn");

            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(usuarioEditVm);
            }
        }
    }
}