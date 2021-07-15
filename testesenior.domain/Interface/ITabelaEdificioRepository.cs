using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testesenior.domain.Entity;
using testesenior.Domain.DTO;

namespace testesenior.domain.Interface
{
    public interface ITabelaEdificioRepository : IBaseRepository<TabelaEdificio>
    {
        /*
        public NovoTabelaEdificioDTO SelectDTO(int id);
        public void InsertDTO(NovoTabelaEdificioDTO entity);
        public void DeleteId(int id);
        public void UpdateByDTO(TabelaEdificioDTO novoObj);

        public IEnumerable<TabelaEdificioDTO> GetAllFromDto();
        */
    }
}
