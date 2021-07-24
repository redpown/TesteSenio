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
using TesteSenior.Data.Context;
using TesteSenior.Data.Repositories;
using TesteSenior.Data.Repositorios;

namespace TesteSenior.Service.Service
{
    public class TabelaApartamentoService : TabelaApartamentoRepository
    {
        public TabelaApartamentoService(TesteSeniorConext testeSeniorConext, IMapper mapper) : base(testeSeniorConext, mapper)
        {
        }



        public void InsertDTO(NovoTabelaApartamentoDTO entity)
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

        public void DeleteId(int id)
        {
            TabelaApartamento deletar = new TabelaApartamento();
            deletar.codigoApartamento = id;
            _TesteSeniorConext.Set<TabelaApartamento>().Remove(deletar);
            _TesteSeniorConext.SaveChanges();
        }

        public void UpdateByDTO(NovoTabelaApartamentoDTO novoObj)
        {
            TabelaApartamento velhoObj = Select(novoObj.codigoApartamento);
            velhoObj.metragem = novoObj.metragem;
            velhoObj.andar = novoObj.andar;
            velhoObj.numeroQuartos = novoObj.numeroQuartos;
            _TesteSeniorConext.Entry(velhoObj).State = EntityState.Modified;
            _TesteSeniorConext.SaveChanges();
        }

        public IEnumerable<TabelaApartamentoDTO> GetAllFromDto()
        {
            var obj = _TesteSeniorConext.Set<TabelaApartamento>().ToList();

            return _mapper.Map<List<TabelaApartamentoDTO>>(obj);
        }

        public NovoTabelaApartamentoDTO SelectDTO(int id)
        {
            TabelaApartamento obj = _TesteSeniorConext.tabelaApartamentos.Find(id);

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
    }
}
