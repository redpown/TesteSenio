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

namespace TesteSenior.Service.Service
{
    public class TabelaCidadeService : TabelaCidadeRepository
    {
        public TabelaCidadeService(TesteSeniorConext testeSeniorConext, IMapper mapper) : base(testeSeniorConext, mapper)
        {
        }
        public void InsertDTO(TabelaCidadeDTO value) {
            TabelaCidade novaCidade = new TabelaCidade(value.nomeCidade, value.estado);
            _TesteSeniorConext.Set<TabelaCidade>().Add(novaCidade);
            _TesteSeniorConext.SaveChanges();
        }
        public void DeleteId(int id)
        {
            TabelaCidade deletar = Select(id);
            _TesteSeniorConext.Set<TabelaCidade>().Remove(deletar);
            _TesteSeniorConext.SaveChanges();
        }
        public void UpdateByDTO(TabelaCidadeDTO novoObj)
        {
            TabelaCidade velhoObj = Select(novoObj.codigoCidade);
            velhoObj.nomeCidade = novoObj.nomeCidade;
            velhoObj.estado = novoObj.estado;
            _TesteSeniorConext.Entry(velhoObj).State = EntityState.Modified;
            _TesteSeniorConext.Set<TabelaCidade>().Update(velhoObj);
            _TesteSeniorConext.SaveChanges();
        }

        public IEnumerable<TabelaCidadeDTO> GetAllFromDto()
        {
            var obj = _TesteSeniorConext.Set<TabelaCidade>().ToList();

            return _mapper.Map<List<TabelaCidadeDTO>>(obj);
        }
    }
}
