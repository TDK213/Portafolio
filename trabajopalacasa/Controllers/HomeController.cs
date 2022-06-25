using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using trabajopalacasa.Models;
using trabajopalacasa.Models.ViewModels;

namespace trabajopalacasa.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ListaSolicitud()
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
                                 Remitente = a.nom_usuario
  
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
            return Redirect(Url.Content("~/Home/"));
        }
        public ActionResult EditarSoli(int Id)
        {
            EditarSolicitud model = new EditarSolicitud();
            using (var db = new pruebaEntities())
            {
                var oSoli = db.solicitud.Find(Id);
                model.Titulo = oSoli.titulo;
                model.Tipo_solicitud = oSoli.tipo_solicitud;
                model.Mensaje = oSoli.mensaje;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult EditarSoli(EditarSolicitud model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }

            using (var db = new pruebaEntities())
            {
                var oSoli = db.solicitud.Find(model.Id);
                oSoli.titulo = model.Titulo;
                oSoli.tipo_solicitud = model.Tipo_solicitud;
                oSoli.mensaje = model.Mensaje;

                db.Entry(oSoli).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            return Redirect(Url.Content("~/Home/"));

        }
        [HttpPost]
        public ActionResult Borrar(int Id)
        {

            using (var db = new pruebaEntities())
            {
                var oSoli = db.solicitud.Find(Id);

                db.Entry(oSoli).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();

            }

            return Content("1");

        }
        [HttpPost]
        public ActionResult Borrar2(int Id)
        {

            using (var db = new pruebaEntities())
            {
                var oSoli = db.solicitud.Find(Id);
                oSoli.estado = "Denegado";


                db.Entry(oSoli).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            return Content("1");

        }
        public ActionResult MostrarSoli(int Id)
        {
            EditarSolicitud model = new EditarSolicitud();
            using (var db = new pruebaEntities())
            {
                var oSoli = db.solicitud.Find(Id);
                model.Titulo = oSoli.titulo;
                model.Tipo_solicitud = oSoli.tipo_solicitud;
                model.Mensaje = oSoli.mensaje;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult MostrarSoli(MostrarSolicitud model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }

            using (var db = new pruebaEntities())
            {
                var oSoli = db.solicitud.Find(model.Id);
                oSoli.titulo = model.Titulo;
                oSoli.tipo_solicitud = model.Tipo_solicitud;
                oSoli.fecha = model.Fecha;
                oSoli.mensaje = model.Mensaje;

                db.Entry(oSoli).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            return Redirect(Url.Content("~/Home/"));

        }
    }
}



