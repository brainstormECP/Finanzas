using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Finanzas.Filters
{
    [HandleError]
    public class LoginFilterAttribute : ActionFilterAttribute
    {
        public string Rol { get; set; }


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session != null && filterContext.HttpContext.Session["usuarioActual"] == null)
            {
                throw new Exception("Para utilizar la aplicacion debe Loguearse");
            }
            var usuario = (Models.Usuario)filterContext.HttpContext.Session["usuarioActual"];
            if (usuario.Rol.nombreRol != "Administrador")
            {
                if ( Rol != "Todos")
                {
                    if (!Rol.Equals(usuario.Rol.nombreRol))
                    {
                        throw new Exception("Esta tratando de acceder a partes de la aplicacion no autorizadas para su Rol");
                    } 
                }
            }
        }
    }
}