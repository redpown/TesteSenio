using System;
using System.Collections.Generic;
using System.Text;
using testesenior.Domain.Enums;

namespace testesenior.Domain.Entity
{
    public class QualidadeMetricas
    {
       

        public int qmId { get; set; }
        public int qmTotal { get; set; }
        public int qmExameId { get; set; }
        //public virtual Exames exames { get; set; }
        public int qmQuantidade { get; set; }
        public int qmColetaId { get; set; }
       // public virtual Coleta coleta { get; set; }
        public int qmTipoExame { get; set; }
       // public virtual TipoExame tipoExame { get; set; }
        public int qmExameStatusId { get; set; }
       // public virtual ExameStatus exameStatus { get; set; }
        public DateTime qmData { get; set; }

        public QualidadeMetricas() { }

        public QualidadeMetricas(int qmId, int qmTotal, int qmExameId, int qmQuantidade, int qmColetaId, int qmTipoExame, int qmExameStatusId, DateTime qmData)
        {
            this.qmId = qmId;
            this.qmTotal = qmTotal;
            this.qmExameId = qmExameId;
            this.qmQuantidade = qmQuantidade;
            this.qmColetaId = qmColetaId;
            this.qmTipoExame = qmTipoExame;
            this.qmExameStatusId = qmExameStatusId;
            this.qmData = qmData;
        }
    }
}
