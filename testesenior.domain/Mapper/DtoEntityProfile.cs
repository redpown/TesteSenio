using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testesenior.domain.Entity;
using testesenior.Domain.DTO;

namespace testesenior.Domain.Mapper
{
    public class DtoEntityProfile : AutoMapper.Profile
    {
        public DtoEntityProfile()
        {
            CreateMap<TabelaApartamentoDTO, TabelaApartamento>();
            CreateMap<TabelaCidadeDTO, TabelaCidade>();
            CreateMap<TabelaEdificioDTO, TabelaEdificio>();
            CreateMap<TabelaPagamentosCondominioDTO, TabelaPagamentosCondominio>();
            CreateMap<NovoTabelaApartamentoDTO, TabelaApartamento>();
            CreateMap<NovoTabelaEdificioDTO, TabelaEdificio>();
            CreateMap<NovoTabelaPagamentosCondominioDTO, TabelaPagamentosCondominio>();
        }
    }
}
