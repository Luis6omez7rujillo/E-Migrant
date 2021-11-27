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
    public class DetallesModel : PageModel
    {
        private readonly IRepositorioServicio _repoServicio;
        public DetallesModel(IRepositorioServicio repoServicio)
        {
            this._repoServicio = repoServicio;
        }

        [BindProperty]
        public Servicios Servicio{get;set;}
        public ActionResult OnGet(int id)
        {
            Servicio = _repoServicio.BuscarServicio(id);
            if(Servicio == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
