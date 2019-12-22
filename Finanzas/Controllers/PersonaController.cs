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
    public class PersonaController : Controller
    {
        Entities db = new Entities();

        //
        // GET: /Persona/

        public ActionResult Index()
        {
            var persona = db.Persona.Where(p => p.activo).Include(i => i.CategoriaPersona);
            return View(persona.ToList());
        }

        public ActionResult Inactivas()
        {
            var persona = db.Persona.Where(p => !p.activo).Include(i => i.CategoriaPersona);
            return View(persona.ToList());
        }

        //
        // GET: /Persona/Create

        public ActionResult Create()
        {
            ViewBag.CategoriaPersonaid = new SelectList(db.CategoriaPersona, "id", "categoria");
            ViewBag.Misionesid = new SelectList(db.Misiones, "id", "lugar");
            return View();
        }

        //
        // POST: /Persona/Create

        [HttpPost]
        public ActionResult Create(Persona persona)
        {
            if (persona.fechaBautismo == null && persona.miembro)
            {
                ModelState.AddModelError("", "La persona no puede ser miembro sino se ha bautizado");
            }
            if (ModelState.IsValid)
            {
                db.Persona.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            ViewBag.CategoriaPersonaid = new SelectList(db.CategoriaPersona, "id", "categoria", persona.CategoriaPersonaid);
            ViewBag.Misionesid = new SelectList(db.Misiones, "id", "lugar", persona.Misionesid);
            return View(persona);
        }

        //
        // GET: /Persona/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaPersonaid = new SelectList(db.CategoriaPersona, "id", "categoria", persona.CategoriaPersonaid);
            ViewBag.Misionesid = new SelectList(db.Misiones, "id", "lugar",persona.Misionesid);
            return View(persona);
        }

        //
        // POST: /Persona/Edit/5

        [HttpPost]
        public ActionResult Edit(Persona persona)
        {
            var pers = db.Persona.FirstOrDefault(p => (p.nombre + p.apellido1 + p.apellido2) == (persona.nombre + persona.apellido1 + persona.apellido2) && p.id != persona.id);
            if (pers != null)
            {
                ModelState.AddModelError("", "Ya existe una persona con este nombre y apellidos");
            }
            if (persona.fechaBautismo == null && persona.miembro)
            {
                ModelState.AddModelError("", "La persona no puede ser miembro sino se ha bautizado");
            }
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaPersonaid = new SelectList(db.CategoriaPersona, "id", "categoria", persona.CategoriaPersonaid);
            ViewBag.Misionesid = new SelectList(db.Misiones, "id", "lugar", persona.Misionesid);
            return View(persona);
        }

        //
        // GET: /Persona/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        //
        // POST: /Persona/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Persona persona = db.Persona.Find(id);
                db.Persona.Remove(persona);
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Este registro se utiliza en una relacion y no lo puede borrar, Si lo desea puede desactivarlo");
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


        public JsonResult CheckCI(string ci, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                var item = db.Persona.FirstOrDefault(i => i.ci == ci);
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.Persona.FirstOrDefault(i => i.ci == ci && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult CheckFechaNacimiento(string fechaNacimiento)
        {
            var result = true;
            var l = fechaNacimiento.Split('/');
            var f = new DateTime(int.Parse(l[2]), int.Parse(l[1]), int.Parse(l[0]));
            var config = ConfiguracionModel.GetConfig();
            if ((f.Month > config.MesActual && f.Year == config.AnoActual) || f.Year > config.AnoActual)
            {
                result = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}