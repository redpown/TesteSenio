using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testesenior.domain.Interface;
using TesteSenior.Data.Context;

namespace TesteSenior.Data.Repositorios
{
    public class BaseRepository<Tentity> : IBaseRepository<Tentity> where Tentity : class
    {
        protected readonly IMapper _mapper;
        protected readonly TesteSeniorConext _TesteSeniorConext;
        

        public BaseRepository(TesteSeniorConext TesteSeniorConext, IMapper mapper)
        {

            _TesteSeniorConext = TesteSeniorConext;
            _mapper = mapper;
        }
        public void Insert(Tentity entity)
        {
            _TesteSeniorConext.Set<Tentity>().Add(entity);
            _TesteSeniorConext.SaveChanges();//sem isso nao salva na base
        }
                

        public void Update(Tentity entity)
        {
            _TesteSeniorConext.Entry(entity).State = EntityState.Modified;
            _TesteSeniorConext.SaveChanges();
        }

        public void Dispose()
        {
            _TesteSeniorConext.Dispose();
        }

        public Tentity Select(int id)
        {
            return _TesteSeniorConext.Set<Tentity>().Find(id);
        }

        public IEnumerable<Tentity> GetAll()
        {
            return _TesteSeniorConext.Set<Tentity>().ToList();
        }

        public void Delete(Tentity entity)
        {
            _TesteSeniorConext.Set<Tentity>().Remove(entity);
            _TesteSeniorConext.SaveChanges();
        }
    }
}
