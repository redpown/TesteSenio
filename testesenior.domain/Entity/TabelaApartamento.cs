//
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testesenior.domain.Entity
{
    public class TabelaApartamento
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column("CODIGO_APARTAMENTO")]
        public int codigoApartamento { get; set; }
        //[ForeignKey("CODIGO_EDIFICIO")]
        public virtual TabelaEdificio tabelaEdificio { get; set; }

        public int tabelaEdificioID { get; set; }
        ///[Column("METRAGEM")]
        public int metragem { get; set; }
        //[Column("ANDAR")]
        public int andar { get; set; }
        //[Column("NUMERO_QUARTOS")]
        public int numeroQuartos { get; set; }
        
        public TabelaApartamento() { }

        public TabelaApartamento(int metragem, int andar, int numeroQuartos)
        {
            this.metragem = metragem;
            this.andar = andar;
            this.numeroQuartos = numeroQuartos;
        }
    }
}
