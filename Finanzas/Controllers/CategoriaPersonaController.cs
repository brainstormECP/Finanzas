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
    public class CategoriaPersonaController : Controller
    {
        Entities db = new Entities();

        //
        // GET: /CategoriaPersona/

        public ActionResult Index()
        {
            return View(db.CategoriaPersona.ToList());
        }

        //
        // GET: /CategoriaPersona/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CategoriaPersona/Create

        [HttpPost]
        public ActionResult Create(CategoriaPersona categoriapersona)
        {
            if (ModelState.IsValid)
            {
                db.CategoriaPersona.Add(categoriapersona);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(categoriapersona);
        }

        //
        // GET: /CategoriaPersona/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CategoriaPersona categoriapersona = db.CategoriaPersona.Find(id);
            if (categoriapersona == null)
            {
                return HttpNotFound();
            }
            return View(categoriapersona);
        }

        //
        // POST: /CategoriaPersona/Edit/5

        [HttpPost]
        public ActionResult Edit(CategoriaPersona categoriapersona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriapersona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriapersona);
        }

        //
        // GET: /CategoriaPersona/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CategoriaPersona categoriapersona = db.CategoriaPersona.Find(id);
            if (categoriapersona == null)
            {
                return HttpNotFound();
            }
            return View(categoriapersona);
        }

        //
        // POST: /CategoriaPersona/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                CategoriaPersona categoriapersona = db.CategoriaPersona.Find(id);
                db.CategoriaPersona.Remove(categoriapersona);
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


        public JsonResult CheckCategoria(string categoria, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                var item = db.CategoriaPersona.FirstOrDefault(i => i.categoria.ToLower() == categoria.ToLower());
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.CategoriaPersona.FirstOrDefault(i => i.categoria.ToLower() == categoria.ToLower() && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}