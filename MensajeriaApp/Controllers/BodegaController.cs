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
    public class BodegaController : Controller
    {
        private mensajeriaDBEntities db = new mensajeriaDBEntities();

        // GET: Bodega
        public ActionResult Index()
        {
            var bodega = db.bodega.Include(b => b.municipio);
            return View(bodega.ToList());
        }

        // GET: Bodega/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bodega bodega = db.bodega.Find(id);
            if (bodega == null)
            {
                return HttpNotFound();
            }
            return View(bodega);
        }

        // GET: Bodega/Create
        public ActionResult Create()
        {
            ViewBag.idMunicipio = new SelectList(db.municipio, "id", "nombre");
            return View();
        }

        // POST: Bodega/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,codigo,direccion,latitud,longitud,idMunicipio")] bodega bodega)
        {
            if (ModelState.IsValid)
            {
                db.bodega.Add(bodega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMunicipio = new SelectList(db.municipio, "id", "nombre", bodega.idMunicipio);
            return View(bodega);
        }

        // GET: Bodega/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bodega bodega = db.bodega.Find(id);
            if (bodega == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMunicipio = new SelectList(db.municipio, "id", "nombre", bodega.idMunicipio);
            return View(bodega);
        }

        // POST: Bodega/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,codigo,direccion,latitud,longitud,idMunicipio")] bodega bodega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bodega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMunicipio = new SelectList(db.municipio, "id", "nombre", bodega.idMunicipio);
            return View(bodega);
        }

        // GET: Bodega/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bodega bodega = db.bodega.Find(id);
            if (bodega == null)
            {
                return HttpNotFound();
            }
            return View(bodega);
        }

        // POST: Bodega/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            bodega bodega = db.bodega.Find(id);
            db.bodega.Remove(bodega);
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
