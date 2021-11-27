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
    public class OrdenDetallesController : Controller
    {
        private pipopiponEntities db = new pipopiponEntities();

        // GET: OrdenDetalles
        public ActionResult Index()
        {
            var ordenDetalles = db.OrdenDetalles.Include(o => o.Bebida).Include(o => o.Comida);
            return View(ordenDetalles.ToList());
        }

        // GET: OrdenDetalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenDetalle ordenDetalle = db.OrdenDetalles.Find(id);
            if (ordenDetalle == null)
            {
                return HttpNotFound();
            }
            return View(ordenDetalle);
        }

        // GET: OrdenDetalles/Create
        public ActionResult Create()
        {
            ViewBag.bebidaId = new SelectList(db.Bebidas, "bebidaId", "bebidaNombre");
            ViewBag.itemId = new SelectList(db.Comidas, "itemId", "comidaNombre");
            return View();
        }

        // POST: OrdenDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ordenDetalles,nombreCliente,itemId,bebidaId,unitPrice,total")] OrdenDetalle ordenDetalle)
        {
            if (ModelState.IsValid)
            {
                db.OrdenDetalles.Add(ordenDetalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bebidaId = new SelectList(db.Bebidas, "bebidaId", "bebidaNombre", ordenDetalle.bebidaId);
            ViewBag.itemId = new SelectList(db.Comidas, "itemId", "comidaNombre", ordenDetalle.itemId);
            return View(ordenDetalle);
        }

        // GET: OrdenDetalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenDetalle ordenDetalle = db.OrdenDetalles.Find(id);
            if (ordenDetalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.bebidaId = new SelectList(db.Bebidas, "bebidaId", "bebidaNombre", ordenDetalle.bebidaId);
            ViewBag.itemId = new SelectList(db.Comidas, "itemId", "comidaNombre", ordenDetalle.itemId);
            return View(ordenDetalle);
        }

        // POST: OrdenDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ordenDetalles,nombreCliente,itemId,bebidaId,unitPrice,total")] OrdenDetalle ordenDetalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenDetalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bebidaId = new SelectList(db.Bebidas, "bebidaId", "bebidaNombre", ordenDetalle.bebidaId);
            ViewBag.itemId = new SelectList(db.Comidas, "itemId", "comidaNombre", ordenDetalle.itemId);
            return View(ordenDetalle);
        }

        // GET: OrdenDetalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenDetalle ordenDetalle = db.OrdenDetalles.Find(id);
            if (ordenDetalle == null)
            {
                return HttpNotFound();
            }
            return View(ordenDetalle);
        }

        // POST: OrdenDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenDetalle ordenDetalle = db.OrdenDetalles.Find(id);
            db.OrdenDetalles.Remove(ordenDetalle);
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

        public ActionResult GenerarPdf(int id)
        {

            var report = new Rotativa.ActionAsPdf("Details", new { id = id });
            return report;
            //return new Rotativa.MVC.ActionAsPdf("Details");
        }
    }
}
