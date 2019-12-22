using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace Finanzas.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Usuario> UserProfiles { get; set; }
    }

    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Este Campo es requerido")]
        [DataType(DataType.Password)]
        [Remote("CheckOldPassword", "Account", ErrorMessage = "La contraseña no coincide con la actual", HttpMethod = "POST")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Este Campo es requerido")]
        [DataType(DataType.Password)]
        [StringLength(12, MinimumLength = 5, ErrorMessage = "La contraseña debe tener entre 5 y 12 caracteres")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "No coinciden la contraseña nueva y la confirmacion")]
        public string ConfirmNewPassword { get; set; }
    }
    
    public class LoginModel
    {
        [Required(ErrorMessage = "Este Campo es requerido")]
        [Display(Name = "Nombre Usuario")]
        [Remote("CheckLoginUser", "Account", ErrorMessage = "Usuario desconocido o no activo", HttpMethod = "POST")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Este Campo es requerido")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [Remote("CheckLoginPassword", "Account", AdditionalFields = "UserName", ErrorMessage = "Contraseña incorrecta", HttpMethod = "POST")]
        public string Password { get; set; }
    }
}
