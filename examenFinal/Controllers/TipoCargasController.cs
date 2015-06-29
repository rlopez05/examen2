using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using examenFinal;
using Newtonsoft.Json;

namespace examenFinal.Controllers
{
    public class TipoCargasController : Controller
    {
        private ExamenDisenoEntities db = new ExamenDisenoEntities();

        // GET: TipoCargas
        public ActionResult Index()
        {
            return View(db.TipoCargas.ToList());
        }
        public ActionResult getTipoCarga()
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.TipoCargas.ToList(), JsonRequestBehavior.AllowGet);
        }


        // GET: TipoCargas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCarga tipoCarga = db.TipoCargas.Find(id);
            if (tipoCarga == null)
            {
                return HttpNotFound();
            }
            return View(tipoCarga);
        }

        // GET: TipoCargas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoCargas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoCarga,referencia,descripcion,tipo,preferencia,comentario")] TipoCarga tipoCarga)
        {
            if (ModelState.IsValid)
            {
                db.TipoCargas.Add(tipoCarga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoCarga);
        }

        // GET: TipoCargas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCarga tipoCarga = db.TipoCargas.Find(id);
            if (tipoCarga == null)
            {
                return HttpNotFound();
            }
            return View(tipoCarga);
        }

        // POST: TipoCargas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoCarga,referencia,descripcion,tipo,preferencia,comentario")] TipoCarga tipoCarga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoCarga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoCarga);
        }

        // GET: TipoCargas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCarga tipoCarga = db.TipoCargas.Find(id);
            if (tipoCarga == null)
            {
                return HttpNotFound();
            }
            return View(tipoCarga);
        }

        // POST: TipoCargas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoCarga tipoCarga = db.TipoCargas.Find(id);
            db.TipoCargas.Remove(tipoCarga);
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
