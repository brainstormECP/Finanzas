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
    public partial class SubreportGastoTotal : DevExpress.XtraReports.UI.XtraReport
    {
        public SubreportGastoTotal()
        {
            InitializeComponent();
            // Info de los parametros
            

        }

        public void CargarDatos()
        {

            //datos
            var db = new Entities();
            var config = ConfiguracionModel.GetConfig();
            var cat = Categoria.Value.ToString();

            var data = from i in db.GastoFinanzas
                       where i.fecha.Month == config.MesActual && i.fecha.Year == config.AnoActual
                       group i by i.Cuentas.TipoMoneda into cuentaGroup
                       select new
                       {
                           moneda = cuentaGroup.Key,
                           importe = cuentaGroup.Sum(c => c.importe)
                       };
            
            DataSource = data.ToList();

            this.monedaCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "moneda")});

            this.importeCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "importe")});
        }

    }
}
