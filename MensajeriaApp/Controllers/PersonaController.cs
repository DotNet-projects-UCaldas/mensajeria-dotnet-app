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
    public class PersonaController : Controller
    {
        private mensajeriaDBEntities db = new mensajeriaDBEntities();

        // GET: Persona
        public ActionResult Index()
        {
            var persona = db.persona.Include(p => p.direccion).Include(p => p.tipoDocumento1);
            return View(persona.ToList());
        }

        // GET: Persona/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = db.persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            ViewBag.idDireccion = new SelectList(db.direccion, "id", "tipoCalle");
            ViewBag.idTipoDocumento = new SelectList(db.tipoDocumento, "id", "nombre");
            return View();
        }

        // POST: Persona/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,primerNombre,otrosNombres,primerApellido,segundoApellido,tipoDocumento,documento,telefono,correo,idDireccion,idTipoDocumento")] persona persona)
        {
            if (ModelState.IsValid)
            {
                db.persona.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDireccion = new SelectList(db.direccion, "id", "tipoCalle", persona.idDireccion);
            ViewBag.idTipoDocumento = new SelectList(db.tipoDocumento, "id", "nombre", persona.idTipoDocumento);
            return View(persona);
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = db.persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDireccion = new SelectList(db.direccion, "id", "tipoCalle", persona.idDireccion);
            ViewBag.idTipoDocumento = new SelectList(db.tipoDocumento, "id", "nombre", persona.idTipoDocumento);
            return View(persona);
        }

        // POST: Persona/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,primerNombre,otrosNombres,primerApellido,segundoApellido,tipoDocumento,documento,telefono,correo,idDireccion,idTipoDocumento")] persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDireccion = new SelectList(db.direccion, "id", "tipoCalle", persona.idDireccion);
            ViewBag.idTipoDocumento = new SelectList(db.tipoDocumento, "id", "nombre", persona.idTipoDocumento);
            return View(persona);
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = db.persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            persona persona = db.persona.Find(id);
            db.persona.Remove(persona);
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
