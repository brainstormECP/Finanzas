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
    public class RolController : Controller
    {
        Entities db = new Entities();

        //
        // GET: /Rol/

        public ActionResult Index()
        {
            return View(db.Rol.ToList());
        }

        //
        // GET: /Rol/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Rol/Create

        [HttpPost]
        public ActionResult Create(Rol rol)
        {
            if (ModelState.IsValid)
            {
                db.Rol.Add(rol);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(rol);
        }

        //
        // GET: /Rol/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Rol rol = db.Rol.Find(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            return View(rol);
        }

        //
        // POST: /Rol/Edit/5

        [HttpPost]
        public ActionResult Edit(Rol rol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rol);
        }

        //
        // GET: /Rol/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Rol rol = db.Rol.Find(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            return View(rol);
        }

        //
        // POST: /Rol/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Rol rol = db.Rol.Find(id);
                db.Rol.Remove(rol);
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
    }
}