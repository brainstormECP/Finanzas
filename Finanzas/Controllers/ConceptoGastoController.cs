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
    public class ConceptoGastoController : Controller
    {
        Entities db = new Entities();

        //
        // GET: /ConceptoGasto/

        public ActionResult Index()
        {
            return View(db.ConceptoGasto.ToList());
        }

        //
        // GET: /ConceptoGasto/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ConceptoGasto/Create

        [HttpPost]
        public ActionResult Create(ConceptoGasto conceptogasto)
        {
            if (ModelState.IsValid)
            {
                db.ConceptoGasto.Add(conceptogasto);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(conceptogasto);
        }

        //
        // GET: /ConceptoGasto/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ConceptoGasto conceptogasto = db.ConceptoGasto.Find(id);
            if (conceptogasto == null)
            {
                return HttpNotFound();
            }
            return View(conceptogasto);
        }

        //
        // POST: /ConceptoGasto/Edit/5

        [HttpPost]
        public ActionResult Edit(ConceptoGasto conceptogasto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conceptogasto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conceptogasto);
        }

        //
        // GET: /ConceptoGasto/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ConceptoGasto conceptogasto = db.ConceptoGasto.Find(id);
            if (conceptogasto == null)
            {
                return HttpNotFound();
            }
            return View(conceptogasto);
        }

        //
        // POST: /ConceptoGasto/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ConceptoGasto conceptogasto = db.ConceptoGasto.Find(id);
                db.ConceptoGasto.Remove(conceptogasto);
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


        public JsonResult CheckConcepto(string concepto, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                var item = db.ConceptoGasto.FirstOrDefault(i => i.concepto.ToLower() == concepto.ToLower());
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.ConceptoGasto.FirstOrDefault(i => i.concepto.ToLower() == concepto.ToLower() && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}