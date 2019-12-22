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
    public class SalidaAlmacenController : Controller
    {
        Entities db = new Entities();
        private static SalidaAlmacen salidaAnterior;

        //
        // GET: /SalidaAlmacen/

        public ActionResult Index()
        {
            var config = ConfiguracionModel.GetConfig();
            var salidaalmacen = db.SalidaAlmacen.Include(s => s.Almacen).Include(s => s.TipoAyuda).Include(s => s.Usuario).Where(i => i.fecha.Month == config.MesActual && i.fecha.Year == config.AnoActual);
            return View(salidaalmacen.ToList());
        }

        //
        // GET: /SalidaAlmacen/Create

        public ActionResult Create()
        {
            ViewBag.Almacenid = new SelectList(db.Almacen.Where(a => a.cantidad > 0), "id","");
            ViewBag.TipoAyudaid = new SelectList(db.TipoAyuda, "id", "tipo");
            return View();
        }

        //
        // POST: /SalidaAlmacen/Create

        [HttpPost]
        public ActionResult Create(SalidaAlmacen salidaalmacen)
        {
            if (ModelState.IsValid)
            {
                var user = Session["usuarioActual"] as Usuario;
                salidaalmacen.Usuarioid = user.id;
                db.SalidaAlmacen.Add(salidaalmacen);
                var almacen = db.Almacen.Find(salidaalmacen.Almacenid);
                almacen.cantidad -= salidaalmacen.cantidad;
                db.Entry(almacen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.Almacenid = new SelectList(db.Almacen.Where(a => a.cantidad > 0), "id", "", salidaalmacen.Almacenid);
            ViewBag.TipoAyudaid = new SelectList(db.TipoAyuda, "id", "tipo", salidaalmacen.TipoAyudaid);
            return View(salidaalmacen);
        }

        //
        // GET: /SalidaAlmacen/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SalidaAlmacen salidaalmacen = db.SalidaAlmacen.Find(id);
            if (salidaalmacen == null)
            {
                return HttpNotFound();
            }
            ViewBag.Almacenid = new SelectList(db.Almacen, "id", "", salidaalmacen.Almacenid);
            ViewBag.TipoAyudaid = new SelectList(db.TipoAyuda, "id", "tipo", salidaalmacen.TipoAyudaid);
            salidaAnterior = salidaalmacen;
            return View(salidaalmacen);
        }

        //
        // POST: /SalidaAlmacen/Edit/5

        [HttpPost]
        public ActionResult Edit(SalidaAlmacen salidaalmacen)
        {
            if (ModelState.IsValid)
            {
                var user = Session["usuarioActual"] as Usuario;
                salidaalmacen.Usuarioid = user.id;
                db.Entry(salidaalmacen).State = EntityState.Modified;

                //anterior
                var almacenAnterior = db.Almacen.Find(salidaAnterior.Almacenid);
                almacenAnterior.cantidad += salidaAnterior.cantidad;

                //actual
                var almacen = db.Almacen.Find(salidaalmacen.Almacenid);
                almacen.cantidad -= salidaalmacen.cantidad;

                db.Entry(almacen).State = EntityState.Modified;
                db.Entry(almacenAnterior).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Almacenid = new SelectList(db.Almacen, "id", "", salidaalmacen.Almacenid);
            ViewBag.TipoAyudaid = new SelectList(db.TipoAyuda, "id", "tipo", salidaalmacen.TipoAyudaid);
            return View(salidaalmacen);
        }

        //
        // GET: /SalidaAlmacen/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SalidaAlmacen salidaalmacen = db.SalidaAlmacen.Find(id);
            if (salidaalmacen == null)
            {
                return HttpNotFound();
            }
            return View(salidaalmacen);
        }

        //
        // POST: /SalidaAlmacen/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                SalidaAlmacen salidaalmacen = db.SalidaAlmacen.Find(id);
                var almacen = db.Almacen.Find(salidaalmacen.Almacenid);
                almacen.cantidad += salidaalmacen.cantidad;
                db.Entry(almacen).State = EntityState.Modified;

                db.SalidaAlmacen.Remove(salidaalmacen);
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


        public JsonResult CheckAlmacen(int cantidad, int Almacenid, int id = 0)
        {
            var result = false;
            var almacen = db.Almacen.Find(Almacenid);
            
            if (id == 0)
            {
                if (cantidad <= almacen.cantidad)
                {
                    result = true;
                }
            }
            else
            {
                if (Almacenid == salidaAnterior.Almacenid)
                {
                    if ((almacen.cantidad + salidaAnterior.cantidad) - cantidad >= 0)
                    {
                        result = true;
                    }
                }
                else
                {
                    if (cantidad <= almacen.cantidad)
                    {
                        result = true;
                    }
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult CheckFecha(string fecha)
        {
            var result = false;
            var l = fecha.Split('/');
            var f = new DateTime(int.Parse(l[2]), int.Parse(l[1]), int.Parse(l[0]));
            var config = ConfiguracionModel.GetConfig();
            if (f.Month == config.MesActual && f.Year == config.AnoActual)
            {
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }

}