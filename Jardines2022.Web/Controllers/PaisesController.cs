using AutoMapper;
using Jardines2022.Entidades.Entidades;
using Jardines2022.Servicios.Servicios;
using Jardines2022.Servicios.Servicios.IServicios;
using Jardines2022.Web.App_Start;
using Jardines2022.Web.Models.Paises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Jardines2022.Web.Controllers
{
    public class PaisesController : Controller
    {
        private readonly IPaisesServicio servicio;
        private IMapper mapper;
        public PaisesController()
        {
            servicio = new PaisesServicio();    
            mapper = AutoMapperConfig.Mapper;
        }
        // GET: Paises
        public ActionResult Index()
        {
            if (Session["Correo"] != null)
            {
                if ((int)Session["Rol"] == 1)
                {
                    var lista = servicio.GetLista();
                    return View(lista);
                }
                return RedirectToAction("Tienda", "Tienda");
            }
            else
            {
                return RedirectToAction("Tienda", "Tienda");
            }
        }
        [HttpGet]
        public JsonResult ListarPaises()
        {
            var lista = servicio.GetLista();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaisListVm paisVm)
        {
            if (!ModelState.IsValid)
            {
                return View(paisVm);
            }

            Pais pais = mapper.Map<Pais>(paisVm);
            try
            {
                if (servicio.Existe(pais))
                {
                    ModelState.AddModelError(string.Empty, "País repetido!!!");
                    return View(paisVm);
                }

                servicio.Guardar(pais);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(paisVm);
            }
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                Pais pais = servicio.GetPaisPorId(id.Value);
                if (pais==null)
                {
                    return HttpNotFound("No se ha podido encontrar el país o no existe.");
                }
                PaisEditVm paisVm = mapper.Map<PaisEditVm>(pais);
                return View(paisVm);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PaisEditVm paisVm)
        {
            if (!ModelState.IsValid)
            {
                return View(paisVm);
            }

            Pais pais = mapper.Map<Pais>(paisVm);
            try
            {
                if (servicio.Existe(pais))
                {
                    ModelState.AddModelError(string.Empty, "País existente!!!");
                    return View(paisVm);
                }
                servicio.Guardar(pais);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(paisVm);
            }
        }
        [HttpGet]
        public ActionResult Borrar(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pais pais = servicio.GetPaisPorId(id.Value);
            if (pais==null)
            {
                return HttpNotFound("No se ha podido encontrar el país o no existe.");
            }
            PaisEditVm paisVm = mapper.Map<PaisEditVm>(pais);
            return View(paisVm);
        }
        [HttpPost,ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public ActionResult BorradoConfirmado(int id)
        {
            Pais pais = servicio.GetPaisPorId(id);
            try
            {
                //if (servicio.EstaRelacionado(pais))
                //{
                //    PaisEditVm paisVm = mapper.Map<PaisEditVm>(pais);
                //    ModelState.AddModelError(string.Empty, "País relacionado, no se puede borrar.");
                //    return View(paisVm);
                //}
                servicio.Borrar(pais);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                PaisEditVm paisVm = mapper.Map<PaisEditVm>(pais);
                ModelState.AddModelError(string.Empty, e.Message);
                return View(paisVm);
            }
        }

    }
}