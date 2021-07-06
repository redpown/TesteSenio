using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testesenior.Domain.DTO
{
    public class TabelaEdificioDTO
    {
        public int codigoEdificio { get; set; }
        public string nomeEdificio { get; set; }
        public int andares { get; set; }
        public int numeroAptoAndar { get; set; }
        public TabelaEdificioDTO(){}
    }
}
