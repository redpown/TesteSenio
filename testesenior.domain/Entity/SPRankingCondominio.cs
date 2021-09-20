using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testesenior.Domain.DTO
{

    public class SPRankingCondominio
    {
        

        public int codigoApartamento { get; set; }
        public decimal codigoEdificio { get; set; }
        public string nomeEdificio { get; set; }
        public decimal metragem { get; set; }
        public decimal andar { get; set; }
        public string nomeCidade { get; set; }
        public string estado { get; set; }
        public decimal valorPagamento { get; set; }
        public decimal numeroQuartos { get; set; }

        public SPRankingCondominio() { }

        public SPRankingCondominio(int codigoApartamento, decimal codigoEdificio, string nomeEdificio, decimal metragem, decimal andar, string nomeCidade, string estado, decimal valorPagamento, decimal numeroQuartos)
        {
            this.codigoApartamento = codigoApartamento;
            this.codigoEdificio = codigoEdificio;
            this.nomeEdificio = nomeEdificio;
            this.metragem = metragem;
            this.andar = andar;
            this.nomeCidade = nomeCidade;
            this.estado = estado;
            this.valorPagamento = valorPagamento;
            this.numeroQuartos = numeroQuartos;
        }
       
    }
}
