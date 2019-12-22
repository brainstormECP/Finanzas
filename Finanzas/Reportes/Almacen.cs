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
    public partial class Almacen : DevExpress.XtraReports.UI.XtraReport
    {
        public Almacen()
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

            var db = new Entities();
            var result = from c in db.Almacen select c;
            var data = new List<dynamic>();
            foreach (var r in result)
            {
                data.Add(new { r.Producto, cantidad = (r.cantidad + " " + r.Producto.UnidadMedida.siglas), r.precio, r.TipoMoneda });
            }
            
            DataSource = data;

            this.productoCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Producto")});

            this.cantidadCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cantidad")});

            this.monedaCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TipoMoneda")});
            
            this.precioCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "precio")});

        }
    }
}
