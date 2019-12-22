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
    [LoginFilter(Rol = "Tesorero")]
    public class CuentaController : Controller
    {
        Entities db = new Entities();

        //
        // GET: /Cuenta/

        public ActionResult Index()
        {
            var cuentas = db.Cuentas.Include(c => c.TipoMoneda);
            return View(cuentas.ToList());
        }

        //
        // GET: /Cuenta/Create

        public ActionResult Create()
        {
            ViewBag.TipoMonedaid = new SelectList(db.TipoMoneda, "id", "siglas");
            return View();
        }

        //
        // POST: /Cuenta/Create

        [HttpPost]
        public ActionResult Create(Cuentas cuentas)
        {
            if (ModelState.IsValid)
            {
                db.Cuentas.Add(cuentas);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.TipoMonedaid = new SelectList(db.TipoMoneda, "id", "siglas", cuentas.TipoMonedaid);
            return View(cuentas);
        }

        //
        // GET: /Cuenta/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cuentas cuentas = db.Cuentas.Find(id);
            if (cuentas == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoMonedaid = new SelectList(db.TipoMoneda, "id", "siglas", cuentas.TipoMonedaid);
            return View(cuentas);
        }

        //
        // POST: /Cuenta/Edit/5

        [HttpPost]
        public ActionResult Edit(Cuentas cuentas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuentas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoMonedaid = new SelectList(db.TipoMoneda, "id", "siglas", cuentas.TipoMonedaid);
            return View(cuentas);
        }

        //
        // GET: /Cuenta/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cuentas cuentas = db.Cuentas.Find(id);
            if (cuentas == null)
            {
                return HttpNotFound();
            }
            return View(cuentas);
        }

        //
        // POST: /Cuenta/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Cuentas cuentas = db.Cuentas.Find(id);
                db.Cuentas.Remove(cuentas);
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

        public JsonResult CheckCuenta(string nombre, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                var item = db.Cuentas.FirstOrDefault(i => i.nombre.ToLower() == nombre.ToLower());
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.Cuentas.FirstOrDefault(i => i.nombre.ToLower() == nombre.ToLower() && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}