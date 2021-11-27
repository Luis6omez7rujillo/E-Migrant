using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Dominio;

namespace Persistencia.AppRepositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {

        private readonly AppContext _appContext;


        public RepositorioUsuario(AppContext appContext)
        {
            _appContext = appContext;
        }

        Usuario IRepositorioUsuario.AddUsuario(Usuario usuario)
        {
            var usuarioAdicionado = _appContext.Usuarios.Add(usuario);
            _appContext.SaveChanges();
            return usuarioAdicionado.Entity;
        }

        void IRepositorioUsuario.DeleteUsuario(int idUsuario)
        {
            var usuarioEncontrado = _appContext.Usuarios.FirstOrDefault(m => m.Id == idUsuario);
            if (usuarioEncontrado == null)
                return;
            _appContext.Usuarios.Remove(usuarioEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Usuario> IRepositorioUsuario.GetAllUsuarios()
        {
            return _appContext.Usuarios.Include(g => g.Rol);
        }

        Usuario IRepositorioUsuario.GetUsuario(int idUsuario)
        {
            var miUsuario = _appContext.Usuarios.Include(m => m.Rol).FirstOrDefault(m => m.Id == idUsuario);
            return miUsuario;
        }

         Usuario IRepositorioUsuario.UpdateUsuario(Usuario usuario)
        {
            var usuarioEncontrado =_appContext.Usuarios.Include(m => m.Rol).FirstOrDefault(m => m.Id==usuario.Id);
            if(usuarioEncontrado!=null)
            {
                usuarioEncontrado.User = usuario.User;
                usuarioEncontrado.Rol = usuario.Rol;
                _appContext.SaveChanges();
            }
            return usuarioEncontrado;
        }
    }
}