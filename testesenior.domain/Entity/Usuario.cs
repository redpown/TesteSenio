using System;
using System.Collections.Generic;
using System.Text;

namespace testesenior.Domain.Entity
{
    public class Usuario
    {
        public int id;
        public string nome;
        public string email;
        private string senha;

        

        public string Senha { get => senha; set => senha = GenerateHashSenha(value); }

        public Usuario() { }
        public Usuario(int id, string nome, string email, string senha)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.senha = GenerateHashSenha(senha);
        }
        public string GenerateHashSenha( string value)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(value);
            data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
            return Convert.ToBase64String(data);
        }

        
    }
}
