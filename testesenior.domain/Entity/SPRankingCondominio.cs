using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testesenior.Domain.DTO
{
    
    public class SPRankingCondominio
    {
        [Column("CODIGO_APARTAMENTO")]
        public int codigoApartamento { get; set; }
        [Column("CODIGO_EDIFICIO")]
        public int codigoEdificio { get; set; }
        [Column("NOME_EDIFICIO")]
        public string nomeEdificio { get; set; }
        [Column("METRAGEM")]
        public int metragem { get; set; }
        [Column("ANDAR")]
        public int andar { get; set; }
        [Column("NOME_CIDADE")]
        public string nomeCidade { get; set; }
        [Column("ESTADO")]
        public string estado { get; set; }
        [Column("VALOR_PAGAMENTO")]
        public double valorPagamento { get; set; }
        [Column("NUMERO_QUARTOS")]
        public int numeroQuartos { get; set; }
    }
}
