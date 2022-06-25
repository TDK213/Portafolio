using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using trabajopalacasa.Models;
using trabajopalacasa.Models.ViewModels;

namespace trabajopalacasa.Controllers
{
    public class SolicitanteController : Controller
    {
        // GET: Solicitante
        public ActionResult Index()
        {
            List<SoliViewModels> lst = null;
            using (pruebaEntities db = new pruebaEntities())
            {
                lst = (from d in db.solicitud
                       from a in db.usuario
                       where d.id_usuario == a.id
                       where d.estado == "Activo"
                       orderby d.id
                       select new SoliViewModels
                       {
                           Id = d.id,
                           Titulo = d.titulo,
                           Tipo_solicitud = d.tipo_solicitud,
                           Estado = d.estado,
                           Fecha = (DateTime)d.fecha

                       }).ToList();
            }
            return View(lst);
        }
        public ActionResult NuevaSoli()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NuevaSoli(NuevaSolicitud model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new pruebaEntities())
            {
                solicitud oSoli = new solicitud();

                oSoli.id_usuario = 1;
                oSoli.titulo = model.Titulo;
                oSoli.tipo_solicitud = model.Tipo_solicitud;
                oSoli.mensaje = model.Mensaje;
                oSoli.fecha = DateTime.Now;
                oSoli.estado = "Activo";

                db.solicitud.Add(oSoli);
                db.SaveChanges();

            }
            return Redirect(Url.Content("~/Solicitante/"));
        }
    }
}