using AutoMapper;
using Jardines2022.Entidades.Entidades;
using Jardines2022.Servicios.Servicios;
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
        private readonly IPersonaServicio servicioPersona;
        private readonly IMapper mapper;
        public AccesoController(UsuarioServicio servicio, PersonaServicio servicioPersona)
        {
            this.servicio=servicio;
            this.servicioPersona=servicioPersona;
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
                        TempData["UserID"] = usuario.UsuarioId;
                        return RedirectToAction("CambiarClave");
                    }
                    else
                    {
                        Persona p = servicioPersona.GetPorUID(usuario.UsuarioId);
                        if (p==null)
                        {
                            FormsAuthentication.SetAuthCookie(usuario.Correo, false);
                            Session["User"] = usuario;
                            Session["Correo"] = usuario.Correo;
                            ViewBag.Error = null;
                            return RedirectToAction("Index", "Home");
                        }
                        FormsAuthentication.SetAuthCookie(usuario.Correo, false);
                        Session["User"] = usuario;
                        Session["Correo"] = usuario.Correo;
                        Session["Nombre"] = p.Nombre;
                        Session["Apellido"] = p.Apellido;
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
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session["User"] = null;
            Session["Correo"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RecuperarCuenta()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RecuperarCuenta(string correo)
        {
            try
            {
                Usuario user = servicio.GetUsuarioPorCorreo(correo);
                if (user==null)
                {
                    ViewBag.Eror="Correo mal ingresado o inexistente!";
                    return View();
                }
                user.Restablecer = true;
                string clave = HelperCliente.GenerarClave();

                string asunto = "Recuperar cuenta";
                string mensaje = $"<h3>Le recomendamos cambiar la contraseña para mayor seguridad</h3><br/><p>Utilice esta contraseña: '{clave}' para poder ingresar a su cuenta</p>";
                bool respuesta = HelperCliente.EnviarCorreo(user.Correo, asunto, mensaje);
                if (respuesta)
                {
                    try
                    {
                        user.Clave = HelperCliente.Encriptar(clave);
                        servicio.Guardar(user);
                        return RedirectToAction("LogIn", "Acceso");
                    }
                    catch (Exception e)
                    {
                        ViewBag.Error = e.Message;
                        return View();
                    }
                }
                else
                {
                    ViewBag.Error = "Lo sentimos. No se ha podido enviar el correo!";
                    return View();
                }
            } 
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }
        public ActionResult CambiarClave()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CambiarClave(string ID, string clave,string nuevaClave,string confirmarClave)
        {
            try
            {
                Usuario u = servicio.GetPorID(int.Parse(ID));
                if (u.Clave!=HelperCliente.Encriptar(clave))
                {
                    ViewBag.Error = "Clave erronea!";
                    return View();
                }
                else if(nuevaClave!=confirmarClave)
                {
                    TempData["UserID"] = u.UsuarioId;
                    ViewData["vData"] = clave;
                    ViewBag.Error = "No coincide la nueva contraseña con la confirmación";
                    return View();
                }
                u.Clave = HelperCliente.Encriptar(nuevaClave);
                u.Restablecer = false;
                servicio.Guardar(u);
                TempData["UserID"] = null;
                return RedirectToAction("LogIn");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

    }
}