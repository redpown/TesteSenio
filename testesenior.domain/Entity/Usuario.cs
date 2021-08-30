using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace testesenior.Domain.Entity
{
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }

        /*
        public string senha
        {
            get
            {
                return this.senha;
            }
            set
            {
                this.senha = value;
               // this.senha = GenerateHashSenha(value);
            }
        }*/

        //public string Senha { get => senha; set => senha = GenerateHashSenha(value); }

        public Usuario() { }

        public Usuario(int? id, string nome, string email, string senha)
        {
            if (id!=null) {
                this.id =(int) id;
            }
            
            this.nome = nome;
            this.email = email;
            this.senha = senha;
        }
        public string GenerateHashSenha(string value)
        {
                     
            MD5 md5Hash = MD5.Create();
            // Converter a String para array de bytes, que é como a biblioteca trabalha.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

            // Cria-se um StringBuilder para recompôr a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
           
        }


    }
}
