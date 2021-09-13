using System;
using System.Collections.Generic;
using System.Text;

namespace testesenior.Domain.Entity
{
    public class ExameStatus
    {


        public int ID { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<QualidadeMetricas> QmID { get; set; }
        public ExameStatus()
        {
        }
        public ExameStatus(int? id, string descricao)
        {
            if (id != null) {
                this.ID = (int)id;
            }
            
            this.Descricao = descricao;
        }
    }
}
