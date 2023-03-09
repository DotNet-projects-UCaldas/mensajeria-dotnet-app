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
    public class TipoTransporteController : Controller
    {
        private mensajeriaDBEntities db = new mensajeriaDBEntities();

        // GET: TipoTransporte
        public ActionResult Index()
        {
            return View(db.tipoTransporte.ToList());
        }

        // GET: TipoTransporte/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoTransporte tipoTransporte = db.tipoTransporte.Find(id);
            if (tipoTransporte == null)
            {
                return HttpNotFound();
            }
            return View(tipoTransporte);
        }

        // GET: TipoTransporte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoTransporte/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] tipoTransporte tipoTransporte)
        {
            if (ModelState.IsValid)
            {
                db.tipoTransporte.Add(tipoTransporte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoTransporte);
        }

        // GET: TipoTransporte/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoTransporte tipoTransporte = db.tipoTransporte.Find(id);
            if (tipoTransporte == null)
            {
                return HttpNotFound();
            }
            return View(tipoTransporte);
        }

        // POST: TipoTransporte/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] tipoTransporte tipoTransporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoTransporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoTransporte);
        }

        // GET: TipoTransporte/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoTransporte tipoTransporte = db.tipoTransporte.Find(id);
            if (tipoTransporte == null)
            {
                return HttpNotFound();
            }
            return View(tipoTransporte);
        }

        // POST: TipoTransporte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tipoTransporte tipoTransporte = db.tipoTransporte.Find(id);
            db.tipoTransporte.Remove(tipoTransporte);
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
