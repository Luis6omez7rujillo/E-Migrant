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


namespace Presentacion.Pages
{
    public class CambioPasswordModel : PageModel
    {
        private Persistencia.AppContext _appContext;


        [BindProperty]
        public string NewPassword{get;set;}

        [BindProperty]
        public string NewPasswordConfirm {get;set;}

        [BindProperty]
        public string Mensaje{get;set;}
        

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
             _appContext = new Persistencia.AppContext();

            var Usuario = HttpContext.Session.GetString("MiUsuario");
            var p = _appContext.Usuarios.Include(p => p.Rol).FirstOrDefault( p => p.User == Usuario);
            if (!NewPassword.Equals(NewPasswordConfirm))
            {
                //Console.WriteLine("Contraseña incorrecta");
                 Mensaje = "Contraseñas no coinciden";
            }
            else
            {
                HttpContext.Session.SetString("MiRol", p.Rol);
                p.Entro = true;
                p.Password = NewPassword;
                _appContext.SaveChanges();
                return RedirectToPage("../Index");
            }

            return Page();
        }


    }
}