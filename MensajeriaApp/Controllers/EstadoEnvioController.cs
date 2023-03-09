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
    public class EstadoEnvioController : Controller
    {
        private mensajeriaDBEntities db = new mensajeriaDBEntities();

        // GET: EstadoEnvio
        public ActionResult Index()
        {
            return View(db.estadoEnvio.ToList());
        }

        // GET: EstadoEnvio/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estadoEnvio estadoEnvio = db.estadoEnvio.Find(id);
            if (estadoEnvio == null)
            {
                return HttpNotFound();
            }
            return View(estadoEnvio);
        }

        // GET: EstadoEnvio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoEnvio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] estadoEnvio estadoEnvio)
        {
            if (ModelState.IsValid)
            {
                db.estadoEnvio.Add(estadoEnvio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoEnvio);
        }

        // GET: EstadoEnvio/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estadoEnvio estadoEnvio = db.estadoEnvio.Find(id);
            if (estadoEnvio == null)
            {
                return HttpNotFound();
            }
            return View(estadoEnvio);
        }

        // POST: EstadoEnvio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] estadoEnvio estadoEnvio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoEnvio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoEnvio);
        }

        // GET: EstadoEnvio/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estadoEnvio estadoEnvio = db.estadoEnvio.Find(id);
            if (estadoEnvio == null)
            {
                return HttpNotFound();
            }
            return View(estadoEnvio);
        }

        // POST: EstadoEnvio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            estadoEnvio estadoEnvio = db.estadoEnvio.Find(id);
            db.estadoEnvio.Remove(estadoEnvio);
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
