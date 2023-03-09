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
    public class OficinaController : Controller
    {
        private mensajeriaDBEntities db = new mensajeriaDBEntities();

        // GET: oficina
        [Authorize]
        public ActionResult Index()
        {
            var oficina = db.oficina.Include(o => o.municipio);
            return View(oficina.ToList());
        }

        // GET: oficina/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oficina oficina = db.oficina.Find(id);
            if (oficina == null)
            {
                return HttpNotFound();
            }
            return View(oficina);
        }

        // GET: oficina/Create
        public ActionResult Create()
        {
            ViewBag.idMunicipio = new SelectList(db.municipio, "id", "nombre");
            return View();
        }

        // POST: oficina/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,codigo,telefono,idMunicipio,direccion,latitud,longitud")] oficina oficina)
        {
            if (ModelState.IsValid)
            {
                db.oficina.Add(oficina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMunicipio = new SelectList(db.municipio, "id", "nombre", oficina.idMunicipio);
            return View(oficina);
        }

        // GET: oficina/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oficina oficina = db.oficina.Find(id);
            if (oficina == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMunicipio = new SelectList(db.municipio, "id", "nombre", oficina.idMunicipio);
            return View(oficina);
        }

        // POST: oficina/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,codigo,telefono,idMunicipio,direccion,latitud,longitud")] oficina oficina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oficina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMunicipio = new SelectList(db.municipio, "id", "nombre", oficina.idMunicipio);
            return View(oficina);
        }

        // GET: oficina/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oficina oficina = db.oficina.Find(id);
            if (oficina == null)
            {
                return HttpNotFound();
            }
            return View(oficina);
        }

        // POST: oficina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            oficina oficina = db.oficina.Find(id);
            db.oficina.Remove(oficina);
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
