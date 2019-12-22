using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;
using Finanzas.Models;

namespace Finanzas.Reportes
{
    public partial class IngresosXFecha : DevExpress.XtraReports.UI.XtraReport
    {
        public IngresosXFecha()
        {
            InitializeComponent();
            // Info de los parametros
            var config = ConfiguracionModel.GetConfig();

            this.mesLabel.Text = config.MesActual.ToString();

            this.yearLabel.Text = config.AnoActual.ToString();

            this.fechaLabel.Text = DateTime.Now.Date.ToShortDateString();
            //fin Info de los parametros

        }

        public void CargarDatos()
        {

            //datos
            var db = new Entities();
            var config = ConfiguracionModel.GetConfig();
            var fechaIni = (DateTime)FechaInicio.Value;
            var fechaFin = (DateTime)FechaFin.Value;

            var result = new List<dynamic>();
                var lista = ListaConceptos.Value.ToString().Split(',');
            foreach (var s in lista)
            {
                if (s != "")
                {
                    var id = int.Parse(s);
                    var data = from i in db.IngresoFinanzas
                               where i.fecha >= fechaIni && i.fecha <= fechaFin && i.ConceptoIngresoid == id
                               orderby i.fecha, i.ConceptoIngresoid
                               select new
                               {
                                   i.fecha,
                                   i.importe,
                                   cuenta = i.Cuentas,
                                   i.ConceptoIngreso.concepto,
                                   descripcion = i.descripcion == null ? " Tramitado por: " + i.Usuario.nombreUsuario : i.descripcion + " Tramitado por: " + i.Usuario.nombreUsuario,
                               };
                    result.AddRange(data); 
                }
            }

           

            DataSource = result;

            this.fechaCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "fecha","{0:dd/M/yyyy}")});

            this.importeCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "importe")});

            this.cuentaCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cuenta")});

            this.conceptoCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "concepto")});

            this.descripcionCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "descripcion")});
            xrSubreport1.ReportSource = new SubreportTotalIngresosFecha();
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var report = ((SubreportTotalIngresosFecha)((XRSubreport)sender).ReportSource);
            report.Concepto.Value = ListaConceptos.Value;
            report.FechaInicio.Value = FechaInicio.Value;
            report.FechaFin.Value = FechaFin.Value;
            report.CargarDatos();
        }

    }
}
