using System;
using System.Collections.Generic;
using System.Text;

namespace testesenior.Domain.Entity
{
    public class UsuarioDTO
    {

        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }


        public UsuarioDTO() { }

        public UsuarioDTO(string nome, string email, string senha)
        {
            this.nome = nome;
            this.email = email;
            this.senha = senha;
        }

    }
}
