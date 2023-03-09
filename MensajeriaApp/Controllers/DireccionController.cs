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
    public class DireccionController : Controller
    {
        private mensajeriaDBEntities db = new mensajeriaDBEntities();

        // GET: Direccion
        public ActionResult Index()
        {
            var direccion = db.direccion.Include(d => d.municipio).Include(d => d.persona1);
            return View(direccion.ToList());
        }

        // GET: Direccion/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            direccion direccion = db.direccion.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // GET: Direccion/Create
        public ActionResult Create()
        {
            ViewBag.idMunicipio = new SelectList(db.municipio, "id", "nombre");
            ViewBag.idPersona = new SelectList(db.persona, "id", "primerNombre");
            return View();
        }

        // POST: Direccion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tipoCalle,numero,tipoInmueble,barrio,observaciones,idMunicipio,idPersona,actual")] direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.direccion.Add(direccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMunicipio = new SelectList(db.municipio, "id", "nombre", direccion.idMunicipio);
            ViewBag.idPersona = new SelectList(db.persona, "id", "primerNombre", direccion.idPersona);
            return View(direccion);
        }

        // GET: Direccion/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            direccion direccion = db.direccion.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMunicipio = new SelectList(db.municipio, "id", "nombre", direccion.idMunicipio);
            ViewBag.idPersona = new SelectList(db.persona, "id", "primerNombre", direccion.idPersona);
            return View(direccion);
        }

        // POST: Direccion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tipoCalle,numero,tipoInmueble,barrio,observaciones,idMunicipio,idPersona,actual")] direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMunicipio = new SelectList(db.municipio, "id", "nombre", direccion.idMunicipio);
            ViewBag.idPersona = new SelectList(db.persona, "id", "primerNombre", direccion.idPersona);
            return View(direccion);
        }

        // GET: Direccion/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            direccion direccion = db.direccion.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: Direccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            direccion direccion = db.direccion.Find(id);
            db.direccion.Remove(direccion);
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
