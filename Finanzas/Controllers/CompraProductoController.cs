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
    public class CompraProductoController : Controller
    {
        Entities db = new Entities();
        private static CompraProducto compraAnterior;

        //
        // GET: /CompraProducto/

        public ActionResult Index()
        {
            var config = ConfiguracionModel.GetConfig();
            var compraproducto = db.CompraProducto.Include(c => c.Producto).Include(c => c.Usuario).Include(c => c.Cuentas).Where(i => i.fecha.Month == config.MesActual && i.fecha.Year == config.AnoActual);
            return View(compraproducto.ToList());
        }

        //
        // GET: /CompraProducto/Create

        public ActionResult Create()
        {
            ViewBag.Productoid = new SelectList(db.Producto, "id", "nombre");
            var cta = db.Cuentas.Where(c => c.activo);
            ViewBag.Cuentasid = new SelectList(cta, "id", "nombre");
            return View();
        }

        //
        // POST: /CompraProducto/Create

        [HttpPost]
        public ActionResult Create(CompraProducto compraproducto)
        {
            if (ModelState.IsValid)
            {
                var user = Session["usuarioActual"] as Usuario;
                compraproducto.Usuarioid = user.id;
                var compraHecha = db.CompraProducto.Add(compraproducto);
                var cuenta = db.Cuentas.FirstOrDefault(c => c.id == compraproducto.Cuentasid);

                var precioProducto = compraproducto.importe / compraproducto.cantidad;
                var almacen =
                    db.Almacen.FirstOrDefault(
                        p => p.Productoid == compraproducto.Productoid && p.precio == precioProducto && p.TipoMonedaid == cuenta.TipoMonedaid);
                if (almacen == null)
                {
                    var newAlmacen = new Almacen()
                                         {
                                             cantidad = compraproducto.cantidad,
                                             precio = precioProducto,
                                             Productoid = compraproducto.Productoid,
                                             TipoMonedaid = cuenta.TipoMonedaid
                                         };
                    db.Almacen.Add(newAlmacen);
                }
                else
                {
                    almacen.cantidad += compraproducto.cantidad;
                    db.Entry(almacen).State = EntityState.Modified;
                }
                
                cuenta.importe -= compraproducto.importe;
                db.Entry(cuenta).State = EntityState.Modified;
                db.SaveChanges();
                var gasto = new GastoFinanzas() {
                    fecha = compraproducto.fecha,
                    Cuentasid = compraproducto.Cuentasid,
                    ConceptoGastoid = 1,
                    Usuarioid = compraproducto.Usuarioid,
                    importe = compraproducto.importe,
                    descripcion = "Id de compra: [" + compraHecha.id +"] Compra de Productos del proyecto un grano de arena"};
                db.GastoFinanzas.Add(gasto);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.Productoid = new SelectList(db.Producto, "id", "nombre", compraproducto.Productoid);
            var cta = db.Cuentas.Where(c => c.activo);
            ViewBag.Cuentasid = new SelectList(cta, "id", "nombre", compraproducto.Cuentasid);
            return View(compraproducto);
        }

        //
        // GET: /CompraProducto/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CompraProducto compraproducto = db.CompraProducto.Find(id);
            if (compraproducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Productoid = new SelectList(db.Producto, "id", "nombre", compraproducto.Productoid);
            var cta = db.Cuentas.Where(c => c.activo);
            ViewBag.Cuentasid = new SelectList(cta, "id", "nombre", compraproducto.Cuentasid);
            compraAnterior = compraproducto;
            return View(compraproducto);
        }

        //
        // POST: /CompraProducto/Edit/5

        [HttpPost]
        public ActionResult Edit(CompraProducto compraproducto)
        {
            if (ModelState.IsValid)
            {
                var user = Session["usuarioActual"] as Usuario;
                compraproducto.Usuarioid = user.id;
                db.Entry(compraproducto).State = EntityState.Modified;
                //anterior
                var precioProductoAnterior = compraAnterior.importe / compraAnterior.cantidad;
                var cuentaAnterior = db.Cuentas.FirstOrDefault(c => c.id == compraAnterior.Cuentasid);
                var almacenAnterior =
                    db.Almacen.FirstOrDefault(
                        p => p.Productoid == compraAnterior.Productoid && p.precio == precioProductoAnterior && p.TipoMonedaid == cuentaAnterior.TipoMonedaid);
                

                //actual
                var precioProducto = compraproducto.importe / compraproducto.cantidad;
                var cuenta = db.Cuentas.FirstOrDefault(c => c.id == compraproducto.Cuentasid);
                var almacen =
                    db.Almacen.FirstOrDefault(
                        p => p.Productoid == compraproducto.Productoid && p.precio == precioProducto && p.TipoMonedaid == cuenta.TipoMonedaid);
               

                if (almacen == null)
                {
                    var newAlmacen = new Almacen()
                    {
                        cantidad = compraproducto.cantidad,
                        precio = precioProducto,
                        Productoid = compraproducto.Productoid,
                        TipoMonedaid = cuenta.TipoMonedaid
                    };
                    db.Almacen.Add(newAlmacen);
                }
                else
                {
                    almacen.cantidad += compraproducto.cantidad;
                    db.Entry(almacen).State = EntityState.Modified;
                }
                almacenAnterior.cantidad -= compraAnterior.cantidad;
                cuentaAnterior.importe += compraAnterior.importe;
                cuenta.importe -= compraproducto.importe;

                var gastos = db.GastoFinanzas.Where(g => g.fecha == compraAnterior.fecha);
                var gasto = new GastoFinanzas();
                foreach (var g in gastos)
                {
                    if (int.Parse(g.descripcion.Split('[')[1].Split(']')[0]) == compraproducto.id)
                    {
                        gasto = g;
                    }
                }
                gasto.importe = compraproducto.importe;
                gasto.fecha = compraproducto.fecha;

                db.Entry(gasto).State = EntityState.Modified;
                db.Entry(almacenAnterior).State = EntityState.Modified;
                db.Entry(cuenta).State = EntityState.Modified;
                db.Entry(cuentaAnterior).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Productoid = new SelectList(db.Producto, "id", "nombre", compraproducto.Productoid);
            var cta = db.Cuentas.Where(c => c.activo);
            ViewBag.Cuentasid = new SelectList(cta, "id", "nombre", compraproducto.Cuentasid);
            return View(compraproducto);
        }

        //
        // GET: /CompraProducto/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CompraProducto compraproducto = db.CompraProducto.Find(id);
            if (compraproducto == null)
            {
                return HttpNotFound();
            }
            return View(compraproducto);
        }

        //
        // POST: /CompraProducto/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                CompraProducto compraproducto = db.CompraProducto.Find(id);
                db.CompraProducto.Remove(compraproducto);

                var precioProducto = compraproducto.importe / compraproducto.cantidad;
                var cuenta = db.Cuentas.FirstOrDefault(c => c.id == compraproducto.Cuentasid);
                var almacen =
                    db.Almacen.FirstOrDefault(
                        p => p.Productoid == compraproducto.Productoid && p.precio == precioProducto && p.TipoMonedaid == cuenta.TipoMonedaid);
                

                almacen.cantidad -= compraproducto.cantidad;
                cuenta.importe += compraproducto.importe;

                db.Entry(almacen).State = EntityState.Modified;
                db.Entry(cuenta).State = EntityState.Modified;

                var gastos = db.GastoFinanzas.Where(g => g.fecha == compraproducto.fecha);
                var gasto = new GastoFinanzas();
                foreach (var g in gastos)
                {
                    if(int.Parse(g.descripcion.Split('[')[1].Split(']')[0]) == compraproducto.id)
                    {
                        gasto = g;
                    }
                }
                db.GastoFinanzas.Remove(gasto);

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


        public JsonResult CheckSaldo(decimal importe, int Cuentasid)
        {
            var result = false;
            var cta = db.Cuentas.Find(Cuentasid);
            if (importe <= cta.importe)
            {
                result = true;
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