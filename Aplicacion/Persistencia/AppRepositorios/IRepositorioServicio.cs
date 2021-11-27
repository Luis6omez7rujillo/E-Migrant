using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioServicio
    {
        IEnumerable<Servicios> ListarServicios();
        bool CrearServicio(Servicios servicio);
        bool ActualizarServicio(Servicios servicio);
        bool EliminarServicio(int idServicio);
        Servicios BuscarServicio (int idServicio);
    }
}