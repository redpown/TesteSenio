using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testesenior.Domain.Entity;
using TesteSenior.Data.Context;
using TesteSenior.Data.Repositories;

namespace TesteSenior.Service.Service
{
    public class UsuarioService : UsuarioRepository
    {

        public UsuarioService(TesteSeniorConext testeSeniorConext, IMapper mapper) : base(testeSeniorConext, mapper)
        {
        }
        public Usuario GetUsuario(Usuario user)
        {
            Usuario valido = new Usuario();

            return valido = _TesteSeniorConext.usuarios.Where(w => w.email == user.email && w.Senha == user.Senha).FirstOrDefault();
          
        }
    }
}
