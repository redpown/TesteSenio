/*******************************************************************************
 |                               ***Andre Marques***
 |
 |Classe    : DtoEntityProfile.cs
 |Data      : 07/16/2021
 |Descrição : Classe de mapeamento de DTO para entiade
 |Autor     : Andre Marques
 |
 |Ataualizações:
 |Autor    :    
 |Data     :
 |Linha    :
 |Descrição:
 ********************************************************************************/
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
                //.ForMember(dest => dest.tabelaCidade.nomeCidade, m => m.MapFrom(a => a.nomeCidade))
                //.ForMember(dest => dest.tabelaCidade.estado, m => m.MapFrom(a => a.estado));

            CreateMap<NovoTabelaPagamentosCondominioDTO, TabelaPagamentosCondominio>();
        }
    }
}
