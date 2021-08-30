using System;
using System.Collections.Generic;
using System.Text;

namespace testesenior.Domain.Entity
{
    public class ExameStatus
    {


        public int id { get; set; }
        public string descricao { get; set; }
        public virtual ICollection<QualidadeMetricas> qmId { get; set; }
        public ExameStatus()
        {
        }
        public ExameStatus(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
        }
    }
}
