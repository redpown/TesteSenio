using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testesenior.domain.Interface
{
    public interface IServiceBase<Tentite> : IDisposable
        where Tentite : class 
    {
        public void InsertDTO(Tentite obj);
        public void DeleteId(int id);

        public void UpdateByDTO(Tentite novoObj);

        public IEnumerable<Tentite> GetAllFromDto();

        public Tentite SelectDTO(int id);
    }
}
