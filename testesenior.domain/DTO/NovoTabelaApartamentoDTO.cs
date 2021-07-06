using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testesenior.Domain.DTO
{
    public class NovoTabelaApartamentoDTO
    {
        public int codigoApartamento { get; set; }
        public string nomeCidade { get; set; }
        public string estado { get; set; }
        public string nomeEdificio { get; set; }
        public int andares { get; set; }
        public int numeroAptoAndar { get; set; }
        public int metragem { get; set; }
        public int andar { get; set; }
        public int numeroQuartos { get; set; }

        public NovoTabelaApartamentoDTO() { }
    }
}
