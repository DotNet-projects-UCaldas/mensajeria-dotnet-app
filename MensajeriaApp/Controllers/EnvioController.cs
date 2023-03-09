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
    public class EnvioController : Controller
    {
        private mensajeriaDBEntities db = new mensajeriaDBEntities();

        // GET: Envio
        public ActionResult Index()
        {
            var envio = db.envio.Include(e => e.direccion).Include(e => e.estadoEnvio).Include(e => e.paquete).Include(e => e.persona).Include(e => e.tipoTransporte);
            return View(envio.ToList());
        }

        // GET: Envio/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            envio envio = db.envio.Find(id);
            if (envio == null)
            {
                return HttpNotFound();
            }
            return View(envio);
        }

        // GET: Envio/Create
        public ActionResult Create()
        {
            ViewBag.idDireccionDestino = new SelectList(db.direccion, "id", "tipoCalle");
            ViewBag.idEstado = new SelectList(db.estadoEnvio, "id", "nombre");
            ViewBag.idPaquete = new SelectList(db.paquete, "id", "id");
            ViewBag.idRemitente = new SelectList(db.persona, "id", "primerNombre");
            ViewBag.idTipoTransporte = new SelectList(db.tipoTransporte, "id", "nombre");
            return View();
        }

        // POST: Envio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fechaEnvio,precio,idRemitente,idDireccionDestino,idPaquete,idEstado,idTipoTransporte")] envio envio)
        {
            if (ModelState.IsValid)
            {
                db.envio.Add(envio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDireccionDestino = new SelectList(db.direccion, "id", "tipoCalle", envio.idDireccionDestino);
            ViewBag.idEstado = new SelectList(db.estadoEnvio, "id", "nombre", envio.idEstado);
            ViewBag.idPaquete = new SelectList(db.paquete, "id", "id", envio.idPaquete);
            ViewBag.idRemitente = new SelectList(db.persona, "id", "primerNombre", envio.idRemitente);
            ViewBag.idTipoTransporte = new SelectList(db.tipoTransporte, "id", "nombre", envio.idTipoTransporte);
            return View(envio);
        }

        // GET: Envio/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            envio envio = db.envio.Find(id);
            if (envio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDireccionDestino = new SelectList(db.direccion, "id", "tipoCalle", envio.idDireccionDestino);
            ViewBag.idEstado = new SelectList(db.estadoEnvio, "id", "nombre", envio.idEstado);
            ViewBag.idPaquete = new SelectList(db.paquete, "id", "id", envio.idPaquete);
            ViewBag.idRemitente = new SelectList(db.persona, "id", "primerNombre", envio.idRemitente);
            ViewBag.idTipoTransporte = new SelectList(db.tipoTransporte, "id", "nombre", envio.idTipoTransporte);
            return View(envio);
        }

        // POST: Envio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fechaEnvio,precio,idRemitente,idDireccionDestino,idPaquete,idEstado,idTipoTransporte")] envio envio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(envio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDireccionDestino = new SelectList(db.direccion, "id", "tipoCalle", envio.idDireccionDestino);
            ViewBag.idEstado = new SelectList(db.estadoEnvio, "id", "nombre", envio.idEstado);
            ViewBag.idPaquete = new SelectList(db.paquete, "id", "id", envio.idPaquete);
            ViewBag.idRemitente = new SelectList(db.persona, "id", "primerNombre", envio.idRemitente);
            ViewBag.idTipoTransporte = new SelectList(db.tipoTransporte, "id", "nombre", envio.idTipoTransporte);
            return View(envio);
        }

        // GET: Envio/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            envio envio = db.envio.Find(id);
            if (envio == null)
            {
                return HttpNotFound();
            }
            return View(envio);
        }

        // POST: Envio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            envio envio = db.envio.Find(id);
            db.envio.Remove(envio);
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
