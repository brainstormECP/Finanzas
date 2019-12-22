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
    public class ConceptoIngresoController : Controller
    {
        Entities db = new Entities();

        //
        // GET: /ConceptoIngreso/

        public ActionResult Index()
        {
            return View(db.ConceptoIngreso.ToList());
        }

        //
        // GET: /ConceptoIngreso/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ConceptoIngreso/Create

        [HttpPost]
        public ActionResult Create(ConceptoIngreso conceptoingreso)
        {
            if (ModelState.IsValid)
            {
                db.ConceptoIngreso.Add(conceptoingreso);
                db.SaveChanges();
               
                return RedirectToAction("Create");
            }

            return View(conceptoingreso);
        }

        //
        // GET: /ConceptoIngreso/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ConceptoIngreso conceptoingreso = db.ConceptoIngreso.Find(id);
            if (conceptoingreso == null)
            {
                return HttpNotFound();
            }
            return View(conceptoingreso);
        }

        //
        // POST: /ConceptoIngreso/Edit/5

        [HttpPost]
        public ActionResult Edit(ConceptoIngreso conceptoingreso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conceptoingreso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conceptoingreso);
        }

        //
        // GET: /ConceptoIngreso/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ConceptoIngreso conceptoingreso = db.ConceptoIngreso.Find(id);
            if (conceptoingreso == null)
            {
                return HttpNotFound();
            }
            return View(conceptoingreso);
        }

        //
        // POST: /ConceptoIngreso/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ConceptoIngreso conceptoingreso = db.ConceptoIngreso.Find(id);
                db.ConceptoIngreso.Remove(conceptoingreso);
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
                var item = db.ConceptoIngreso.FirstOrDefault(i => i.concepto.ToLower() == concepto.ToLower());
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.ConceptoIngreso.FirstOrDefault(i => i.concepto.ToLower() == concepto.ToLower() && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}