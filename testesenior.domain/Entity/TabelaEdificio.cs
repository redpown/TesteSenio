using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testesenior.domain.Entity
{
    public class TabelaEdificio
    {
        [Column("CODIGO_EDIFICIO")]
        public int codigoEdificio { get; set; }
        [ForeignKey("CODIGO_CIDADE")]
        public virtual TabelaCidade tabelaCidade { get; set; }
        [Column("NOME_EDIFICIO")]
        public string nomeEdificio { get; set; }
        [Column("ANDARES")]
        public int andares { get; set; }
        [Column("NUMERO__APTO_ANDAR")]
        public int numeroAptoAndar { get; set; }

        public virtual ICollection<TabelaApartamento> tabelaApartamento { get; set; }
        public TabelaEdificio() { }
        public TabelaEdificio(string nomeEdificio, int andares, int numeroAptoAndar) {
            this.nomeEdificio = nomeEdificio;
            this.andares = andares;
            this.numeroAptoAndar = numeroAptoAndar;
        }
    }
}
