using System;
using System.Collections.Generic;

#nullable disable

namespace testesenior.Domain.Entity
{
    public partial class MetricasTipoMes
    {
        public int ID { get; set; }
        public int? Total { get; set; }
        public string Tipo { get; set; }
        public string Mes { get; set; }
        public int? Ano { get; set; }
    }
}
