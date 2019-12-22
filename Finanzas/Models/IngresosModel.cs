using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Finanzas.Filters;

namespace Finanzas.Models
{
    public class IngresosModel
    {
        [Display(Name = "Fecha de Inicio")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fecha de Fin")]
        [DataType(DataType.Date)]
        [FechaMayorQue("FechaInicio")]
        public DateTime FechaFin { get; set; }

        public List<int> ConceptoId { get; set; }
    }
}