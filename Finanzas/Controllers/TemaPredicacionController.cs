using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Finanzas.Models;

namespace Finanzas.Controllers
{
    public class TemaPredicacionController : Controller
    {
        Entities db = new Entities();

        //
        // GET: /TemaPredicacion/

        public ActionResult Index()
        {
            return View(db.TemaPredicacion.ToList());
        }

        //
        // GET: /TemaPredicacion/Details/5

        public ActionResult Details(int id = 0)
        {
            TemaPredicacion temapredicacion = db.TemaPredicacion.Find(id);
            if (temapredicacion == null)
            {
                return HttpNotFound();
            }
            return View(temapredicacion);
        }

        //
        // GET: /TemaPredicacion/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TemaPredicacion/Create

        [HttpPost]
        public ActionResult Create(TemaPredicacion temapredicacion)
        {
            if (ModelState.IsValid)
            {
                db.TemaPredicacion.Add(temapredicacion);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(temapredicacion);
        }

        //
        // GET: /TemaPredicacion/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TemaPredicacion temapredicacion = db.TemaPredicacion.Find(id);
            if (temapredicacion == null)
            {
                return HttpNotFound();
            }
            return View(temapredicacion);
        }

        //
        // POST: /TemaPredicacion/Edit/5

        [HttpPost]
        public ActionResult Edit(TemaPredicacion temapredicacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(temapredicacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(temapredicacion);
        }

        //
        // GET: /TemaPredicacion/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TemaPredicacion temapredicacion = db.TemaPredicacion.Find(id);
            if (temapredicacion == null)
            {
                return HttpNotFound();
            }
            return View(temapredicacion);
        }

        //
        // POST: /TemaPredicacion/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                TemaPredicacion temapredicacion = db.TemaPredicacion.Find(id);
                db.TemaPredicacion.Remove(temapredicacion);
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


        public JsonResult CheckTema(string tema, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                var item = db.TemaPredicacion.FirstOrDefault(i => i.tema.ToLower() == tema.ToLower());
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.TemaPredicacion.FirstOrDefault(i => i.tema.ToLower() == tema.ToLower() && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}