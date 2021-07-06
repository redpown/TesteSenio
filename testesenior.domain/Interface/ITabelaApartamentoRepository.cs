using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testesenior.domain.Entity;
using testesenior.Domain.DTO;

namespace testesenior.domain.Interface
{
    public interface ITabelaApartamentoRepository : IBaseRepository<TabelaApartamento>
    {
        public void InsertDTO(NovoTabelaApartamentoDTO entity);
        public void DeleteId(int id);

        public void UpdateByDTO(NovoTabelaApartamentoDTO novoObj);

        public IEnumerable<TabelaApartamentoDTO> GetAllFromDto();

        public NovoTabelaApartamentoDTO SelectDTO(int id);

    }
   
}
