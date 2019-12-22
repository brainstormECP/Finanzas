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
    public class TipoMonedaController : Controller
    {
        Entities db = new Entities();

        //
        // GET: /TipoMoneda/

        public ActionResult Index()
        {
            return View(db.TipoMoneda.ToList());
        }

        //
        // GET: /TipoMoneda/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TipoMoneda/Create

        [HttpPost]
        public ActionResult Create(TipoMoneda tipomoneda)
        {
            if (ModelState.IsValid)
            {
                db.TipoMoneda.Add(tipomoneda);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(tipomoneda);
        }

        //
        // GET: /TipoMoneda/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TipoMoneda tipomoneda = db.TipoMoneda.Find(id);
            if (tipomoneda == null)
            {
                return HttpNotFound();
            }
            return View(tipomoneda);
        }

        //
        // POST: /TipoMoneda/Edit/5

        [HttpPost]
        public ActionResult Edit(TipoMoneda tipomoneda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipomoneda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipomoneda);
        }

        //
        // GET: /TipoMoneda/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TipoMoneda tipomoneda = db.TipoMoneda.Find(id);
            if (tipomoneda == null)
            {
                return HttpNotFound();
            }
            return View(tipomoneda);
        }

        //
        // POST: /TipoMoneda/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                TipoMoneda tipomoneda = db.TipoMoneda.Find(id);
                db.TipoMoneda.Remove(tipomoneda);
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

        public JsonResult CheckSiglas(string siglas, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                var item = db.TipoMoneda.FirstOrDefault(i => i.siglas.ToLower() == siglas.ToLower());
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.TipoMoneda.FirstOrDefault(i => i.siglas.ToLower() == siglas.ToLower() && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckMoneda(string moneda, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                var item = db.TipoMoneda.FirstOrDefault(i => i.moneda.ToLower() == moneda.ToLower());
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.TipoMoneda.FirstOrDefault(i => i.moneda.ToLower() == moneda.ToLower() && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}