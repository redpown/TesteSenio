using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testesenior.domain.Entity;
using testesenior.Domain.DTO;

namespace testesenior.domain.Interface
{
    public interface ITabelaCidadeRepository : IBaseRepository<TabelaCidade>
    {
        public void InsertDTO(TabelaCidadeDTO value);
        public void DeleteId(int id);

        public void UpdateByDTO(TabelaCidadeDTO novoObj);

        public IEnumerable<TabelaCidadeDTO> GetAllFromDto();
    }
}
