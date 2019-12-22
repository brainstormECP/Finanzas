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
    public class ProductoController : Controller
    {
        Entities db = new Entities();

        //
        // GET: /Producto/

        public ActionResult Index()
        {
            var producto = db.Producto.Include(p => p.UnidadMedida);
            return View(producto.ToList());
        }

        //
        // GET: /Producto/Create

        public ActionResult Create()
        {
            ViewBag.UnidadMedidaid = new SelectList(db.UnidadMedida, "id", "siglas");
            return View();
        }

        //
        // POST: /Producto/Create

        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.UnidadMedidaid = new SelectList(db.UnidadMedida, "id", "siglas", producto.UnidadMedidaid);
            return View(producto);
        }

        //
        // GET: /Producto/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.UnidadMedidaid = new SelectList(db.UnidadMedida, "id", "siglas", producto.UnidadMedidaid);
            return View(producto);
        }

        //
        // POST: /Producto/Edit/5

        [HttpPost]
        public ActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UnidadMedidaid = new SelectList(db.UnidadMedida, "id", "siglas", producto.UnidadMedidaid);
            return View(producto);
        }

        //
        // GET: /Producto/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        //
        // POST: /Producto/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Producto producto = db.Producto.Find(id);
                db.Producto.Remove(producto);
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

        public JsonResult CheckProducto(string nombre, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                var item = db.Producto.FirstOrDefault(i => i.nombre.ToLower() == nombre.ToLower());
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.Producto.FirstOrDefault(i => i.nombre.ToLower() == nombre.ToLower() && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}