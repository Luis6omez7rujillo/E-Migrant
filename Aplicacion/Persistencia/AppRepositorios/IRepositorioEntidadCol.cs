using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioEntidadCol
    {
         IEnumerable<EntidadColaboradora> ListarEntidadesCol();
        List<EntidadColaboradora> ListarEntidadesCol1();
        bool CrearEntidadCol(EntidadColaboradora entidadCol);
        bool ActualizarEntidadCol(EntidadColaboradora entidadCol);
        bool EliminarEntidadCol(int id);
        EntidadColaboradora BuscarEntidadCol(int id);
    }
}