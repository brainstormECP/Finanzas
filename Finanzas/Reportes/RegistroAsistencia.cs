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
    public partial class RegistroAsistencia : DevExpress.XtraReports.UI.XtraReport
    {
        public RegistroAsistencia()
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
            //Encabezado
            var config = ConfiguracionModel.GetConfig();
            int trim = int.Parse(Trimestre.Value.ToString());
            var primerDomingo = new DateTime(config.AnoActual, trim, 1);
            
            while (primerDomingo.DayOfWeek != DayOfWeek.Sunday)
            {
                primerDomingo = primerDomingo.AddDays(1);
            }
            var actualMes = primerDomingo.Month;
            var ultimoMes = primerDomingo.Month + 2;
            var nombreMes = 1;
            var nombreDom = 1;

            mes1Cell.Text = Mes(ultimoMes - 2);
            mes2Cell.Text = Mes(ultimoMes - 1);
            mes3Cell.Text = Mes(ultimoMes);

            while (primerDomingo.Month <= ultimoMes)
            {
                string nombreControl = "mes" + nombreMes + "Dom" + nombreDom + "Cell";
                var control = FindControl(nombreControl, false);
                control.Text = primerDomingo.Day.ToString();
                primerDomingo = primerDomingo.AddDays(7);
                if (actualMes != primerDomingo.Month)
                {
                    actualMes++;
                    nombreMes++;
                    nombreDom = 1;
                }
                else
                {
                    nombreDom++;
                }
            }


            //fin de encabezado

            //datos
            var db = new Entities();

            var result = new List<dynamic>();
            var lista = ListaCategoria.Value.ToString().Split(',');
            foreach (var s in lista)
            {
                if (s != "")
                {
                    var id = int.Parse(s);
                    var data = from i in db.Persona
                               where i.activo
                               && i.CategoriaPersonaid == id
                               select new { nombre = i };
                    result.AddRange(data);
                }
            }
            
            DataSource = result;

            this.nombreCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "nombre")});
        }

        public static string Mes(int mes)
        {
            switch (mes)
            {
                case 1:
                    return "Enero";
                case 2:
                    return "Febrero";
                case 3:
                    return "Marzo";
                case 4:
                    return "Abril";
                case 5:
                    return "Mayo";
                case 6:
                    return "Junio";
                case 7:
                    return "Julio";
                case 8:
                    return "Agosto";
                case 9:
                    return "Septiembre";
                case 10:
                    return "Octubre";
                case 11:
                    return "Noviembre";
                case 12:
                    return "Diciembre";
            }
            return "";
        }

    }
}
