using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pipo_Pipon.Models;

namespace Pipo_Pipon.Controllers
{
    public class ComidasController : Controller
    {
        private pipopiponEntities db = new pipopiponEntities();

        // GET: Comidas
        public ActionResult Index()
        {
            return View(db.Comidas.ToList());
        }

        // GET: Comidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comida comida = db.Comidas.Find(id);
            if (comida == null)
            {
                return HttpNotFound();
            }
            return View(comida);
        }

        // GET: Comidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "itemId,comidaNombre,comidaPrecio,cantidad")] Comida comida)
        {
            if (ModelState.IsValid)
            {
                db.Comidas.Add(comida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comida);
        }

        // GET: Comidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comida comida = db.Comidas.Find(id);
            if (comida == null)
            {
                return HttpNotFound();
            }
            return View(comida);
        }

        // POST: Comidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "itemId,comidaNombre,comidaPrecio,cantidad")] Comida comida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comida);
        }

        // GET: Comidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comida comida = db.Comidas.Find(id);
            if (comida == null)
            {
                return HttpNotFound();
            }
            return View(comida);
        }

        // POST: Comidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comida comida = db.Comidas.Find(id);
            db.Comidas.Remove(comida);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
