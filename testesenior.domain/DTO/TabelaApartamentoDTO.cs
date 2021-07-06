using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testesenior.Domain.DTO
{
    public class TabelaApartamentoDTO
    {

        public int codigoApartamento { get; set; }
        public int metragem { get; set; }
        public int andar { get; set; }
        public int numeroQuartos { get; set; }

        public TabelaApartamentoDTO() { }
    }
}
