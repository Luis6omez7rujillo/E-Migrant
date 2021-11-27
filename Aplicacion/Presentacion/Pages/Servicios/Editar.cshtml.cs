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
    public class EditarModel : PageModel
    {
        private readonly IRepositorioServicio _repoServicio;
        public EditarModel(IRepositorioServicio repoServicio)
        {
            this._repoServicio=repoServicio;
        }

        [BindProperty]
        public Servicios Servicio{get;set;}
        public ActionResult OnGet(int id)
        {
            Servicio = _repoServicio.BuscarServicio(id);
            return Page();
        }

        public ActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            bool funciono = _repoServicio.ActualizarServicio(Servicio);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Mensaje"] = "se ha presentado un error...";
                return Page();
            }
        }
    }
}
