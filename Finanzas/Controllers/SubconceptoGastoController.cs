using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Finanzas.Filters;
using Finanzas.Models;

namespace Finanzas.Controllers
{
    [LoginFilter(Rol = "Administrador")]
    public class SubconceptoGastoController : Controller
    {
        Entities db = new Entities();

        //
        // GET: /SubconceptoGasto/

        public ActionResult Index()
        {
            return View(db.SubconceptoGasto.Include(i => i.ConceptoGasto).ToList());
        }

        //
        // GET: /SubconceptoGasto/Create

        public ActionResult Create()
        {
            ViewBag.ConceptoGastoid = new SelectList(db.ConceptoGasto.Where(c => c.id != 1), "id", "concepto");
            return View();
        }

        //
        // POST: /SubconceptoGasto/Create

        [HttpPost]
        public ActionResult Create(SubconceptoGasto subconceptogasto)
        {
            if (ModelState.IsValid)
            {
                db.SubconceptoGasto.Add(subconceptogasto);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            ViewBag.ConceptoGastoid = new SelectList(db.ConceptoGasto.Where(c => c.id != 1), "id", "concepto", subconceptogasto.ConceptoGastoid);
            return View(subconceptogasto);
        }

        //
        // GET: /SubconceptoGasto/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SubconceptoGasto subconceptogasto = db.SubconceptoGasto.Find(id);
            if (subconceptogasto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConceptoGastoid = new SelectList(db.ConceptoGasto.Where(c => c.id != 1), "id", "concepto", subconceptogasto.ConceptoGastoid);
            return View(subconceptogasto);
        }

        //
        // POST: /SubconceptoGasto/Edit/5

        [HttpPost]
        public ActionResult Edit(SubconceptoGasto subconceptogasto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subconceptogasto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConceptoGastoid = new SelectList(db.ConceptoGasto.Where(c => c.id != 1), "id", "concepto", subconceptogasto.ConceptoGastoid);
            return View(subconceptogasto);
        }

        //
        // GET: /SubconceptoGasto/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SubconceptoGasto subconceptogasto = db.SubconceptoGasto.Find(id);
            if (subconceptogasto == null)
            {
                return HttpNotFound();
            }
            return View(subconceptogasto);
        }

        //
        // POST: /SubconceptoGasto/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                SubconceptoGasto subconceptogasto = db.SubconceptoGasto.Find(id);
                db.SubconceptoGasto.Remove(subconceptogasto);
                db.SaveChanges();
            }
            catch (Exception)
            {
                
                throw new Exception("Este registro se utiliza en una relacion y no lo puede borrar");
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public JsonResult CheckSubconcepto(string subconcepto, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                var item = db.SubconceptoGasto.FirstOrDefault(i => i.subconcepto.ToLower() == subconcepto.ToLower());
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.SubconceptoGasto.FirstOrDefault(i => i.subconcepto.ToLower() == subconcepto.ToLower() && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}