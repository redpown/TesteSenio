using Criptografa;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Criptografia.Teste
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CriptografarTeste()
        {
            Criptografar teste = new Criptografar();
            string texto = "minha senha.com 123";
            //valor maximo para a chave de 1 a 140
            int chave = 140;
            File.WriteAllText(@"C:\Users\Public\Documents\cript.txt", teste.Criptografia(texto, chave));
            File.WriteAllText(@"C:\Users\Public\Documents\decript.txt", teste.DesCriptografia(teste.Criptografia(texto, chave), chave));

        }
    }
}
