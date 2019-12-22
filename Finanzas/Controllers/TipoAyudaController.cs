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
    public class TipoAyudaController : Controller
    {
        Entities db = new Entities();

        //
        // GET: /TipoAyuda/

        public ActionResult Index()
        {
            return View(db.TipoAyuda.ToList());
        }

        //
        // GET: /TipoAyuda/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TipoAyuda/Create

        [HttpPost]
        public ActionResult Create(TipoAyuda tipoayuda)
        {
            if (ModelState.IsValid)
            {
                db.TipoAyuda.Add(tipoayuda);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(tipoayuda);
        }

        //
        // GET: /TipoAyuda/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TipoAyuda tipoayuda = db.TipoAyuda.Find(id);
            if (tipoayuda == null)
            {
                return HttpNotFound();
            }
            return View(tipoayuda);
        }

        //
        // POST: /TipoAyuda/Edit/5

        [HttpPost]
        public ActionResult Edit(TipoAyuda tipoayuda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoayuda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoayuda);
        }

        //
        // GET: /TipoAyuda/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TipoAyuda tipoayuda = db.TipoAyuda.Find(id);
            if (tipoayuda == null)
            {
                return HttpNotFound();
            }
            return View(tipoayuda);
        }

        //
        // POST: /TipoAyuda/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                TipoAyuda tipoayuda = db.TipoAyuda.Find(id);
                db.TipoAyuda.Remove(tipoayuda);
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

        public JsonResult CheckTipoAyuda(string tipo, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                var item = db.TipoAyuda.FirstOrDefault(i => i.tipo.ToLower() == tipo.ToLower());
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.TipoAyuda.FirstOrDefault(i => i.tipo.ToLower() == tipo.ToLower() && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}