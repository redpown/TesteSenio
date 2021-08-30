using System;
using System.Collections.Generic;
using System.Text;

namespace testesenior.Domain.Entity
{
    public class Exames
    {
        

        public int id { get; set; }
        public string descricao { get; set; }
        public virtual ICollection<QualidadeMetricas> qmId { get; set; }

        public Exames()
        {

        }

        public Exames(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
        }
    }
}
