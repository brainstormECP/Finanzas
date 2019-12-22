using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;
using Finanzas.Models;

namespace Finanzas.Reportes
{
    public partial class Miembros : DevExpress.XtraReports.UI.XtraReport
    {
        public Miembros()
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

            var data = from i in db.Persona
                       where i.activo && i.miembro
                       orderby i.CategoriaPersonaid
                       select new
                       {
                           nombre = i,
                           fechaNac = i.fechaNacimiento,
                           fechaConv = i.fechaConversion,
                           fechaBaut = i.fechaBautismo,
                           i.CategoriaPersona.categoria,
                       };

            DataSource = data.ToList();

            this.nombreCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "nombre")});

            this.fechaNacimCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "fechaNac","{0:dd/M/yyyy}")});

            this.fechaConvCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "fechaConv","{0:dd/M/yyyy}")});

            this.fechaBautCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "fechaBaut","{0:dd/M/yyyy}")});

            this.categoriaCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "categoria")});
        }

    }
}
