using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure
{
    public interface IRepository<T,in Tkey> where T :DomainBase<Tkey>
    {
        void Create(T entity);
        T Get(Tkey id);
        List<T> GetAll();
        bool Exists(Expression<Func<T, bool>> expr);
        void Save();
    }
}
