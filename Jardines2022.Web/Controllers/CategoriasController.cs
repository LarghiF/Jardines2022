using AutoMapper;
using Jardines2022.Entidades.Entidades;
using Jardines2022.Servicios.Servicios;
using Jardines2022.Servicios.Servicios.IServicios;
using Jardines2022.Web.App_Start;
using Jardines2022.Web.Models.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Jardines2022.Web.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaServicio servicio;
        private IMapper mapper;
        public CategoriasController(CategoriaServicio servicio)
        {
            this.servicio = servicio;
            mapper = AutoMapperConfig.Mapper;
        }

        // GET: Categorias
        public ActionResult Index()
        {
            var lista = servicio.GetLista();
            return View(lista);
        }
        [HttpGet]
        public JsonResult ListarCategorias()
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
        public ActionResult Create(CategoriaListVm categoriaVm)
        {
            if (!ModelState.IsValid)
            {
                return View(categoriaVm);
            }
            Categoria categoria = mapper.Map<Categoria>(categoriaVm);
            try
            {
                if (servicio.Existe(categoria))
                {
                    ModelState.AddModelError(string.Empty, "Categoría esxistente.");
                    return View(categoriaVm);
                }
                servicio.Guardar(categoria);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(categoriaVm);
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
                Categoria categoria = servicio.GetCategoriaPorId(id.Value);
                if (categoria==null)
                {
                    return HttpNotFound("Categoría no encontrada.");
                }
                CategoriaEditVm categoriaEditVm = mapper.Map<CategoriaEditVm>(categoria);
                return View(categoriaEditVm);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriaEditVm categoriaEditVm)
        {
            if (!ModelState.IsValid)
            {
                return View(categoriaEditVm);
            }
            Categoria categoria = mapper.Map<Categoria>(categoriaEditVm);
            try
            {
                if (servicio.Existe(categoria))
                {
                    ModelState.AddModelError(string.Empty, "Categoría existente");
                    return View(categoriaEditVm);
                }
                servicio.Guardar(categoria);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(categoriaEditVm);
            }
        }
        [HttpGet]
        public ActionResult Borrar(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = servicio.GetCategoriaPorId(id.Value);
            if (categoria==null)
            {
                return HttpNotFound("Categoria no encontrada");
            }
            CategoriaEditVm categoriaEditVm = mapper.Map<CategoriaEditVm>(categoria);
            return View(categoriaEditVm);
        }
        [HttpPost,ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public ActionResult BorradoConfirmado(int id)
        {
            Categoria categoria = servicio.GetCategoriaPorId(id);
            try
            {
                servicio.Borrar(categoria);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                CategoriaEditVm categoriaEditVm = mapper.Map<CategoriaEditVm>(categoria);
                ModelState.AddModelError(string.Empty, e.Message);
                return View(categoriaEditVm);
            }
        }


    }
}