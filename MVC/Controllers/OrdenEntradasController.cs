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
    public class OrdenEntradasController : Controller
    {
        private ModeloContexto db = new ModeloContexto();

        // GET: OrdenEntradas
        public ActionResult Index()
        {
            var ordenEntradas = db.OrdenEntradas.Include(o => o.Clientes).Include(o => o.Equipos).Include(o => o.Estado);
            return View(ordenEntradas.ToList());
        }

        // GET: OrdenEntradas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenEntrada ordenEntrada = db.OrdenEntradas.Find(id);
            if (ordenEntrada == null)
            {
                return HttpNotFound();
            }
            return View(ordenEntrada);
        }

        // GET: OrdenEntradas/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre1");
            ViewBag.EquipoId = new SelectList(db.Equipoes, "EquipoId", "Modelo");
            ViewBag.EstadoId = new SelectList(db.Estados, "ID", "Descripcion");
            return View();
        }

        // POST: OrdenEntradas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrdenEntradaId,ClienteId,EquipoId,EstadoId, Activo, NumeroSerie,Descripcion,FechaIngreso,DateCreation,DateModification,Control")] OrdenEntrada ordenEntrada)
        {
            if (ModelState.IsValid)
            {
                db.OrdenEntradas.Add(ordenEntrada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre1", ordenEntrada.ClienteId);
            ViewBag.EquipoId = new SelectList(db.Equipoes, "EquipoId", "Modelo", ordenEntrada.EquipoId);
            ViewBag.EstadoId = new SelectList(db.Estados, "ID", "Descripcion", ordenEntrada.EstadoId);
            return View(ordenEntrada);
        }

        // GET: OrdenEntradas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenEntrada ordenEntrada = db.OrdenEntradas.Find(id);
            if (ordenEntrada == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre1", ordenEntrada.ClienteId);
            ViewBag.EquipoId = new SelectList(db.Equipoes, "EquipoId", "Modelo", ordenEntrada.EquipoId);
            ViewBag.EstadoId = new SelectList(db.Estados, "ID", "Descripcion", ordenEntrada.EstadoId);
            return View(ordenEntrada);
        }

        // POST: OrdenEntradas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrdenEntradaId,ClienteId,EquipoId,EstadoId,Activo,NumeroSerie,Descripcion,DescripcionTecnica,FechaIngreso,FechaEgreso,DateCreation,DateModification,Control")] OrdenEntrada ordenEntrada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenEntrada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombre1", ordenEntrada.ClienteId);
            ViewBag.EquipoId = new SelectList(db.Equipoes, "EquipoId", "Modelo", ordenEntrada.EquipoId);
            ViewBag.EstadoId = new SelectList(db.Estados, "ID", "Descripcion", ordenEntrada.EstadoId);
            return View(ordenEntrada);
        }

        // GET: OrdenEntradas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenEntrada ordenEntrada = db.OrdenEntradas.Find(id);
            if (ordenEntrada == null)
            {
                return HttpNotFound();
            }
            return View(ordenEntrada);
        }

        // POST: OrdenEntradas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenEntrada ordenEntrada = db.OrdenEntradas.Find(id);
            db.OrdenEntradas.Remove(ordenEntrada);
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
