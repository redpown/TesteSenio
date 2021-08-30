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
            QualidadeMetricas deletar = new QualidadeMetricas();
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
    }
}
