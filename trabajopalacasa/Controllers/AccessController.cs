using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using trabajopalacasa.Models;

namespace trabajopalacasa.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string usuario, string clave)
        {
            try
            {
                using (pruebaEntities db = new pruebaEntities())
                {
                    var lst = from d in db.usuario
                              where d.correo_usuario == usuario && d.contrasena == clave
                              select d;
                    if (lst.Count() > 0)
                    {
                        usuario oUser = lst.First();
                        Session["User"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario Invalidao");
                    }
                }
            }catch (Exception ex)
            {
                return Content("Fallo" + ex.Message);
            }
        }
    }
}