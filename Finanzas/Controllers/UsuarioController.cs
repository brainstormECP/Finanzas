using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Finanzas.Filters;
using Finanzas.Models;

namespace Finanzas.Controllers
{
    [LoginFilter(Rol = "Administrador")]
    public class UsuarioController : Controller
    {
        Entities db = new Entities();

        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(u => u.Rol);
            return View(usuario.Where(u => u.nombreUsuario != "admin").ToList());
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create()
        {
            ViewBag.Rolid = new SelectList(db.Rol, "id", "nombreRol");
            return View();
        }

        //
        // POST: /Usuario/Create

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                MD5 crypto = MD5.Create();
                var passcryto = Convert.ToBase64String(crypto.ComputeHash(Encoding.UTF8.GetBytes(usuario.pass)));
                usuario.pass = passcryto;
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.Rolid = new SelectList(db.Rol, "id", "nombreRol", usuario.Rolid);
            return View(usuario);
        }

        //
        // GET: /Usuario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            if (usuario.nombreUsuario == "admin")
            {
                throw new Exception("No se puede modificar este usuario");
            }
            ViewBag.Rolid = new SelectList(db.Rol, "id", "nombreRol", usuario.Rolid);
            return View(usuario);
        }

        //
        // POST: /Usuario/Edit/5

        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (usuario.nombreUsuario == "admin")
                {
                    throw new Exception("No se puede modificar este usuario");
                }
                MD5 crypto = MD5.Create();
                var passcryto = Convert.ToBase64String(crypto.ComputeHash(Encoding.UTF8.GetBytes(usuario.pass)));
                usuario.pass = passcryto;
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Rolid = new SelectList(db.Rol, "id", "nombreRol", usuario.Rolid);
            return View(usuario);
        }

        //
        // GET: /Usuario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            if (usuario.nombreUsuario == "admin")
            {
                throw new Exception("No se puede borrar este usuario");
            }
            return View(usuario);
        }

        //
        // POST: /Usuario/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario.nombreUsuario == "admin")
            {
                throw new Exception("No se puede borrar este usuario");
            }
            try
            {
                db.Usuario.Remove(usuario);
                db.SaveChanges();
            }
            catch (Exception)
            {
                usuario.activo = false;
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                throw new Exception("Este usuario es usado en otras relaciones no se puede borrar pero ha sido marcado como Inactivo");
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public JsonResult CheckUsuario(string nombreUsuario, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                var item = db.Usuario.FirstOrDefault(i => i.nombreUsuario.ToLower() == nombreUsuario.ToLower());
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.Usuario.FirstOrDefault(i => i.nombreUsuario.ToLower() == nombreUsuario.ToLower() && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}