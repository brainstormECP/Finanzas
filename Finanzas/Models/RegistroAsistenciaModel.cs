using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Finanzas.Models
{
    public class RegistroAsistenciaModel
    {
        [Required(ErrorMessage = "Este dato es Obligatorio")]
        [Display(Name = "Trimestre")]
        public int Trimestre { get; set; }

        [Required(ErrorMessage = "Este dato es Obligatorio")]
        [Display(Name = "Categoria Persona")]
        public List<int> CategoriaPersonaid { get; set; }
    }
}