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
    public class HistorialController : Controller
    {
        private mensajeriaDBEntities db = new mensajeriaDBEntities();

        // GET: Historial
        public ActionResult Index()
        {
            var historial = db.historial.Include(h => h.bodega).Include(h => h.paquete);
            return View(historial.ToList());
        }

        // GET: Historial/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historial historial = db.historial.Find(id);
            if (historial == null)
            {
                return HttpNotFound();
            }
            return View(historial);
        }

        // GET: Historial/Create
        public ActionResult Create()
        {
            ViewBag.idBodega = new SelectList(db.bodega, "id", "nombre");
            ViewBag.idPaquete = new SelectList(db.paquete, "id", "id");
            return View();
        }

        // POST: Historial/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fechaIngreso,fechaSalida,descripcion,idPaquete,idBodega")] historial historial)
        {
            if (ModelState.IsValid)
            {
                db.historial.Add(historial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idBodega = new SelectList(db.bodega, "id", "nombre", historial.idBodega);
            ViewBag.idPaquete = new SelectList(db.paquete, "id", "id", historial.idPaquete);
            return View(historial);
        }

        // GET: Historial/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historial historial = db.historial.Find(id);
            if (historial == null)
            {
                return HttpNotFound();
            }
            ViewBag.idBodega = new SelectList(db.bodega, "id", "nombre", historial.idBodega);
            ViewBag.idPaquete = new SelectList(db.paquete, "id", "id", historial.idPaquete);
            return View(historial);
        }

        // POST: Historial/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fechaIngreso,fechaSalida,descripcion,idPaquete,idBodega")] historial historial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBodega = new SelectList(db.bodega, "id", "nombre", historial.idBodega);
            ViewBag.idPaquete = new SelectList(db.paquete, "id", "id", historial.idPaquete);
            return View(historial);
        }

        // GET: Historial/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historial historial = db.historial.Find(id);
            if (historial == null)
            {
                return HttpNotFound();
            }
            return View(historial);
        }

        // POST: Historial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            historial historial = db.historial.Find(id);
            db.historial.Remove(historial);
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
