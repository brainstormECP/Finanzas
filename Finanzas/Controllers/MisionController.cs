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
    [LoginFilter(Rol = "Secretaria")]
    public class MisionController : Controller
    {
        Entities db = new Entities();

        //
        // GET: /Mision/

        public ActionResult Index()
        {
            var misiones = db.Misiones.Include(m => m.Lider);
            return View(misiones.ToList());
        }

        //
        // GET: /Mision/Create

        public ActionResult Create()
        {
            var personas = from p in db.Persona
                           where p.activo
                           select new { p.id, nombre = p.nombre + " " + p.apellido1 + " " + (p.apellido2 ?? "") };
            ViewBag.Personaid = new SelectList(personas, "id", "nombre");
            return View();
        }

        //
        // POST: /Mision/Create

        [HttpPost]
        public ActionResult Create(Misiones misiones)
        {
            if (ModelState.IsValid)
            {
                db.Misiones.Add(misiones);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            var personas = from p in db.Persona
                           where p.activo
                           select new { p.id, nombre = p.nombre + " " + p.apellido1 + " " + (p.apellido2 ?? "") };
            ViewBag.Personaid = new SelectList(personas, "id", "nombre", misiones.Personaid);
            return View(misiones);
        }

        //
        // GET: /Mision/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Misiones misiones = db.Misiones.Find(id);
            if (misiones == null)
            {
                return HttpNotFound();
            }
            var personas = from p in db.Persona
                           where p.activo
                           select new { p.id, nombre = p.nombre + " " + p.apellido1 + " " + (p.apellido2 ?? "") };
            ViewBag.Personaid = new SelectList(personas, "id", "nombre", misiones.Personaid);
            return View(misiones);
        }

        //
        // POST: /Mision/Edit/5

        [HttpPost]
        public ActionResult Edit(Misiones misiones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(misiones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var personas = from p in db.Persona
                           where p.activo
                           select new { p.id, nombre = p.nombre + " " + p.apellido1 + " " + (p.apellido2 ?? "") };
            ViewBag.Personaid = new SelectList(personas, "id", "nombre", misiones.Personaid);
            return View(misiones);
        }

        //
        // GET: /Mision/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Misiones misiones = db.Misiones.Find(id);
            if (misiones == null)
            {
                return HttpNotFound();
            }
            return View(misiones);
        }

        //
        // POST: /Mision/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Misiones misiones = db.Misiones.Find(id);
                db.Misiones.Remove(misiones);
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

        public JsonResult CheckLugar(string lugar)
        {
            var result = false;
            var usuario = db.Misiones.FirstOrDefault(u => u.lugar == lugar);
            if (usuario == null)
            {
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckMision(string lugar, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                var item = db.Misiones.FirstOrDefault(i => i.lugar.ToLower() == lugar.ToLower());
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.Misiones.FirstOrDefault(i => i.lugar.ToLower() == lugar.ToLower() && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}