using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;



namespace testesenior.Domain.Entity
{
    //[Keyless] //anotacao para classes de view e de apenas query
    public class ViewMetricasTipoMes
    {



        public int? Total { get; set; }
        public string Tipo { get; set; }
        public string Mes { get; set; }
        public int? Ano { get; set; }
        
        public ViewMetricasTipoMes()
        { }

        public ViewMetricasTipoMes(int? total, string tipo, string mes, int? ano)
        {

            Total = total;
            Tipo = tipo;
            Mes = mes;
            Ano = ano;
        }
    }
}
