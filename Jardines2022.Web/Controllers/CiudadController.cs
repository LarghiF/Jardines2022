using AutoMapper;
using Jardines2022.Entidades.Entidades;
using Jardines2022.Servicios.Servicios;
using Jardines2022.Servicios.Servicios.IServicios;
using Jardines2022.Web.App_Start;
using Jardines2022.Web.Models.Ciudad;
using PagedList;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace Jardines2022.Web.Controllers
{
    public class CiudadController : Controller
    {
        private readonly ICiudadServicio servicio;
        private readonly IPaisesServicio paisesServicio;
        private IMapper mapper;
        public CiudadController()
        {
            servicio = new CiudadServicio();
            paisesServicio = new PaisesServicio();
            mapper = AutoMapperConfig.Mapper;
        }
        // GET: Ciudad
        public ActionResult Index(int? pageSize,
            int? page)
        {
            page = (page ?? 1);
            ViewBag.CurrentItemsPerPage = pageSize ?? 10; // default 10
            var lista = servicio.GetLista();
            //var listaVm = mapper.Map<List<CiudadListVm>>(lista);
            return View(lista.ToPagedList((int)page, pageSize ?? 10));

        }
        [HttpGet]
        public JsonResult ListarCiudadesPorPais(int id)
        {
            var lista = servicio.GetCiudadesPorPais(id);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            CiudadEditVm ciudadEditVm = new CiudadEditVm()
            {
                Pais = paisesServicio.GetLista()
            };
            return View(ciudadEditVm);
        }
        [HttpPost]
        public ActionResult Create(CiudadEditVm ciudadEditVm)
        {
            if (!ModelState.IsValid)
            {
                ciudadEditVm.Pais = paisesServicio.GetLista();
                return View(ciudadEditVm);
            }
            try
            {
                var ciudad = mapper.Map<Ciudad>(ciudadEditVm);
                if (!servicio.Existe(ciudad))
                {
                    servicio.Guardar(ciudad);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Ciudad ya existente!");
                    ciudadEditVm.Pais = paisesServicio.GetLista();
                    return View(ciudadEditVm);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                ciudadEditVm.Pais = paisesServicio.GetLista();
                return View(ciudadEditVm);
            }
        }
        [HttpGet]
        public ActionResult Edit(int?id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudad c = servicio.GetCiudadPorId(id.Value);
            if (c==null)
            {
                return HttpNotFound("No se ha encontrado la ciudad o no existe!");
            }
            CiudadEditVm ciudadVm = mapper.Map<CiudadEditVm>(c);
            ciudadVm.Pais = paisesServicio.GetLista();
            return View(ciudadVm);
        }
        [HttpPost]
        public ActionResult Edit(CiudadEditVm ciudadVm)
        {
            if (!ModelState.IsValid)
            {
                return View(ciudadVm);
            }
            Ciudad ciudad = mapper.Map<Ciudad>(ciudadVm);
            try
            {
                if (servicio.Existe(ciudad))
                {
                    ModelState.AddModelError(string.Empty, "La ciudad ya existe");
                    return View(ciudadVm);
                }
                servicio.Guardar(ciudad);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(ciudadVm);
            }
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudad c = servicio.GetCiudadPorId(id.Value);
            if (c==null)
            {
                return HttpNotFound("No se ha encontrado la ciudad!");
            }
            CiudadListVm ciudadVm = mapper.Map<CiudadListVm>(c);
            return View(ciudadVm);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult BorradoConfirmado(int id)
        {
            Ciudad c = servicio.GetCiudadPorId(id);
            try
            {
                servicio.Borrar(c);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                CiudadEditVm ciudadEditVm = mapper.Map<CiudadEditVm>(c);
                ModelState.AddModelError(string.Empty, e.Message);
                return View(ciudadEditVm);
            }
        }
    }
}