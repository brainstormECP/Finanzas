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
    public partial class Diezmadores : DevExpress.XtraReports.UI.XtraReport
    {
        public Diezmadores()
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

            var data = from i in db.IngresoFinanzas
                       where i.ConceptoIngreso.concepto == "Diezmo" && i.fecha.Month == config.MesActual && i.fecha.Year == config.AnoActual
                       group i by i.Persona
                           into personaGroup
                           select new
                           {
                               persona = personaGroup.Key,
                               importeMN = personaGroup.Any(p => p.Cuentas.TipoMoneda.siglas == "MN") ? personaGroup.Where(p => p.Cuentas.TipoMoneda.siglas == "MN").Sum(j => j.importe) : 0m,
                               importeCUC = personaGroup.Any(p => p.Cuentas.TipoMoneda.siglas == "CUC") ? personaGroup.Where(p => p.Cuentas.TipoMoneda.siglas == "CUC").Sum(j => j.importe) : 0m
                           };

            DataSource = data.ToList();

            this.nombreCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "persona")});

            this.importeCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "importeMN")});

            this.monedaCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "importeCUC")});
        }

    }
}
