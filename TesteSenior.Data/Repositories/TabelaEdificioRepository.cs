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
    public class TabelaEdificioRepository : BaseRepository<TabelaEdificio>, ITabelaEdificioRepository
    {
        public TabelaEdificioRepository(TesteSeniorConext testeSeniorConext, IMapper mapper) : base(testeSeniorConext, mapper)
        {
        }
        public void InsertDTO(NovoTabelaEdificioDTO entity) {

           
            TabelaEdificio novoEdifivio = new TabelaEdificio(entity.nomeEdificio, entity.andares, entity.numeroAptoAndar);
            TabelaCidade novaCidade = new TabelaCidade(entity.nomeCidade, entity.estado);
            novoEdifivio.tabelaCidade = novaCidade;
            _TesteSeniorConext.Set<TabelaCidade>().Add(novaCidade);
            _TesteSeniorConext.Set<TabelaEdificio>().Add(novoEdifivio);
          
            _TesteSeniorConext.SaveChanges();
        }
        public void DeleteId(int id)
        {
            TabelaEdificio deletar = new TabelaEdificio();
            deletar.codigoEdificio = id;
            _TesteSeniorConext.Set<TabelaEdificio>().Remove(deletar);
            _TesteSeniorConext.SaveChanges();
        }

        public void UpdateByDTO(TabelaEdificioDTO novoObj)
        {
            TabelaEdificio velhoObj = Select(novoObj.codigoEdificio);
            velhoObj.andares = novoObj.andares;
            velhoObj.nomeEdificio = novoObj.nomeEdificio;
            velhoObj.numeroAptoAndar = novoObj.numeroAptoAndar;
            _TesteSeniorConext.Entry(velhoObj).State = EntityState.Modified;
            _TesteSeniorConext.SaveChanges();
        }

        public IEnumerable<TabelaEdificioDTO> GetAllFromDto()
        {
            var obj = _TesteSeniorConext.Set<TabelaEdificio>().ToList();

            return _mapper.Map<List<TabelaEdificioDTO>>(obj);
        }

        public NovoTabelaEdificioDTO SelectDTO(int id)
        {
            TabelaEdificio obj = _TesteSeniorConext.tabelaEdificios.Find(id);

            NovoTabelaEdificioDTO objSelecionado = new NovoTabelaEdificioDTO();
            if (obj != null)
            {
                objSelecionado.codigoEdificio = obj.codigoEdificio;
                objSelecionado.andares = obj.andares;
                objSelecionado.nomeCidade = obj.tabelaCidade.nomeCidade;
                objSelecionado.numeroAptoAndar = obj.numeroAptoAndar;
                objSelecionado.estado = obj.tabelaCidade.estado;
                objSelecionado.nomeEdificio = obj.nomeEdificio;
                
            }
            return objSelecionado;
        }
    }
}
