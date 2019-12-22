using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Finanzas.Filters;
using Finanzas.Models;

namespace Finanzas.Controllers
{
    [LoginFilter(Rol = "Administrador")]
    public class ConfigController : Controller
    {
        Entities db = new Entities();

        //
        // GET: /Config/

        public ActionResult Index()
        {
            try
            {
                var model = ConfiguracionModel.GetConfig();
                //if (db.Cuentas.Any(c => c.TipoMoneda.siglas.ToUpper() == "CUC") || db.Cuentas.Any(c => c.TipoMoneda.siglas.ToUpper() == "MN"))
                //{
                //    return RedirectToAction("Create", "Cuenta");
                //}
                var meses = new List<dynamic> { new { mes = "Enero", id = 1 }, new { mes = "Febrero", id = 2 } 
                , new { mes = "Marzo", id = 3 }, new { mes = "Abril", id = 4 }
                , new { mes = "Mayo", id = 5 }, new { mes = "Junio", id = 6 }
                , new { mes = "Julio", id = 7 }, new { mes = "Agosto", id = 8 }
                , new { mes = "Septiembre", id = 9 }, new { mes = "Octubre", id = 10 }
                , new { mes = "Noviembre", id = 11 }, new { mes = "Diciembre", id = 12 }};
                ViewBag.MesActual = new SelectList(meses,"id","mes",model.MesActual);
                return View(model);
            }
            catch (Exception)
            {

                throw new Exception("No se encontro el fichero de configuracion");
            }
        }

        [HttpPost]
        public ActionResult Index(ConfiguracionModel configuracion)
        {
            //var ing = db.IngresoFinanzas.FirstOrDefault(i => i.fecha.Month == configuracion.MesActual && i.fecha.Year == configuracion.AnoActual);
            //var gast = db.GastoFinanzas.FirstOrDefault(i => i.fecha.Month == configuracion.MesActual && i.fecha.Year == configuracion.AnoActual);
            //if (ing != null || gast != null)
            //{
            //   ModelState.AddModelError("","Ya este mes esta en proceso o se cerro, no se puede seleccionar");
            //}
            if (ModelState.IsValid)
            {
                configuracion.SaveConfig();
                return RedirectToAction("Index","Home"); 
            }
            var meses = new List<dynamic> { new { mes = "Enero", id = 1 }, new { mes = "Febrero", id = 2 } 
                , new { mes = "Marzo", id = 3 }, new { mes = "Abril", id = 4 }
                , new { mes = "Mayo", id = 5 }, new { mes = "Junio", id = 6 }
                , new { mes = "Julio", id = 7 }, new { mes = "Agosto", id = 8 }
                , new { mes = "Septiembre", id = 9 }, new { mes = "Octubre", id = 10 }
                , new { mes = "Noviembre", id = 11 }, new { mes = "Diciembre", id = 12 }};
            ViewBag.MesActual = new SelectList(meses, "id", "mes", configuracion.MesActual);
            return View(configuracion);
        }
    }
}
