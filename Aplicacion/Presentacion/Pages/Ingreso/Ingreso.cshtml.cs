using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Persistencia;
using Dominio;

namespace Presentacion.Pages.Ingreso
{
    public class IngresoModel : PageModel
    {
        private Persistencia.AppContext _appContext;

        [BindProperty]
        public string Usuario {get;set;}

        [BindProperty]
        public string Password {get;set;}

        [BindProperty]
        public string MensajeUsuario {get;set;}

        [BindProperty]
        public string MensajePassword {get;set;}

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _appContext = new Persistencia.AppContext();

            var p = _appContext.Usuarios.Include(p => p.Rol).FirstOrDefault(p => p.User == Usuario);
            if (p == null)
            {
                MensajeUsuario = "Usuario Inexistente";
            }
            else if (!p.Password.Equals(Password))
            {
                MensajePassword = "Contraseña Incorrecta";
            }
            else if(p.Entro == false)
            {
                HttpContext.Session.SetString("MiUsuario", Usuario);
                return RedirectToPage("./CambioPassword");
            }
            else 
            {
                HttpContext.Session.SetString("MiUsuario", Usuario);
                HttpContext.Session.SetString("MiRol", p.Rol);
                return RedirectToPage("../Index");
            }
            return Page();
        }
        

    }
}