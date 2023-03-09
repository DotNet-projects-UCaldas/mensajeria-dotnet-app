using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MensajeriaApp.entityFrameworkModels;

namespace MensajeriaApp.Controllers
{
    public class PaqueteController : Controller
    {
        private mensajeriaDBEntities db = new mensajeriaDBEntities();

        // GET: Paquete
        public ActionResult Index()
        {
            var paquete = db.paquete.Include(p => p.oficina);
            return View(paquete.ToList());
        }

        // GET: Paquete/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paquete paquete = db.paquete.Find(id);
            if (paquete == null)
            {
                return HttpNotFound();
            }
            return View(paquete);
        }

        // GET: Paquete/Create
        public ActionResult Create()
        {
            ViewBag.idOficina = new SelectList(db.oficina, "id", "nombre");
            return View();
        }

        // POST: Paquete/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,peso,altura,profundidad,ancho,idOficina")] paquete paquete)
        {
            if (ModelState.IsValid)
            {
                db.paquete.Add(paquete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idOficina = new SelectList(db.oficina, "id", "nombre", paquete.idOficina);
            return View(paquete);
        }

        // GET: Paquete/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paquete paquete = db.paquete.Find(id);
            if (paquete == null)
            {
                return HttpNotFound();
            }
            ViewBag.idOficina = new SelectList(db.oficina, "id", "nombre", paquete.idOficina);
            return View(paquete);
        }

        // POST: Paquete/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,peso,altura,profundidad,ancho,idOficina")] paquete paquete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paquete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idOficina = new SelectList(db.oficina, "id", "nombre", paquete.idOficina);
            return View(paquete);
        }

        // GET: Paquete/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paquete paquete = db.paquete.Find(id);
            if (paquete == null)
            {
                return HttpNotFound();
            }
            return View(paquete);
        }

        // POST: Paquete/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            paquete paquete = db.paquete.Find(id);
            db.paquete.Remove(paquete);
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
