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
    public partial class SubreportTotalIngresosFecha : DevExpress.XtraReports.UI.XtraReport
    {
        public SubreportTotalIngresosFecha()
        {
            InitializeComponent();
            // Info de los parametros
            

        }

        public void CargarDatos()
        {

            //datos
            var db = new Entities();
            var config = ConfiguracionModel.GetConfig();
            var fechaIni = (DateTime)FechaInicio.Value;
            var fechaFin = (DateTime)FechaFin.Value;

            var result = new List<dynamic>();
            var lista = Concepto.Value.ToString().Split(',');
            foreach (var s in lista)
            {
                if (s != "")
                {
                    var id = int.Parse(s);
                    var data = from i in db.IngresoFinanzas
                               where i.fecha >= fechaIni && i.fecha <= fechaFin && i.ConceptoIngresoid == id
                               orderby i.fecha, i.ConceptoIngresoid
                               select new
                               {
                                   i.Cuentas.TipoMoneda,
                                   i.importe
                               };
                    result.AddRange(data); 
                }
            }
            var resultFinal = from r in result
                              group r by r.TipoMoneda
                              into resulGroup
                              select new
                                         {
                                             moneda = resulGroup.Key,
                                             importe = resulGroup.Sum(i => (decimal)i.importe)
                                         };
            
            
            DataSource = resultFinal.ToList();

            this.monedaCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "moneda")});

            this.importeCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "importe")});
        }

    }
}
