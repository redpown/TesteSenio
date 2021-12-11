using System;

namespace Criptografa
{
    public static class Criptografar
    {
        public static int AsciiToInt(Char Caracter)
        {
            int i = 32;
            while (i < 255)
            {
                if ((char)i == Caracter)
                    break;
                i++;
            }
            return i;
        }
        public static String Criptografia(string texto, int chave)
        {
            string retorno;
            if ((texto.Trim() == "") || (chave == 0))
            {
                return texto;
            }
            else
            {
                retorno = "";
                for (int i = 0; i < texto.Length; i++)
                {
                    retorno = retorno + (char)(AsciiToInt(texto[i]) + chave);
                }
                return retorno;
            }
        }

        public static String DesCriptografia(string texto, int chave)
        {
            string retorno;
            if ((texto.Trim() == "") || (chave == 0))
            {
                return texto;
            }
            else
            {
                retorno = "";
                for (int i = 0; i < texto.Length; i++)
                {
                    retorno = retorno + (char)(AsciiToInt(texto[i]) - chave);
                }
                return retorno;
            }
        }
    }
}
