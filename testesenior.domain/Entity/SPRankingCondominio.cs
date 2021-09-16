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
        public int codigoEdificio { get; set; }
        public string nomeEdificio { get; set; }
        public int metragem { get; set; }
        public int andar { get; set; }
        public string nomeCidade { get; set; }
        public string estado { get; set; }
        public double valorPagamento { get; set; }
        public int numeroQuartos { get; set; }

        public SPRankingCondominio() { }

        public SPRankingCondominio(int codigoApartamento, int codigoEdificio, string nomeEdificio, int metragem, int andar, string nomeCidade, string estado, double valorPagamento, int numeroQuartos)
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
