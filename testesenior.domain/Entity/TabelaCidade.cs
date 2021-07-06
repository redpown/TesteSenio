using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testesenior.domain.Entity
{
    public class TabelaCidade
    {
        [Column("CODIGO_CIDADE")]
        public int codigoCidade { get; set; }
        [Column("NOME_CIDADE")]
        public string nomeCidade { get; set; }
        [Column("ESTADO")]
        public string estado { get; set; }
             
       
        public TabelaCidade() { }
        
        public TabelaCidade( string nomeCidade, string estado) {
            this.nomeCidade = nomeCidade;
            this.estado = estado;
        }
        

    }
}
