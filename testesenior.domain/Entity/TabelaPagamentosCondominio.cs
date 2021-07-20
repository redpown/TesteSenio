using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testesenior.domain.Entity
{
    public class TabelaPagamentosCondominio
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column("CODIGO_PAGAMENTOS_CONDOMINIO")]
        public int codigoPagamentoCondominio { get; set; }
        //[ForeignKey("CODIGO_APARTAMENTO")]
        public virtual TabelaApartamento tabelaApartamento { get; set; }

        public int tabelaApartamentoID { get; set; }
        //[Column("DATA_PAGAMENTO")]
        public DateTime dataPagamento { get; set; }
        //[Column("VALOR_PAGAMENTO")]
        public double valorPagamento { get; set; }

        public TabelaPagamentosCondominio() { }

        public TabelaPagamentosCondominio(DateTime dataPagamento, double valorPagamento) {
            this.dataPagamento = dataPagamento;
            this.valorPagamento = valorPagamento;
        }

    }
}
