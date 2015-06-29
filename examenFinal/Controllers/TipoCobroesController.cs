using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using examenFinal;

namespace examenFinal.Controllers
{
    public class TipoCobroesController : Controller
    {
        private ExamenDisenoEntities db = new ExamenDisenoEntities();

        // GET: TipoCobroes
        public ActionResult Index()
        {
            return View(db.TipoCobroes.ToList());
        }
        public ActionResult getCobros()
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.TipoCobroes.ToList(),JsonRequestBehavior.AllowGet);
        }


        // GET: TipoCobroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCobro tipoCobro = db.TipoCobroes.Find(id);
            if (tipoCobro == null)
            {
                return HttpNotFound();
            }
            return View(tipoCobro);
        }

        // GET: TipoCobroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoCobroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoCobro,referencia,descripcion")] TipoCobro tipoCobro)
        {
            if (ModelState.IsValid)
            {
                db.TipoCobroes.Add(tipoCobro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoCobro);
        }

        // GET: TipoCobroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCobro tipoCobro = db.TipoCobroes.Find(id);
            if (tipoCobro == null)
            {
                return HttpNotFound();
            }
            return View(tipoCobro);
        }

        // POST: TipoCobroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoCobro,referencia,descripcion")] TipoCobro tipoCobro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoCobro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoCobro);
        }

        // GET: TipoCobroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCobro tipoCobro = db.TipoCobroes.Find(id);
            if (tipoCobro == null)
            {
                return HttpNotFound();
            }
            return View(tipoCobro);
        }

        // POST: TipoCobroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoCobro tipoCobro = db.TipoCobroes.Find(id);
            db.TipoCobroes.Remove(tipoCobro);
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
