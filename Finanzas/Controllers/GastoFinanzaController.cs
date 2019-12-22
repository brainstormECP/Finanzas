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
    public class GastoFinanzaController : Controller
    {
        private static GastoFinanzas gastoAnterior = new GastoFinanzas();

        Entities db = new Entities();

        //
        // GET: /GastoFinanza/

        public ActionResult Index()
        {
            var config = ConfiguracionModel.GetConfig();

            var gastofinanzas = db.GastoFinanzas.Include(g => g.ConceptoGasto).Include(g => g.Cuentas).Include(g => g.Usuario).Include(g => g.SubconceptoGasto).Where(g => g.fecha.Month == config.MesActual && g.fecha.Year == config.AnoActual);
            return View(gastofinanzas.ToList());
        }

        //
        // GET: /GastoFinanza/Create

        public ActionResult Create()
        {
            ViewBag.ConceptoGastoid = new SelectList(db.ConceptoGasto.Where(c => c.id != 1), "id", "concepto");
            ViewBag.Cuentasid = new SelectList(db.Cuentas, "id", "nombre");
            ViewBag.SubconceptoGastoid = new SelectList(db.SubconceptoGasto, "id", "subconcepto");
            return View();
        }

        //
        // POST: /GastoFinanza/Create

        [HttpPost]
        public ActionResult Create(GastoFinanzas gastofinanzas)
        {
            var subconcep = db.SubconceptoGasto.Find(gastofinanzas.SubconceptoGastoid);
            if (gastofinanzas.ConceptoGastoid != subconcep.ConceptoGastoid)
            {
                ModelState.AddModelError("","El subconcepto seleccionado no se corresponde con el concepto seleccionado"); 
            }
            if (ModelState.IsValid)
            {
                var user = Session["usuarioActual"] as Usuario;
                gastofinanzas.Usuarioid = user.id;

                var cuenta = db.Cuentas.Find(gastofinanzas.Cuentasid);
                cuenta.importe -= gastofinanzas.importe;

                db.GastoFinanzas.Add(gastofinanzas);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.ConceptoGastoid = new SelectList(db.ConceptoGasto.Where(c => c.id != 1), "id", "concepto", gastofinanzas.ConceptoGastoid);
            ViewBag.Cuentasid = new SelectList(db.Cuentas, "id", "nombre", gastofinanzas.Cuentasid);
            ViewBag.SubconceptoGastoid = new SelectList(db.SubconceptoGasto, "id", "subconcepto", gastofinanzas.SubconceptoGastoid);
            return View(gastofinanzas);
        }

        //
        // GET: /GastoFinanza/Edit/5

        public ActionResult Edit(int id = 0)
        {
            GastoFinanzas gastofinanzas = db.GastoFinanzas.Find(id);
            if (gastofinanzas.ConceptoGastoid == 1)
            {
                throw new Exception("No puede editar un gasto de Grano de Arena");
            }
            if (gastofinanzas == null)
            {
                return HttpNotFound();
            }
            gastoAnterior = gastofinanzas;
            ViewBag.ConceptoGastoid = new SelectList(db.ConceptoGasto.Where(c => c.id != 1), "id", "concepto", gastofinanzas.ConceptoGastoid);
            ViewBag.Cuentasid = new SelectList(db.Cuentas, "id", "nombre", gastofinanzas.Cuentasid);
            ViewBag.SubconceptoGastoid = new SelectList(db.SubconceptoGasto, "id", "subconcepto", gastofinanzas.SubconceptoGastoid);
            return View(gastofinanzas);
        }

        //
        // POST: /GastoFinanza/Edit/5

        [HttpPost]
        public ActionResult Edit(GastoFinanzas gastofinanzas)
        {
            var subconcep = db.SubconceptoGasto.Find(gastofinanzas.SubconceptoGastoid);
            if (gastofinanzas.ConceptoGastoid != subconcep.ConceptoGastoid)
            {
                ModelState.AddModelError("", "El subconcepto seleccionado no se corresponde con el concepto seleccionado");
            }
            if (ModelState.IsValid)
            {
                var user = Session["usuarioActual"] as Usuario;
                gastofinanzas.Usuarioid = user.id;

                var cuentaAnterior = db.Cuentas.Find(gastoAnterior.Cuentasid);
                cuentaAnterior.importe += gastoAnterior.importe;

                var cuenta = db.Cuentas.Find(gastofinanzas.Cuentasid);
                cuenta.importe -= gastofinanzas.importe;
                 
                db.Entry(gastofinanzas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConceptoGastoid = new SelectList(db.ConceptoGasto.Where(c => c.id != 1), "id", "concepto", gastofinanzas.ConceptoGastoid);
            ViewBag.Cuentasid = new SelectList(db.Cuentas, "id", "nombre", gastofinanzas.Cuentasid);
            ViewBag.SubconceptoGastoid = new SelectList(db.SubconceptoGasto, "id", "subconcepto", gastofinanzas.SubconceptoGastoid);
            return View(gastofinanzas);
        }

        //
        // GET: /GastoFinanza/Delete/5

        public ActionResult Delete(int id = 0)
        {

            GastoFinanzas gastofinanzas = db.GastoFinanzas.Find(id);
            if (gastofinanzas.ConceptoGastoid == 1)
            {
                throw new Exception("No puede editar un gasto de Grano de Arena");
            }
            if (gastofinanzas == null)
            {
                return HttpNotFound();
            }
            return View(gastofinanzas);
        }

        //
        // POST: /GastoFinanza/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                GastoFinanzas gastofinanzas = db.GastoFinanzas.Find(id);
                db.GastoFinanzas.Remove(gastofinanzas);
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

        [HttpPost]
        public JsonResult CheckImporte(decimal importe, int id = 0, int Cuentasid = 0)
        {
            var result = false;
            if (id == 0)
            {
                var cuenta = db.Cuentas.FirstOrDefault(i => i.id == Cuentasid);
                if (cuenta.importe - importe >= 0)
                {
                    result = true;
                }

            }
            else
            {
                var cuenta = db.Cuentas.FirstOrDefault(i => i.id == Cuentasid);
                if (cuenta.id == gastoAnterior.Cuentasid)
                {
                    if ((cuenta.importe + gastoAnterior.importe) - importe >= 0)
                    {
                        result = true;
                    }
                }
                else
                {
                    if (cuenta.importe - importe >= 0)
                    {
                        result = true;
                    }
                }
            }
            return Json(result, JsonRequestBehavior.DenyGet);
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