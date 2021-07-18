/*******************************************************************************
 |                               ***Andre Marques***
 |
 |Classe    : DtoEntityProfile.cs
 |Data      : 07/16/2021
 |Descrição : Classe de mapeamento de entiade para DTO 
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
    public class EntityDtoProfile : AutoMapper.Profile
    {
        public EntityDtoProfile()
        {
            CreateMap<TabelaApartamento , TabelaApartamentoDTO>();
            CreateMap<TabelaCidade,TabelaCidadeDTO >();
            CreateMap<TabelaEdificio,TabelaEdificioDTO >();
            CreateMap<TabelaPagamentosCondominio,TabelaPagamentosCondominioDTO >();
            CreateMap<TabelaApartamento, NovoTabelaApartamentoDTO>();
            CreateMap<TabelaEdificio, NovoTabelaEdificioDTO>();
            CreateMap<TabelaPagamentosCondominio, NovoTabelaPagamentosCondominioDTO>();
        }
    }
}
