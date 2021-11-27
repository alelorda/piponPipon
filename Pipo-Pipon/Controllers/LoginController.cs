using Pipo_Pipon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pipo_Pipon.Controllers
{
    public class LoginController : Controller
    {

        /* public ActionResult Index()
         {

             return View("Login");   
         }*/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario objUser)
        {
            if (ModelState.IsValid)
            {
                using (pipopiponEntities db = new pipopiponEntities())
                {
                    var obj = db.Usuarios.Where(a => a.username.Equals(objUser.username) && a.password.Equals(objUser.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.id_usuario.ToString();
                        Session["UserName"] = obj.username.ToString();
                        return RedirectToAction("Index","OrdenDetalles", "OrdenDetalles");
                    }
                }
            }
            return View(objUser);
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}


