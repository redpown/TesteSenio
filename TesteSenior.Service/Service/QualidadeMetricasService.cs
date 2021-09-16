using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testesenior.domain.Entity;
using testesenior.domain.Interface;
using testesenior.Domain.DTO;
using testesenior.Domain.Entity;
using TesteSenior.Data.Context;
using TesteSenior.Data.Repositories;
using TesteSenior.Data.Repositorios;

namespace TesteSenior.Service.Service
{
    public class QualidadeMetricasService : QualidadeMetricasRepository
    {
        public QualidadeMetricasService(TesteSeniorConext testeSeniorConext, IMapper mapper) : base(testeSeniorConext, mapper)
        {
        }

        /*

        public void InsertDTO(QualidadeMetricas entity)
        {
      
            TabelaApartamento novoAPTO = new TabelaApartamento(entity.metragem, entity.andar, entity.numeroQuartos);
            TabelaEdificio novoEdificio = new TabelaEdificio(entity.nomeEdificio, entity.andares, entity.numeroAptoAndar);
            TabelaCidade novaCidade = new TabelaCidade(entity.nomeCidade, entity.estado);
            novoAPTO.tabelaEdificio = novoEdificio;
            novoEdificio.tabelaCidade = novaCidade;
            _TesteSeniorConext.Set<TabelaCidade>().Add(novaCidade);
            _TesteSeniorConext.Set<TabelaEdificio>().Add(novoEdificio);
            _TesteSeniorConext.Set<TabelaApartamento>().Add(novoAPTO);

            _TesteSeniorConext.SaveChanges();

        }
        */

        public void DeleteId(int id)
        {
            QualidadeMetricas deletar = new();
            deletar.qmId = id;
            _TesteSeniorConext.Set<QualidadeMetricas>().Remove(deletar);
            _TesteSeniorConext.SaveChanges();
        }
        /*
        public void UpdateByDTO(QualidadeMetricas novoObj)
        {
           
            QualidadeMetricas velhoObj = Select(novoObj.qmId);
            velhoObj.qmColetaId = novoObj.qmColetaId;
            velhoObj.andar = novoObj.andar;
            velhoObj.numeroQuartos = novoObj.numeroQuartos;
            _TesteSeniorConext.Entry(velhoObj).State = EntityState.Modified;
            _TesteSeniorConext.SaveChanges();
        }
        */
        public IEnumerable<QualidadeMetricas> GetAllFromDto()
        {


            return _TesteSeniorConext.Set<QualidadeMetricas>().ToList(); //_mapper.Map<List<TabelaApartamentoDTO>>(obj);
        }
        /*
        public NovoTabelaApartamentoDTO SelectDTO(int id)
        {
            QualidadeMetricas obj = _TesteSeniorConext.qualidadeMetricas.Find(id);

            NovoTabelaApartamentoDTO objSelecionado = new NovoTabelaApartamentoDTO();
            if (obj != null)
            {
                objSelecionado.codigoApartamento = obj.codigoApartamento;
                objSelecionado.andar = obj.andar;
                objSelecionado.nomeCidade = obj.tabelaEdificio.tabelaCidade.nomeCidade;
                objSelecionado.numeroAptoAndar = obj.tabelaEdificio.numeroAptoAndar;
                objSelecionado.estado = obj.tabelaEdificio.tabelaCidade.estado;
                objSelecionado.nomeEdificio = obj.tabelaEdificio.nomeEdificio;
                objSelecionado.andares = obj.tabelaEdificio.andares;
                objSelecionado.metragem = obj.metragem;
                objSelecionado.numeroQuartos = obj.numeroQuartos;
            }
            return objSelecionado;
        }
        */

        public void GerarDados()
        {
            int totalDias = 1400;
            /*
            Random r = new Random();
            int rInt = r.Next(0, 100); //for ints
            int range = 100;
            double rDouble = r.NextDouble() * range; //for doubles
            */
            Random r = new();
            int meses;
            int dias;
            int anos;
            int exame;
            int tipo;
            int coleta;
            int status;

            for (int i = 0; i < totalDias; i++)
            {

                QualidadeMetricas QMA = new();
                meses = r.Next(1, 12);
                dias = r.Next(1, 28);
                anos = r.Next(2019, 2021);
                exame = r.Next(1, 8);
                tipo = r.Next(1, 2);
                coleta = r.Next(1, 3);
                status = r.Next(1, 3);

                if ((tipo == 1) && (status == 3))
                {
                    status = r.Next(0, 2);
                }

                QMA.qmExameId = exame;
                QMA.qmColetaId = coleta;
                QMA.qmExameStatusId = status;
                QMA.qmTipoExame = tipo;
                QMA.qmData = DateTime.Parse(anos.ToString()+"-"+ meses.ToString().PadLeft(2,'0')+"-" + dias.ToString().PadLeft(2, '0'));
                QMA.qmTotal = 0;
                QMA.qmQuantidade = 0;
                _TesteSeniorConext.QualidadeMetricas.Add(QMA);
                _TesteSeniorConext.SaveChanges();
            }

            // return _TesteSeniorConext.Set<QualidadeMetricas>().ToList(); //_mapper.Map<List<TabelaApartamentoDTO>>(obj);
        }
    }
}
