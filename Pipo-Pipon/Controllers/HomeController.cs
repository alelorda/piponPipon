using Pipo_Pipon.Models;
using Pipo_Pipon.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pipo_Pipon.Controllers
{
    public class HomeController : Controller
    {
        private pipopiponEntities db;

        public HomeController()
        {
            db = new pipopiponEntities();

        }
       

        [HttpGet]
        public decimal getPrecioComida(int itemId)
        {
            decimal precioComida = db.Comidas.Single(model => model.itemId == itemId).comidaPrecio;

            return precioComida;
        }

        [HttpGet]
        public decimal getPrecioBebida(int itemId)
        {
            decimal precioBebida = db.Bebidas.Single(model => model.bebidaId == itemId).bebidaPrecio;

            return precioBebida;
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
    }
}