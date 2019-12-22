using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;
using Finanzas.Models;

namespace Finanzas.Reportes
{
    public partial class Salidas : DevExpress.XtraReports.UI.XtraReport
    {
        public Salidas()
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

            var data = from i in db.SalidaAlmacen
                       where i.fecha.Month == config.MesActual && i.fecha.Year == config.AnoActual
                           select new
                           {
                               i.fecha,
                               producto = i.Almacen,
                               i.cantidad,
                               tipoAyuda = i.TipoAyuda
                           };

            DataSource = data.ToList();

            this.fechaCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "fecha","{0:dd/M/yyyy}")});

            this.productoCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "producto")});

            this.cantidadCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cantidad")});

            this.tipoAyudaCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tipoAyuda")});
        }

    }
}
