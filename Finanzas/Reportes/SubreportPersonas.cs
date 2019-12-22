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
    public partial class SubreportPersonas : DevExpress.XtraReports.UI.XtraReport
    {
        public SubreportPersonas()
        {
            InitializeComponent();
            // Info de los parametros
            var config = ConfiguracionModel.GetConfig();

        }

        public void CargarDatos()
        {

            //datos
            var db = new Entities();

            var cat = Categoria.Value.ToString();

            var data = from i in db.Persona
                       where i.activo && i.CategoriaPersona.categoria == cat
                       select new
                       {
                           nombre = i,
                           fechaNac = i.fechaNacimiento
                       };
            
            DataSource = data.ToList();

            this.nombreCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "nombre")});

            this.fechaNacimCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "fechaNac","{0:dd/M/yyyy}")});
        }

    }
}
