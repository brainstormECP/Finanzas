using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using DevExpress.XtraReports.UI;
using Finanzas.Models;
//using Finanzas.Reportes;

namespace Finanzas.Controllers
{
    public class ReporteController : Controller
    {
        private Entities db = new Entities();
        //static XtraReport report;

        //
        // GET: /Reporte/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReportViewerPartial()
        {
            //ViewData["Report"] = report;
            //return PartialView("ReportViewerPartial");
            throw new NotImplementedException();
        }

        public ActionResult ExportReportViewer()
        {
            //return DevExpress.Web.Mvc.ReportViewerExtension.ExportTo(report);
            throw new NotImplementedException();
        }

        public ActionResult Compras()
        {
            //report = new Compras();
            return View("Plantilla");
        }

        public ActionResult Cumpleanos()
        {
            //report = new Cumpleanos();
            return View("Plantilla");
        }

        public ActionResult Diezmadores()
        {
            //report = new Diezmadores();
            return View("Plantilla");
        }

        public ActionResult Gastos()
        {
            //report = new Gastos();
            return View("Plantilla");
        }

        public ActionResult Ingresos()
        {
            //report = new Ingresos();
            return View("Plantilla");
        }

        public ActionResult Miembros()
        {
            //report = new Miembros();
            return View("Plantilla");
        }

        public ActionResult RegistroAsistencia()
        {
            
            var trimestres = new List<dynamic> { new { mes = "Enero - Marzo", id = 1 }, new { mes = "Abril - Junio", id = 4 }
                , new { mes = "Julio - Septiembre", id = 7 }, new { mes = "Octubre - Diciembre", id = 10 }};
            ViewBag.Trimestre = new SelectList(trimestres,"id","mes");
            ViewBag.CategoriaPersonaid = new SelectList(db.CategoriaPersona, "id", "categoria");
            return View();
        }

        [HttpPost]
        public ActionResult RegistroAsistencia(RegistroAsistenciaModel registro)
        {
            //string lista = registro.CategoriaPersonaid.Aggregate("", (current, i) => current + (i + ","));
            //var r = new RegistroAsistencia() { Trimestre = { Value = registro.Trimestre }, ListaCategoria = { Value = lista } };
            //r.CargarDatos();
            //report = r;
            return View("Plantilla");
        }

        public ActionResult Salidas()
        {
            //report = new Salidas();
            return View("Plantilla");
        }

        public ActionResult PersonaxCategoria()
        {
            ViewBag.CategoriaPersonaid = new SelectList(db.CategoriaPersona, "id", "categoria");
            return View();
        }

        [HttpPost]
        public ActionResult PersonaxCategoria(CategoriaModel c)
        {

            //var r = new PersonasXCategoria(){Categoria = {Value = db.CategoriaPersona.Find(c.CategoriaPersonaid).categoria}};
            //r.CargarDatos();
            //report = r;
            return View("Plantilla");
        }

        public ActionResult CumpleannoXFecha()
        {
           
            return View("Fecha");
        }

        [HttpPost]
        public ActionResult CumpleannoXFecha(FechaModel fechaModel)
        {

            //var r = new CumpleannosXFecha() { FechaInicio = { Value = fechaModel.FechaInicio }, FechaFin = { Value = fechaModel.FechaFin } };
            //r.CargarDatos();
            //report = r;
            return View("Plantilla");
        }

        public ActionResult BautizadosXFecha()
        {
            return View("Fecha");
        }

        [HttpPost]
        public ActionResult BautizadosXFecha(FechaModel fechaModel)
        {

            //var r = new BautizadosXFecha() { FechaInicio = { Value = fechaModel.FechaInicio }, FechaFin = { Value = fechaModel.FechaFin } };
            //r.CargarDatos();
            //report = r;
            return View("Plantilla");
        }

        public ActionResult ConvertidosXFecha()
        {
            return View("Fecha");
        }

        [HttpPost]
        public ActionResult ConvertidosXFecha(FechaModel fechaModel)
        {

            //var r = new ConvertidosXFecha() { FechaInicio = { Value = fechaModel.FechaInicio }, FechaFin = { Value = fechaModel.FechaFin } };
            //r.CargarDatos();
            //report = r;
            return View("Plantilla");
        }


        public ActionResult EstadosCuentas()
        {
            //var r = new EstadosCuentas();
            //r.CargarDatos();
            //report = r;
            return View("Plantilla");
        }


        public ActionResult IngresosXFecha()
        {
            ViewBag.ConceptoId = new SelectList(db.ConceptoIngreso, "id", "concepto");
            return View("IngresosFecha");
        }

        [HttpPost]
        public ActionResult IngresosXFecha(IngresosModel fechaModel)
        {
            //string lista = fechaModel.ConceptoId.Aggregate("", (current, i) => current + (i + ","));
            //var r = new IngresosXFecha() { ListaConceptos = { Value = lista }, FechaInicio = { Value = fechaModel.FechaInicio }, FechaFin = { Value = fechaModel.FechaFin } };
            //r.CargarDatos();
            //report = r;
            return View("Plantilla");
        }


        public ActionResult Almacen()
        {
            //var r = new Reportes.Almacen();
            //r.CargarDatos();
            //report = r;
            return View("Plantilla");
        }

    }
}
