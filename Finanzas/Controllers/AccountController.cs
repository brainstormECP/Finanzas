using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Finanzas.Filters;
using Finanzas.Models;

namespace GestionZafra.Controllers
{
    public class AccountController : Controller
    {
        Entities db = new Entities();
        //
        // GET: /Login/
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Login/Login

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = db.Usuario.FirstOrDefault(u => u.nombreUsuario.Equals(model.UserName) && u.activo);
                if (user == null)
                {
                    ModelState.AddModelError("", "Este usuario esta desactivado");
                    return View(model);
                }
                if (CompareEqualsPasswords(user.pass,model.Password))
                {
                    Session.Add("usuarioActual", user);
                    return RedirectToAction("Index", "Home");
                }
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "El nombre de usuario o la contreseña son incorrectos");
            return View(model);
        }

        [HandleError]
        [LoginFilter(Rol = "Todos")]
        public ActionResult LogOff()
        {
            Session.Remove("usuarioActual");
            return RedirectToAction("Login", "Account");
        }

        [LoginFilter(Rol = "Todos")]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [LoginFilter(Rol = "Todos")]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel changePasswordModel)
        {
            var usuarioactual = Session["usuarioActual"] as Usuario;
            var usuario = db.Usuario.Find(usuarioactual.id);
            MD5 crypto = MD5.Create();
            var passcryto = Convert.ToBase64String(crypto.ComputeHash(Encoding.UTF8.GetBytes(changePasswordModel.NewPassword)));
            usuario.pass = passcryto;
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                Session.Remove("usuarioActual");
                Session.Add("usuarioActual", usuario);
                return RedirectToAction("Index", "Home");
            }
            return View(changePasswordModel);
        }

        [HttpPost]
        public JsonResult CheckOldPassword(string OldPassword)
        {
            var result = true;
            var usuario = Session["usuarioActual"] as Usuario;
            result = CompareEqualsPasswords(usuario.pass, OldPassword);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult CheckLoginPassword(string Password, string UserName)
        {
            var result = true;
            try
            {
                var user = db.Usuario.First(u => u.nombreUsuario == UserName && u.activo);
                result = CompareEqualsPasswords(user.pass, Password);
            }
            catch (Exception)
            {
                result = false;
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult CheckLoginUser(string UserName)
        {
            var result = true;
            try
            {
                var user = db.Usuario.First(u => u.nombreUsuario == UserName && u.activo);
            }
            catch (Exception)
            {
                result = false;
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }



        public static bool CompareEqualsPasswords(string pass1, string pass2)
        {
            MD5 crypto = MD5.Create();
            var passcryto = Convert.ToBase64String(crypto.ComputeHash(Encoding.UTF8.GetBytes(pass2)));
            return pass1.Equals(passcryto);
        }

    }
}
