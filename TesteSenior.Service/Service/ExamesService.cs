using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class ExamesService : ExamesRepository
    {

        public ExamesService(TesteSeniorConext testeSeniorConext, IMapper mapper) : base(testeSeniorConext, mapper)
        {
        }
        /*
        public UsuarioDTO GetUsuario(UsuarioDTO user)
        {
            Usuario userGet = _TesteSeniorConext.usuarios.Where(w => w.email == user.email && w.senha == user.senha).FirstOrDefault();
            //return _TesteSeniorConext.usuarios.Find(user);
            UsuarioDTO userDTO = new UsuarioDTO(userGet.nome, userGet.email, userGet.senha);
            return userDTO;

        }

        public IEnumerable<Usuario>  GetAllUsuario()
        {
            var obj = _TesteSeniorConext.Set<Usuario>().ToList();

            return obj;

        }

        public void PutUsuario(UsuarioDTO user)
        {
            Usuario userPut = new Usuario(null, user.nome, user.email, user.senha);
            _TesteSeniorConext.usuarios.Add(userPut);
            _TesteSeniorConext.SaveChanges();



        }

        public void DeleteId(int id)
        {
            Usuario deletar = new Usuario();
            deletar.id = id;
            _TesteSeniorConext.Set<Usuario>().Remove(deletar);
            _TesteSeniorConext.SaveChanges();
        }

        public void UpdateByDTO(Usuario novoObj)
        {
            Usuario velhoObj = Select(novoObj.id);
            velhoObj.nome = novoObj.nome;
            velhoObj.email = novoObj.email;
            velhoObj.senha = novoObj.senha;
            _TesteSeniorConext.Entry(velhoObj).State = EntityState.Modified;
            _TesteSeniorConext.SaveChanges();
        }

        public void InsertDTO(UsuarioDTO entity)
        {

            Usuario novoUsuario = new Usuario(null,entity.nome, entity.email,entity.senha);

            _TesteSeniorConext.Set<Usuario>().Add(novoUsuario);

            _TesteSeniorConext.SaveChanges();

        }*/
    }
}
