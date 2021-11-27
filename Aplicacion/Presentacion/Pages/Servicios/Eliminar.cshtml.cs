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
    public class EliminarModel : PageModel
    {
        private readonly IRepositorioServicio repoServicio;
        public EliminarModel(IRepositorioServicio _repoServicio)
        {
            this.repoServicio = _repoServicio;
        }

        [BindProperty]
        public Servicios Servicio{get;set;}
        public ActionResult OnGet(int id)
        {
            Servicio = repoServicio.BuscarServicio(id);
            if(Servicio == null)
            {
                return NotFound();
            }

            ViewData["Mensaje"]="esta seguro de eliminar el registro?";
            return Page();
        }
        
        public ActionResult onPost()
        {
            bool funciono = repoServicio.EliminarServicio(Servicio.Id);
            if(funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"] = "No es posible eliminar registros que tienen integridad referencial";
                return Page();
            }
        }
    }
}
