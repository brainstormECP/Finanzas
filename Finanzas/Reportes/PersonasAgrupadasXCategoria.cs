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
    public partial class PersonasAgrupadasXCategoria : DevExpress.XtraReports.UI.XtraReport
    {
        public PersonasAgrupadasXCategoria()
        {
            InitializeComponent();
            // Info de los parametros
            var config = ConfiguracionModel.GetConfig();

            this.mesLabel.Text = config.MesActual.ToString();

            this.yearLabel.Text = config.AnoActual.ToString();

            this.fechaLabel.Text = DateTime.Now.Date.ToShortDateString();
            //fin Info de los parametros

            xrSubreport1.ReportSource = new SubreportPersonas();
        }

        public void CargarDatos()
        {
            //datos
            var db = new Entities();
            var data = db.CategoriaPersona.Where(c => db.Persona.Any(p => p.CategoriaPersonaid == c.id)).ToList();
            DataSource = data;

            this.categoriaCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "categoria")});
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var report = ((SubreportPersonas)((XRSubreport)sender).ReportSource);
            report.Categoria.Value = GetCurrentColumnValue("categoria").ToString();
            report.CargarDatos();
        }

    }
}
