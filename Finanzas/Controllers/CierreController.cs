using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Finanzas.Filters;
using Finanzas.Models;

namespace Finanzas.Controllers
{
    [LoginFilter(Rol = "Tesorero")]
    public class CierreController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cerrar()
        {
            var config = ConfiguracionModel.GetConfig();
            config.CambiarMes();
            return RedirectToAction("Index", "Home");
        }
    }
}
