using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Finanzas.Models
{
    public class CategoriaModel
    {
        [Required(ErrorMessage = "Este dato es Obligatorio")]
        [Display(Name = "Categoria Persona")]
        public int CategoriaPersonaid { get; set; }
    }
}