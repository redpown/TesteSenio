using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteSenior.Asp.Models
{
    public class TabelaCidadeModel
    {
        public int codigoCidade { get; set; }

        public string nomeCidade { get; set; }

        public string estado { get; set; }


        public TabelaCidadeModel() { }

        public TabelaCidadeModel(string nomeCidade, string estado)
        {
            this.nomeCidade = nomeCidade;
            this.estado = estado;
        }
    }
}
