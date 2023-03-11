using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure
{
    public interface IUnitOfWork
    {
        void BeginTrans();
        void CommitTrans();
        void RollBack();
    }
}
