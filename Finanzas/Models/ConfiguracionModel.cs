using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace Finanzas.Models
{
    public class ConfiguracionModel
    {
        private static ConfiguracionModel config;

        private static string Camino { get; set; }

        [Display(Name = "Mes Actual")]
        public int MesActual { get; set; }

        [Display(Name = "Año Actual")]
        public int AnoActual { get; set; }

        public static void CargarConfig(string direccion)
        {
            var doc = new XDocument();
            try
            {
                doc  = XDocument.Load(direccion);
            }
            catch (Exception)
            {
                XmlWriter writer = new XmlTextWriter(direccion,null);
                writer.WriteStartDocument();
                writer.WriteStartElement("config");
                writer.WriteStartElement("mesActual");
                writer.WriteString(DateTime.Now.Month.ToString());
                writer.WriteEndElement();
                writer.WriteStartElement("anoActual");
                writer.WriteString(DateTime.Now.Year.ToString());
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Flush();
                writer.Close();
                doc = XDocument.Load(direccion);
            }

            var query = from item in doc.Descendants() select new { item.Value, item.Name };
            config = new ConfiguracionModel()
            {
                AnoActual = int.Parse(query.First(q => q.Name == "anoActual").Value),
                MesActual = int.Parse(query.First(q => q.Name == "mesActual").Value)
            };
            Camino = direccion;
        }

        public static ConfiguracionModel GetConfig()
        {
            if (config == null)
            {
                XDocument doc = XDocument.Load(Camino);
                var query = from item in doc.Descendants() select new { item.Value, item.Name };
                config = new ConfiguracionModel()
                {
                    AnoActual = int.Parse(query.First(q => q.Name == "anoActual").Value),
                    MesActual = int.Parse(query.First(q => q.Name == "mesActual").Value)
                };
            }
            return config;
        }

        public void SaveConfig()
        {
            XDocument doc = XDocument.Load(Camino);
            var e = doc.Descendants().First(d => d.Name == "mesActual");
            e.Value = MesActual.ToString();
            config.MesActual = MesActual;

            e = doc.Descendants().First(d => d.Name == "anoActual");
            e.Value = AnoActual.ToString();
            config.AnoActual = AnoActual;

            doc.Save(Camino);
        }

        public void CambiarMes()
        {
            XDocument doc = XDocument.Load(Camino);
            MesActual += 1;
            if (MesActual == 13)
            {
                AnoActual += 1;
                MesActual = 1;
            }

            var e = doc.Descendants().First(d => d.Name == "mesActual");
            e.Value = MesActual.ToString();

            e = doc.Descendants().First(d => d.Name == "anoActual");
            e.Value = AnoActual.ToString();

            doc.Save(Camino);
        }


        public string MesToString()
        {
            string mes = "";
            switch (MesActual)
            {
                case 1:
                    mes = "Enero"; break;
                case 2:
                    mes = "Febrero"; break;
                case 3:
                    mes = "Marzo"; break;
                case 4:
                    mes = "Abril"; break;
                case 5:
                    mes = "Mayo"; break;
                case 6:
                    mes = "Junio"; break;
                case 7:
                    mes = "Julio"; break;
                case 8:
                    mes = "Agosto"; break;
                case 9:
                    mes = "Septiembre"; break;
                case 10:
                    mes = "Octubre"; break;
                case 11:
                    mes = "Noviembre"; break;
                case 12:
                    mes = "Diciembre"; break;

            }
            return mes;
        }


        public override string ToString()
        {
            return MesToString() + " " + AnoActual;
        }

    }
}