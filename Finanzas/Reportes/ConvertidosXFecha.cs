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
    public partial class ConvertidosXFecha : DevExpress.XtraReports.UI.XtraReport
    {
        public ConvertidosXFecha()
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
            var fechaInicio = (DateTime)FechaInicio.Value;
            var fechaFin = (DateTime)FechaFin.Value;
            var data = from i in db.Persona
                       where i.activo && i.fechaConversion.HasValue && i.fechaConversion.Value <= fechaFin && i.fechaConversion.Value >= fechaInicio
                       orderby i.fechaConversion.Value
                       select new
                       {
                           persona = i,
                           fecha = i.fechaConversion.Value,
                           edad = DateTime.Today.Year - i.fechaNacimiento.Year,
                           categoria = i.CategoriaPersona
                       };
            
            DataSource = data.ToList();

            this.nombreCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "persona")});

            this.fechaNacCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "fecha","{0:dd/M/yyyy}")});

            this.edadCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "edad")});

            this.categoriaCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "categoria")});

        }
    }
}
