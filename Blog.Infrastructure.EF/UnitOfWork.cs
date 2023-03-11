using Common.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogDbContext _dbcontext;

        public UnitOfWork(BlogDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void BeginTrans()
        {
            _dbcontext.Database.BeginTransaction(); 
        }

        public void CommitTrans()
        {
            _dbcontext.SaveChanges();
            _dbcontext.Database.CommitTransaction();

        }

        public void RollBack()
        {
            _dbcontext.Database.RollbackTransaction();
        }
    }
}
