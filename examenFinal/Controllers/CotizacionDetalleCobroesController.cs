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
    public class CotizacionDetalleCobroesController : Controller
    {
        private ExamenDisenoEntities db = new ExamenDisenoEntities();

        // GET: CotizacionDetalleCobroes
        public ActionResult Index()
        {
            var cotizacionDetalleCobroes = db.CotizacionDetalleCobroes.Include(c => c.CotizacionCobro).Include(c => c.Tarifa);
            return View(cotizacionDetalleCobroes.ToList());
        }

        // GET: CotizacionDetalleCobroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionDetalleCobro cotizacionDetalleCobro = db.CotizacionDetalleCobroes.Find(id);
            if (cotizacionDetalleCobro == null)
            {
                return HttpNotFound();
            }
            return View(cotizacionDetalleCobro);
        }

        // GET: CotizacionDetalleCobroes/Create
        public ActionResult Create()
        {
            ViewBag.idCotizacionDetalle = new SelectList(db.CotizacionCobroes, "idCotizacionDetalle", "descripcion");
            ViewBag.idTarifa = new SelectList(db.Tarifas, "idTarifa", "referencia");
            return View();
        }

        // POST: CotizacionDetalleCobroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCotizacionDetalleCobro,idCotizacionDetalle,idTarifa,total")] CotizacionDetalleCobro cotizacionDetalleCobro)
        {
            if (ModelState.IsValid)
            {
                db.CotizacionDetalleCobroes.Add(cotizacionDetalleCobro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCotizacionDetalle = new SelectList(db.CotizacionCobroes, "idCotizacionDetalle", "descripcion", cotizacionDetalleCobro.idCotizacionDetalle);
            ViewBag.idTarifa = new SelectList(db.Tarifas, "idTarifa", "referencia", cotizacionDetalleCobro.idTarifa);
            return View(cotizacionDetalleCobro);
        }

        // GET: CotizacionDetalleCobroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionDetalleCobro cotizacionDetalleCobro = db.CotizacionDetalleCobroes.Find(id);
            if (cotizacionDetalleCobro == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCotizacionDetalle = new SelectList(db.CotizacionCobroes, "idCotizacionDetalle", "descripcion", cotizacionDetalleCobro.idCotizacionDetalle);
            ViewBag.idTarifa = new SelectList(db.Tarifas, "idTarifa", "referencia", cotizacionDetalleCobro.idTarifa);
            return View(cotizacionDetalleCobro);
        }

        // POST: CotizacionDetalleCobroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCotizacionDetalleCobro,idCotizacionDetalle,idTarifa,total")] CotizacionDetalleCobro cotizacionDetalleCobro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotizacionDetalleCobro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCotizacionDetalle = new SelectList(db.CotizacionCobroes, "idCotizacionDetalle", "descripcion", cotizacionDetalleCobro.idCotizacionDetalle);
            ViewBag.idTarifa = new SelectList(db.Tarifas, "idTarifa", "referencia", cotizacionDetalleCobro.idTarifa);
            return View(cotizacionDetalleCobro);
        }

        // GET: CotizacionDetalleCobroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionDetalleCobro cotizacionDetalleCobro = db.CotizacionDetalleCobroes.Find(id);
            if (cotizacionDetalleCobro == null)
            {
                return HttpNotFound();
            }
            return View(cotizacionDetalleCobro);
        }

        // POST: CotizacionDetalleCobroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CotizacionDetalleCobro cotizacionDetalleCobro = db.CotizacionDetalleCobroes.Find(id);
            db.CotizacionDetalleCobroes.Remove(cotizacionDetalleCobro);
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
