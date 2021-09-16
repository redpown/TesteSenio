using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;



namespace testesenior.Domain.Entity
{
   // [Keyless]//anotacao para classes de view e de apenas query
    public  class ViewMetrica
    {
        
        public int? Total { get; set; }
        public string Tipo { get; set; }
        public string Status { get; set; }
        public string Coleta { get; set; }
        public string Exame { get; set; }
        public string Mes { get; set; }
        public int? Ano { get; set; }
        
        public ViewMetrica()
        { }
        public ViewMetrica(int? total, string tipo, string status, string coleta, string exame, string mes, int? ano)
        {

            Total = total;
            Tipo = tipo;
            Status = status;
            Coleta = coleta;
            Exame = exame;
            Mes = mes;
            Ano = ano;
        }
    }
}
