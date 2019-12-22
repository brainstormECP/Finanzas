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
    public class UnidadMedidaController : Controller
    {
        Entities db = new Entities();

        //
        // GET: /UnidadMedida/

        public ActionResult Index()
        {
            return View(db.UnidadMedida.ToList());
        }

        //
        // GET: /UnidadMedida/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UnidadMedida/Create

        [HttpPost]
        public ActionResult Create(UnidadMedida unidadmedida)
        {
            if (ModelState.IsValid)
            {
                db.UnidadMedida.Add(unidadmedida);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(unidadmedida);
        }

        //
        // GET: /UnidadMedida/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UnidadMedida unidadmedida = db.UnidadMedida.Find(id);
            if (unidadmedida == null)
            {
                return HttpNotFound();
            }
            return View(unidadmedida);
        }

        //
        // POST: /UnidadMedida/Edit/5

        [HttpPost]
        public ActionResult Edit(UnidadMedida unidadmedida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unidadmedida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unidadmedida);
        }

        //
        // GET: /UnidadMedida/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UnidadMedida unidadmedida = db.UnidadMedida.Find(id);
            if (unidadmedida == null)
            {
                return HttpNotFound();
            }
            return View(unidadmedida);
        }

        //
        // POST: /UnidadMedida/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                UnidadMedida unidadmedida = db.UnidadMedida.Find(id);
                db.UnidadMedida.Remove(unidadmedida);
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
                var item = db.UnidadMedida.FirstOrDefault(i => i.siglas.ToLower() == siglas.ToLower());
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.UnidadMedida.FirstOrDefault(i => i.siglas.ToLower() == siglas.ToLower() && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckUnidad(string unidad, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                var item = db.UnidadMedida.FirstOrDefault(i => i.unidad.ToLower() == unidad.ToLower());
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.UnidadMedida.FirstOrDefault(i => i.unidad.ToLower() == unidad.ToLower() && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}