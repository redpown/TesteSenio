using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testesenior.domain.Entity;
using testesenior.Domain.DTO;

namespace testesenior.domain.Interface
{
    public interface ITabelaPagamentosCondominioRepository : IBaseRepository<TabelaPagamentosCondominio>
    {
        public NovoTabelaPagamentosCondominioDTO SelectDTO(int id);
        public void InsertDTO(NovoTabelaPagamentosCondominioDTO entity);
        public void DeleteId(int id);

        public void UpdateByDTO(TabelaPagamentosCondominioDTO Obj);

        public IEnumerable<TabelaPagamentosCondominioDTO> GetAllFromDto();

        
    }
}
