using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Contexto;
using MVC.Entidades;

namespace MVC.Controllers
{
    public class FacturaDetallesController : Controller
    {
        private ModeloContexto db = new ModeloContexto();

        // GET: FacturaDetalles
        public ActionResult Index(int facturaId)
        {
            ViewBag.FacturaId = facturaId;
            var facturaDetalles = db.FacturaDetalles.Include(f => f.Facturas).Include(f => f.OrdenEntradas).Where(f => f.FacturaId == facturaId).OrderBy(f => f.FacturaDetalleId).ToList();
            return PartialView("_Index", facturaDetalles);
        }

        // GET: FacturaDetalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaDetalle facturaDetalle = db.FacturaDetalles.Find(id);
            if (facturaDetalle == null)
            {
                return HttpNotFound();
            }
            return View(facturaDetalle);
        }

        // GET: FacturaDetalles/Create
        public ActionResult Create(int facturaId)
        {
            ViewBag.FacturaId = facturaId;
            ViewBag.OrdenEntradaId = new SelectList(db.OrdenEntradas, "OrdenEntradaId", "DescripcionTecnica");

            FacturaDetalle nuevaFacturaDetalle = new FacturaDetalle();
            nuevaFacturaDetalle.FacturaId = facturaId;
            return PartialView("_Create", nuevaFacturaDetalle);
        }

        // POST: FacturaDetalles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacturaDetalleId,FacturaId,OrdenEntradaId,Descripcion,Precio,DateCreation,DateModification,Control")] FacturaDetalle facturaDetalle)
        {
            if (ModelState.IsValid)
            {
                db.FacturaDetalles.Add(facturaDetalle);
                db.SaveChanges();
                return Json(new { success = true });
            }

            ViewBag.FacturaId = new SelectList(db.Facturas, "FacturaId", "FacturaId", facturaDetalle.FacturaId);
            ViewBag.OrdenEntradaId = new SelectList(db.OrdenEntradas, "OrdenEntradaId", "DescripcionTecnica", facturaDetalle.OrdenEntradaId);
            return View(facturaDetalle);
        }

        // GET: FacturaDetalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaDetalle facturaDetalle = db.FacturaDetalles.Find(id);
            if (facturaDetalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacturaId = new SelectList(db.Facturas, "FacturaId", "FacturaId", facturaDetalle.FacturaId);
            ViewBag.OrdenEntradaId = new SelectList(db.OrdenEntradas, "OrdenEntradaId", "DescripcionTecnica", facturaDetalle.OrdenEntradaId);
            return View(facturaDetalle);
        }

        // POST: FacturaDetalles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacturaDetalleId,FacturaId,OrdenEntradaId,Descripcion,Precio,DateCreation,DateModification,Control")] FacturaDetalle facturaDetalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facturaDetalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FacturaId = new SelectList(db.Facturas, "FacturaId", "FacturaId", facturaDetalle.FacturaId);
            ViewBag.OrdenEntradaId = new SelectList(db.OrdenEntradas, "OrdenEntradaId", "DescripcionTecnica", facturaDetalle.OrdenEntradaId);
            return View(facturaDetalle);
        }

        // GET: FacturaDetalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaDetalle facturaDetalle = db.FacturaDetalles.Find(id);
            if (facturaDetalle == null)
            {
                return HttpNotFound();
            }
            return View(facturaDetalle);
        }

        // POST: FacturaDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FacturaDetalle facturaDetalle = db.FacturaDetalles.Find(id);
            db.FacturaDetalles.Remove(facturaDetalle);
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
