using AutoMapper;
using Criptografa;
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
    public class UsuarioService : UsuarioRepository
    {

        public UsuarioService(TesteSeniorConext testeSeniorConext, IMapper mapper) : base(testeSeniorConext, mapper)
        {
        }

        public UsuarioDTO GetUsuario(UsuarioDTO user)
        {
            UsuarioDTO userDTO = new UsuarioDTO();
           Usuario userGet = _TesteSeniorConext.Usuarios.Where(w =>  w.email == user.email && w.senha == Criptografar.Criptografia(user.senha,140)).FirstOrDefault();
            //return _TesteSeniorConext.usuarios.Find(user);
            if (userGet != null) {
                 userDTO = new UsuarioDTO(userGet.nome, userGet.email, Criptografar.Criptografia(userGet.senha,140), userGet.perfil);
            }

            return userDTO;

        }

        public IEnumerable<Usuario>  GetAllUsuario()
        {
            var obj = _TesteSeniorConext.Set<Usuario>().ToList();

            return obj;

        }

       
        public void PutUsuario(UsuarioDTO user)
        {
            Usuario userPut = new Usuario(null, user.nome, user.email, Criptografar.Criptografia(user.senha,140), user.perfil);
            _TesteSeniorConext.Usuarios.Add(userPut);
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
            velhoObj.senha = Criptografar.Criptografia(novoObj.senha,140);
            _TesteSeniorConext.Entry(velhoObj).State = EntityState.Modified;
            _TesteSeniorConext.SaveChanges();
        }

        public void InsertDTO(UsuarioDTO entity)
        {

            Usuario novoUsuario = new Usuario(null,entity.nome, entity.email, Criptografar.Criptografia(entity.senha,140), entity.perfil);

            _TesteSeniorConext.Set<Usuario>().Add(novoUsuario);

            _TesteSeniorConext.SaveChanges();

        }
    }
}
