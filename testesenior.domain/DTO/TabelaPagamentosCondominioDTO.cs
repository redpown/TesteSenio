using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testesenior.Domain.DTO
{
    public class TabelaPagamentosCondominioDTO
    {
        public int codigoPagamentoCondominio { get; set; }
        public DateTime dataPagamento { get; set; }
        public double valorPagamento { get; set; }

        public TabelaPagamentosCondominioDTO(){}
    }
}
