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
    public class IndexModel : PageModel
    {
        private readonly IRepositorioServicio _repoServicio;
        public IEnumerable<Servicios> Servicios{get;set;}
        public IndexModel(IRepositorioServicio repoServicio)
        {
            this._repoServicio=repoServicio;
        }

        public void OnGet()
        {
            Servicios = _repoServicio.ListarServicios();
        }
    }
}
