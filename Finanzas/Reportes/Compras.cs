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
    public partial class Compras : DevExpress.XtraReports.UI.XtraReport
    {
        public Compras()
        {
            InitializeComponent();
            // Info de los parametros
            var config = ConfiguracionModel.GetConfig();

            this.mesLabel.Text = config.MesActual.ToString();

            this.yearLabel.Text = config.AnoActual.ToString();

            this.fechaLabel.Text = DateTime.Now.Date.ToShortDateString();
            //fin Info de los parametros

            var db = new Entities();
            var data = from i in db.CompraProducto
                       where i.fecha.Month == config.MesActual && i.fecha.Year == config.AnoActual
                       select new {i.fecha,i.Producto, i.cantidad, importe = i.importe,i.Cuentas};

            var result = new List<dynamic>();
            foreach (var d in data)
            {
                result.Add(new {fecha =  d.fecha.ToShortDateString(), d.Producto,cantidad  = d.cantidad + " " + d.Producto.UnidadMedida.siglas, d.importe,d.Cuentas});
            }

            DataSource = result;

            this.fechaCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "fecha")});

            this.productoCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Producto")});

            this.cantidadCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cantidad")});

            this.importeCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "importe")});

            this.cuentaCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Cuentas")});
        }

    }
}
