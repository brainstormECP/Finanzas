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
    public partial class CumpleannosXFecha : DevExpress.XtraReports.UI.XtraReport
    {
        public CumpleannosXFecha()
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
                       where i.activo && i.fechaNacimiento.Month >= fechaInicio.Month && i.fechaNacimiento.Month <= fechaFin.Month && i.fechaNacimiento.Day >= fechaInicio.Day && i.fechaNacimiento.Day <= fechaFin.Day
                       orderby i.fechaNacimiento
                       select new
                       {
                           persona = i,
                           fecha = i.fechaNacimiento,
                           edad = DateTime.Today.Year - i.fechaNacimiento.Year,
                           categoria = i.CategoriaPersona,
                           miembro = i.miembro ? "SI" : "NO"
                       };
            var result = new List<dynamic>();
            foreach (var d in data)
            {
                result.Add(new { d.persona, fecha = Dia(d.fecha.AddYears(d.edad).DayOfWeek) + " " + d.fecha.Day + " de " + Mes(d.fecha.Month), d.edad, d.categoria, d.miembro });
            }

            DataSource = result;

            this.nombreCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "persona")});

            this.fechaNacCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "fecha")});

            this.edadCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "edad")});

            this.categoriaCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "categoria")});

            this.miembroCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "miembro")});

            
        }

        /// <summary>
        /// Devuelve el lunes donde inicia la semana actual
        /// </summary>
        /// <returns></returns>
        public static DateTime Semana()
        {
            var result = DateTime.Today;
            var inicio = result.DayOfWeek;
            switch (inicio)
            {
                case DayOfWeek.Monday:
                    return result;
                case DayOfWeek.Tuesday:
                    return result.Subtract(new TimeSpan(1,0,0,0));
                case DayOfWeek.Wednesday:
                    return result.Subtract(new TimeSpan(2, 0, 0, 0));
                case DayOfWeek.Thursday:
                    return result.Subtract(new TimeSpan(3, 0, 0, 0));
                case DayOfWeek.Friday:
                    return result.Subtract(new TimeSpan(4, 0, 0, 0));
                case DayOfWeek.Saturday:
                    return result.Subtract(new TimeSpan(5, 0, 0, 0));
                case DayOfWeek.Sunday:
                    return result.Subtract(new TimeSpan(6, 0, 0, 0));
            }
            return result;
        }

        public static string Dia(DayOfWeek dia)
        {
            switch (dia)
            {
                case DayOfWeek.Monday:
                    return "Lunes";
                case DayOfWeek.Tuesday:
                    return "Martes";
                case DayOfWeek.Wednesday:
                    return "Miercoles";
                case DayOfWeek.Thursday:
                    return "Jueves";
                case DayOfWeek.Friday:
                    return "Viernes";
                case DayOfWeek.Saturday:
                    return "Sabado";
                case DayOfWeek.Sunday:
                    return "Domingo";
            }
            return "";
        }

        public static string Mes(int mes)
        {
            switch (mes)
            {
                case 1:
                    return "Enero";
                case 2:
                    return "Febreo";
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
