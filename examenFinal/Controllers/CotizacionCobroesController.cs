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
    public class CotizacionCobroesController : Controller
    {
        private ExamenDisenoEntities db = new ExamenDisenoEntities();

        // GET: CotizacionCobroes
        public ActionResult Index()
        {
            var cotizacionCobroes = db.CotizacionCobroes.Include(c => c.Cotizacion);
            return View(cotizacionCobroes.ToList());
        }

        // GET: CotizacionCobroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionCobro cotizacionCobro = db.CotizacionCobroes.Find(id);
            if (cotizacionCobro == null)
            {
                return HttpNotFound();
            }
            return View(cotizacionCobro);
        }

        // GET: CotizacionCobroes/Create
        public ActionResult Create()
        {
            ViewBag.idCotizacion = new SelectList(db.Cotizacions, "idCotizacion", "cliente");
            return View();
        }

        // POST: CotizacionCobroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCotizacionDetalle,idCotizacion,idTipoCarga,cantidad,descripcion,tamano,alto,ancho,largo,peso,idUnidadPeso")] CotizacionCobro cotizacionCobro)
        {
            if (ModelState.IsValid)
            {
                db.CotizacionCobroes.Add(cotizacionCobro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCotizacion = new SelectList(db.Cotizacions, "idCotizacion", "cliente", cotizacionCobro.idCotizacion);
            return View(cotizacionCobro);
        }

        // GET: CotizacionCobroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionCobro cotizacionCobro = db.CotizacionCobroes.Find(id);
            if (cotizacionCobro == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCotizacion = new SelectList(db.Cotizacions, "idCotizacion", "cliente", cotizacionCobro.idCotizacion);
            return View(cotizacionCobro);
        }

        // POST: CotizacionCobroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCotizacionDetalle,idCotizacion,idTipoCarga,cantidad,descripcion,tamano,alto,ancho,largo,peso,idUnidadPeso")] CotizacionCobro cotizacionCobro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotizacionCobro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCotizacion = new SelectList(db.Cotizacions, "idCotizacion", "cliente", cotizacionCobro.idCotizacion);
            return View(cotizacionCobro);
        }

        // GET: CotizacionCobroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionCobro cotizacionCobro = db.CotizacionCobroes.Find(id);
            if (cotizacionCobro == null)
            {
                return HttpNotFound();
            }
            return View(cotizacionCobro);
        }

        // POST: CotizacionCobroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CotizacionCobro cotizacionCobro = db.CotizacionCobroes.Find(id);
            db.CotizacionCobroes.Remove(cotizacionCobro);
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
