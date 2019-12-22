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
    public class AlmacenController : Controller
    {
        Entities db = new Entities();

        //
        // GET: /Almacen/

        public ActionResult Index()
        {
            var almacen = db.Almacen.Include(a => a.Producto);
            return View(almacen.ToList());
        }

        ////
        //// GET: /Almacen/Create

        //public ActionResult Create()
        //{
        //    ViewBag.Productoid = new SelectList(db.Producto, "id", "nombre");
        //    return View();
        //}

        ////
        //// POST: /Almacen/Create

        //[HttpPost]
        //public ActionResult Create(Almacen almacen)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Almacen.Add(almacen);
        //        db.SaveChanges();
        //        return RedirectToAction("Create");
        //    }

        //    ViewBag.Productoid = new SelectList(db.Producto, "id", "nombre", almacen.Productoid);
        //    return View(almacen);
        //}

        ////
        //// GET: /Almacen/Edit/5

        //public ActionResult Edit(int id = 0)
        //{
        //    Almacen almacen = db.Almacen.Find(id);
        //    if (almacen == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Productoid = new SelectList(db.Producto, "id", "nombre", almacen.Productoid);
        //    return View(almacen);
        //}

        ////
        //// POST: /Almacen/Edit/5

        //[HttpPost]
        //public ActionResult Edit(Almacen almacen)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(almacen).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Productoid = new SelectList(db.Producto, "id", "nombre", almacen.Productoid);
        //    return View(almacen);
        //}

        ////
        //// GET: /Almacen/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    Almacen almacen = db.Almacen.Find(id);
        //    if (almacen == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(almacen);
        //}

        ////
        //// POST: /Almacen/Delete/5

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    try
        //    {
        //        Almacen almacen = db.Almacen.Find(id);
        //        db.Almacen.Remove(almacen);
        //        db.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
                
        //        throw new Exception("Este registro se utiliza en una relacion y no lo puede borrar");
        //    }
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}