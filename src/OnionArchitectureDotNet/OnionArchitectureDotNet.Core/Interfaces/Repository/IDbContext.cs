using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureDotNet.Core.Interfaces.Repository
{
   public interface IDbContext
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        Task<IDbTransaction> OpenTransaction();
        Task<IDbTransaction> OpenTransaction(IsolationLevel level);
        void CommitTransaction(bool disposeTrans = true);
        void RollbackTransaction(bool disposeTrans = true);
    }
}
