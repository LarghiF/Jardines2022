using AutoMapper;
using Jardines2022.Entidades.Entidades;
using Jardines2022.Servicios.Servicios;
using Jardines2022.Servicios.Servicios.IServicios;
using Jardines2022.Web.App_Start;
using Jardines2022.Web.Models.Ciudad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult Index()
        {
            var lista = servicio.GetLista();
            var listVm = mapper.Map<List<CiudadListVm>>(lista);
            return View(listVm);

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
    }
}