using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure
{
    public class BaseRepository<T, Tkey> : IRepository<T, Tkey> where T : DomainBase<Tkey>
    {
        private readonly DbContext _dbcontex;

        public BaseRepository(DbContext dbcontex)
        {
            _dbcontex = dbcontex;
        }

        public void Create(T entity)
        {
            _dbcontex.Add<T>(entity);
            Save();

        }

        
        public bool Exists(Expression<Func<T, bool>> expr)
        {
            return _dbcontex.Set<T>().Any(expr);
        }

        public T Get(Tkey id)
        {
           return _dbcontex.Find<T>(id);
        }

        public List<T> GetAll()
        {
          return  _dbcontex.Set<T>().ToList();
        }

        public void Save()
        {
            _dbcontex.SaveChanges();
        }

    }
}
