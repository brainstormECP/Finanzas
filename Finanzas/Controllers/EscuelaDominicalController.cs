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
    public class EscuelaDominicalController : Controller
    {
        Entities db = new Entities();

        //
        // GET: /EscuelaDominical/

        public ActionResult Index()
        {
            var escueladominical = db.EscuelaDominical.Include(e => e.Usuario).Include(e => e.TemaPredicacion);
            return View(escueladominical.ToList());
        }

        //
        // GET: /EscuelaDominical/Create

        public ActionResult Create()
        {
            ViewBag.TemaPredicacionid = new SelectList(db.TemaPredicacion, "id", "tema");
            return View();
        }

        //
        // POST: /EscuelaDominical/Create

        [HttpPost]
        public ActionResult Create(EscuelaDominical escueladominical)
        {
            if (ModelState.IsValid)
            {
                var user = Session["usuarioActual"] as Usuario;
                escueladominical.Usuarioid = user.id;
                db.EscuelaDominical.Add(escueladominical);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.TemaPredicacionid = new SelectList(db.TemaPredicacion, "id", "tema", escueladominical.TemaPredicacionid);
            return View(escueladominical);
        }

        //
        // GET: /EscuelaDominical/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EscuelaDominical escueladominical = db.EscuelaDominical.Find(id);
            if (escueladominical == null)
            {
                return HttpNotFound();
            }
            ViewBag.TemaPredicacionid = new SelectList(db.TemaPredicacion, "id", "tema", escueladominical.TemaPredicacionid);
            return View(escueladominical);
        }

        //
        // POST: /EscuelaDominical/Edit/5

        [HttpPost]
        public ActionResult Edit(EscuelaDominical escueladominical)
        {
            if (ModelState.IsValid)
            {
                var user = Session["usuarioActual"] as Usuario;
                escueladominical.Usuarioid = user.id;
                db.Entry(escueladominical).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           ViewBag.TemaPredicacionid = new SelectList(db.TemaPredicacion, "id", "tema", escueladominical.TemaPredicacionid);
            return View(escueladominical);
        }

        //
        // GET: /EscuelaDominical/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EscuelaDominical escueladominical = db.EscuelaDominical.Find(id);
            if (escueladominical == null)
            {
                return HttpNotFound();
            }
            return View(escueladominical);
        }

        //
        // POST: /EscuelaDominical/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                EscuelaDominical escueladominical = db.EscuelaDominical.Find(id);
                db.EscuelaDominical.Remove(escueladominical);
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