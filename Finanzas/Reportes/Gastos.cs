using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;
using Finanzas.Models;

namespace Finanzas.Reportes
{
    public partial class Gastos : DevExpress.XtraReports.UI.XtraReport
    {
        public Gastos()
        {
            InitializeComponent();
            // Info de los parametros
            var config = ConfiguracionModel.GetConfig();

            this.mesLabel.Text = config.MesActual.ToString();

            this.yearLabel.Text = config.AnoActual.ToString();

            this.fechaLabel.Text = DateTime.Now.Date.ToShortDateString();
            //fin Info de los parametros

            //datos
            var db = new Entities();

            var data = from i in db.GastoFinanzas
                       where i.fecha.Month == config.MesActual && i.fecha.Year == config.AnoActual
                       orderby i.fecha,i.ConceptoGastoid
                           select new
                           {
                               i.fecha,
                               i.importe,
                               cuenta = i.Cuentas,
                               concepto = i.SubconceptoGasto == null ? i.ConceptoGasto.concepto : i.ConceptoGasto.concepto + " - " + i.SubconceptoGasto.subconcepto,
                               descripcion =  i.descripcion == null?" Tramitado por: " + i.Usuario.nombreUsuario: i.descripcion + " Tramitado por: " + i.Usuario.nombreUsuario,
                               };

            DataSource = data.ToList();

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
            xrSubreport1.ReportSource = new SubreportGastoTotal();
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var report = ((SubreportGastoTotal)((XRSubreport)sender).ReportSource);
            report.CargarDatos();
        }

    }
}
