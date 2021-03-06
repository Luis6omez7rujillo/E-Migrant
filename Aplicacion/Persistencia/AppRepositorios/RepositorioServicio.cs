using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioServicio : IRepositorioServicio
    {
        private readonly AppContext _appContext;

        public RepositorioServicio(AppContext appContext)
        {
            _appContext = appContext;
        }

        bool IRepositorioServicio.CrearServicio(Servicios servicio)
        {
            bool creado = false;
            bool ex=Existe(servicio);
            if(!ex)
            {
                try
                {
                    _appContext.Servicios.Add(servicio);
                    _appContext.SaveChanges();
                    creado = true;
                }
                catch (System.Exception)
                {
                    return creado;
                }
            }

            return creado;
        }

        bool IRepositorioServicio.ActualizarServicio(Servicios servicio)
        {
            bool actualizado = false;
            var s = _appContext.Servicios.Find(servicio.Id);
            if (s != null)
            {
                try
                {

                    s.Nombre = servicio.Nombre;
                    s.MaxMigrantes = servicio.MaxMigrantes;
                    s.FechaInicio = servicio.FechaInicio;
                    s.FechaFinal = servicio.FechaFinal;
                    s.Estado = servicio.Estado;
                    s.EntidadId=servicio.EntidadId;

                    _appContext.SaveChanges();
                    actualizado = true;
                }

                catch
                {
                    return actualizado;
                }
            }
            return actualizado;
        }

        bool IRepositorioServicio.EliminarServicio(int idServicio)
        {
            bool eliminado = false;
            var servicio = _appContext.Servicios.Find(idServicio);
            if(servicio != null)
            {
                try{
                    _appContext.Servicios.Remove(servicio);
                    _appContext.SaveChanges();
                    eliminado =true;
                }
                catch (System.Exception)
                {
                    return eliminado;
                }
            }
            return eliminado;
            
        }

        Servicios IRepositorioServicio.BuscarServicio(int idServicios)
        {
            Servicios servicios=_appContext.Servicios.Find(idServicios);
            return servicios;
        }

        IEnumerable<Servicios> IRepositorioServicio.ListarServicios()
        {
            return _appContext.Servicios; 

        }

        public List<Servicios> ListarServicios1()
        {
            return _appContext.Servicios.ToList();
        }

        private bool Existe(Servicios servicio)
        {
            bool ex= false;
            var equ= _appContext.Servicios.FirstOrDefault(e => e.Nombre == servicio.Nombre);
            if(equ!=null)
            {
                ex = true;
            }
            return ex;

        }



    }
}