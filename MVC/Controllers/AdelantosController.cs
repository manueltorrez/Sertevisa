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
    public class AdelantosController : Controller
    {
        private ModeloContexto db = new ModeloContexto();

        // GET: Adelantos
        public ActionResult Index()
        {
            var adelantos = db.Adelantos.Include(a => a.OrdenEntradas);
            return View(adelantos.ToList());
        }

        // GET: Adelantos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adelanto adelanto = db.Adelantos.Find(id);
            if (adelanto == null)
            {
                return HttpNotFound();
            }
            return View(adelanto);
        }

        // GET: Adelantos/Create
        public ActionResult Create()
        {
            ViewBag.OrdenEntradaId = new SelectList(db.OrdenEntradas, "OrdenEntradaId", "NumeroSerie");
            return View();
        }

        // POST: Adelantos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdelantoId,OrdenEntradaId,Moneda,Valor,TasaCambio,DateCreation,DateModification,Control")] Adelanto adelanto)
        {
            if (ModelState.IsValid)
            {
                db.Adelantos.Add(adelanto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrdenEntradaId = new SelectList(db.OrdenEntradas, "OrdenEntradaId", "NumeroSerie", adelanto.OrdenEntradaId);
            return View(adelanto);
        }

        // GET: Adelantos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adelanto adelanto = db.Adelantos.Find(id);
            if (adelanto == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrdenEntradaId = new SelectList(db.OrdenEntradas, "OrdenEntradaId", "NumeroSerie", adelanto.OrdenEntradaId);
            return View(adelanto);
        }

        // POST: Adelantos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdelantoId,OrdenEntradaId,Moneda,Valor,TasaCambio,DateCreation,DateModification,Control")] Adelanto adelanto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adelanto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrdenEntradaId = new SelectList(db.OrdenEntradas, "OrdenEntradaId", "NumeroSerie", adelanto.OrdenEntradaId);
            return View(adelanto);
        }

        // GET: Adelantos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adelanto adelanto = db.Adelantos.Find(id);
            if (adelanto == null)
            {
                return HttpNotFound();
            }
            return View(adelanto);
        }

        // POST: Adelantos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adelanto adelanto = db.Adelantos.Find(id);
            db.Adelantos.Remove(adelanto);
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
