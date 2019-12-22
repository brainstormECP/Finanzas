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
    public class IngresoFinanzaController : Controller
    {
        Entities db = new Entities();
        private static IngresoFinanzas ingresoAnterior = new IngresoFinanzas();

        //
        // GET: /IngresoFinanza/

        public ActionResult Index()
        {
            var config = ConfiguracionModel.GetConfig();

            var ingresofinanzas = db.IngresoFinanzas.Where(i => i.Cuentas.activo).Include(i => i.ConceptoIngreso).Include(i => i.Cuentas).Include(i => i.Usuario).Include(i => i.Persona).Where(i => i.fecha.Month == config.MesActual && i.fecha.Year == config.AnoActual);
            return View(ingresofinanzas.ToList());
        }

        //
        // GET: /IngresoFinanza/Create

        public ActionResult Create()
        {
            ViewBag.ConceptoIngresoid = new SelectList(db.ConceptoIngreso, "id", "concepto");
            ViewBag.Cuentasid = new SelectList(db.Cuentas.Where(c => c.activo), "id", "nombre");
            var personas = from p in db.Persona
                           where p.activo
                           select new { p.id, nombre = p.nombre + " " + p.apellido1 + " " + (p.apellido2 ?? "") };
            ViewBag.Personaid = new SelectList(personas, "id", "nombre");
            return View();
        }

        //
        // POST: /IngresoFinanza/Create

        [HttpPost]
        public ActionResult Create(IngresoFinanzas ingresofinanzas)
        {
            if (ModelState.IsValid)
            {
                var user = Session["usuarioActual"] as Usuario;
                ingresofinanzas.Usuarioid = user.id;
                var cuenta = db.Cuentas.Find(ingresofinanzas.Cuentasid);
                cuenta.importe += ingresofinanzas.importe;
                db.Entry(cuenta).State = EntityState.Modified;
                db.IngresoFinanzas.Add(ingresofinanzas);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.ConceptoIngresoid = new SelectList(db.ConceptoIngreso, "id", "concepto", ingresofinanzas.ConceptoIngresoid);
            ViewBag.Cuentasid = new SelectList(db.Cuentas.Where(c => c.activo), "id", "nombre", ingresofinanzas.Cuentasid);
            var personas = from p in db.Persona
                           where p.activo
                           select new { p.id, nombre = p.nombre + " " + p.apellido1 + " " + (p.apellido2 ?? "") };
            ViewBag.Personaid = new SelectList(personas, "id", "nombre", ingresofinanzas.Personaid);
            return View(ingresofinanzas);
        }

        //
        // GET: /IngresoFinanza/Edit/5

        public ActionResult Edit(int id = 0)
        {

            IngresoFinanzas ingresofinanzas = db.IngresoFinanzas.Find(id);
            if (ingresofinanzas == null)
            {
                return HttpNotFound();
            }
            ingresoAnterior = ingresofinanzas;
            ViewBag.ConceptoIngresoid = new SelectList(db.ConceptoIngreso, "id", "concepto", ingresofinanzas.ConceptoIngresoid);
            ViewBag.Cuentasid = new SelectList(db.Cuentas.Where(c => c.activo), "id", "nombre", ingresofinanzas.Cuentasid);
            var personas = from p in db.Persona
                           where p.activo
                           select new { p.id, nombre = p.nombre + " " + p.apellido1 + " " + (p.apellido2 ?? "") };
            ViewBag.Personaid = new SelectList(personas, "id", "nombre", ingresofinanzas.Personaid);
            return View(ingresofinanzas);
        }

        //
        // POST: /IngresoFinanza/Edit/5

        [HttpPost]
        public ActionResult Edit(IngresoFinanzas ingresofinanzas)
        {
            if (ModelState.IsValid)
            {
                var user = Session["usuarioActual"] as Usuario;
                ingresofinanzas.Usuarioid = user.id;

                var cuentaAnterior = db.Cuentas.Find(ingresoAnterior.Cuentasid);

                if (cuentaAnterior.importe - ingresofinanzas.importe >= 0)
                {
                    cuentaAnterior.importe -= ingresofinanzas.importe;
                }
                else
                {
                    throw new Exception("La cuanta de la que desea extraer no tiene ese importe, no puede borrar este ingreso mientras la cuenta no tenga el importe suficiente");
                }

                var cuenta = db.Cuentas.Find(ingresofinanzas.Cuentasid);
                cuenta.importe += ingresofinanzas.importe;

                db.Entry(cuenta).State = EntityState.Modified;
                db.Entry(cuentaAnterior).State = EntityState.Modified;
                db.Entry(ingresofinanzas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConceptoIngresoid = new SelectList(db.ConceptoIngreso, "id", "concepto", ingresofinanzas.ConceptoIngresoid);
            ViewBag.Cuentasid = new SelectList(db.Cuentas, "id", "nombre", ingresofinanzas.Cuentasid);
            var personas = from p in db.Persona
                           where p.activo
                           select new { p.id, nombre = p.nombre + " " + p.apellido1 + " " + (p.apellido2 ?? "") };
            ViewBag.Personaid = new SelectList(personas, "id", "nombre", ingresofinanzas.Personaid);
            return View(ingresofinanzas);
        }

        //
        // GET: /IngresoFinanza/Delete/5

        public ActionResult Delete(int id = 0)
        {
            IngresoFinanzas ingresofinanzas = db.IngresoFinanzas.Find(id);
            if (ingresofinanzas == null)
            {
                return HttpNotFound();
            }
            return View(ingresofinanzas);
        }

        //
        // POST: /IngresoFinanza/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {

            IngresoFinanzas ingresofinanzas = db.IngresoFinanzas.Find(id);

            var cuenta = ingresofinanzas.Cuentas;

            if (cuenta.importe - ingresofinanzas.importe >= 0)
            {
                cuenta.importe -= ingresofinanzas.importe;
            }
            else
            {
                throw new Exception("La cuanta de la que desea extraer no tiene ese importe, no puede borrar este ingreso mientras la cuenta no tenga el importe suficiente");
            }
            db.Entry(cuenta).State = EntityState.Modified;
            db.IngresoFinanzas.Remove(ingresofinanzas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
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