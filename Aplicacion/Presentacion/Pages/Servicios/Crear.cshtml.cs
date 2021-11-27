using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Dominio;
using Persistencia;

namespace Presentacion.Pages.Servicio
{
    public class CrearModel : PageModel
    {
         private readonly IRepositorioServicio _repoServicio;
         [BindProperty]
         public Servicios Servicio{get;set;}
         public CrearModel(IRepositorioServicio repoServicio)
         {
             this._repoServicio = repoServicio;
         }

        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            bool creado = _repoServicio.CrearServicio(Servicio);
            if (creado)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Mensaje"] = "Este servicio ya se encuentra registrado";
                return Page();
            }
        }

    }
}
