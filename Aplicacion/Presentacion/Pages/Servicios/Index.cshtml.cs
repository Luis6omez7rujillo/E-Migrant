using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Dominio;
using Persistencia;

namespace Presentacion.Pages.Servicios
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioServicio _repoServicio;
        //public IEnumerable<Servicios> Servicios {get;set;}
        public IndexModel(IRepositorioServicio reposervicio)
        {
            this._repoServicio=reposervicio;
        }


        public void OnGet()
        {
        //    Servicios = _repoServicio.ListarServicios();
        }
    }
}
