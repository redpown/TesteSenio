using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testesenior.domain.Interface
{
    public interface IBaseRepository<Tentity> : IDisposable where Tentity : class
    {
        public void Insert(Tentity entity);
        public Tentity Select(int id);
        public IEnumerable<Tentity> GetAll();
        public void Update(Tentity entity);
        public void Delete(Tentity entity);
    }
}
