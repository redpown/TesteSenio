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
using TesteSenior.Data.Repositorios;

namespace TesteSenior.Data.Repositories
{
    public class TabelaPagamentosCondominioRepository : BaseRepository<TabelaPagamentosCondominio>, ITabelaPagamentosCondominioRepository
    {
        public TabelaPagamentosCondominioRepository(TesteSeniorConext testeSeniorConext, IMapper mapper) : base(testeSeniorConext, mapper)
        {
        }
        public void InsertDTO(NovoTabelaPagamentosCondominioDTO entity) {

            TabelaPagamentosCondominio novaPagamento = new TabelaPagamentosCondominio(entity.dataPagamento, entity.valorPagamento);
            TabelaApartamento novoAPTO = new TabelaApartamento(entity.metragem, entity.andar, entity.numeroQuartos);
            TabelaEdificio novoEdifivio = new TabelaEdificio(entity.nomeEdificio, entity.andares, entity.numeroAptoAndar);
            TabelaCidade novaCidade = new TabelaCidade(entity.nomeCidade, entity.estado);
            novoAPTO.tabelaEdificio = novoEdifivio;
            novoEdifivio.tabelaCidade = novaCidade;
            novaPagamento.tabelaApartamento = novoAPTO;
            _TesteSeniorConext.Set<TabelaCidade>().Add(novaCidade);
            _TesteSeniorConext.Set<TabelaEdificio>().Add(novoEdifivio);
            _TesteSeniorConext.Set<TabelaApartamento>().Add(novoAPTO);
            _TesteSeniorConext.Set<TabelaPagamentosCondominio>().Add(novaPagamento);
            
            _TesteSeniorConext.SaveChanges();

        }
        public void DeleteId(int id)
        {
            TabelaPagamentosCondominio deletar = new TabelaPagamentosCondominio();
            deletar.codigoPagamentoCondominio = id;
            _TesteSeniorConext.Set<TabelaPagamentosCondominio>().Remove(deletar);
            _TesteSeniorConext.SaveChanges();
        }
        public void UpdateByDTO(TabelaPagamentosCondominioDTO novoObj)
        {
            TabelaPagamentosCondominio velhoObj = Select(novoObj.codigoPagamentoCondominio);
            velhoObj.dataPagamento = novoObj.dataPagamento;
            velhoObj.valorPagamento = novoObj.valorPagamento;
            _TesteSeniorConext.Entry(velhoObj).State = EntityState.Modified;
            _TesteSeniorConext.SaveChanges();
        }

        public IEnumerable<TabelaPagamentosCondominioDTO> GetAllFromDto()
        {
            var obj = _TesteSeniorConext.Set<TabelaPagamentosCondominio>().ToList();

            return _mapper.Map<List<TabelaPagamentosCondominioDTO>>(obj);
        }

        public NovoTabelaPagamentosCondominioDTO SelectDTO(int id) {

            TabelaPagamentosCondominio obj = _TesteSeniorConext.tabelaPagamentosCondominios.Find(id);

            NovoTabelaPagamentosCondominioDTO objSelecionado = new NovoTabelaPagamentosCondominioDTO();
            if (obj != null)
            {
                objSelecionado.codigoPagamentoCondominio = obj.codigoPagamentoCondominio;
                objSelecionado.nomeCidade = obj.tabelaApartamento.tabelaEdificio.tabelaCidade.nomeCidade;
                objSelecionado.estado = obj.tabelaApartamento.tabelaEdificio.tabelaCidade.estado;
                objSelecionado.nomeEdificio = obj.tabelaApartamento.tabelaEdificio.nomeEdificio;
                objSelecionado.andares = obj.tabelaApartamento.tabelaEdificio.andares;
                objSelecionado.numeroAptoAndar = obj.tabelaApartamento.tabelaEdificio.numeroAptoAndar;
                objSelecionado.metragem = obj.tabelaApartamento.metragem;
                objSelecionado.andar = obj.tabelaApartamento.andar;
                objSelecionado.numeroQuartos = obj.tabelaApartamento.numeroQuartos;
                objSelecionado.dataPagamento = obj.dataPagamento;
                objSelecionado.valorPagamento = obj.valorPagamento;
            }
            return objSelecionado;
        }
    }
}
