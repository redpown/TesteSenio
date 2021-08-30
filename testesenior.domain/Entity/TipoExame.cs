using System;
using System.Collections.Generic;
using System.Text;

namespace testesenior.Domain.Entity
{
    public class TipoExame
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public virtual ICollection<QualidadeMetricas> qmId { get; set; }

        public TipoExame()
        {
        }

        public TipoExame(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
        }
    }
}
