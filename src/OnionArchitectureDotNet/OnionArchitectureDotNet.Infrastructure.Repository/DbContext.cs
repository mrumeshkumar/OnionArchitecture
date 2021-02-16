using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using OnionArchitectureDotNet.Core.Interfaces.Repository;

namespace OnionArchitectureDotNet.Infrastructure.Repository
{
    public class DbContext: IDbContext
    {
        protected IDbConnection _cn = null;
        public IDbConnection Connection
        {
            get => _cn;
        }
        protected IDbTransaction _trans = null;
        public IDbTransaction Transaction
        {
            get => _trans;
        }
        private string ConnectionString => System.Configuration.ConfigurationManager.ConnectionStrings["ToDoDBConnection"].ConnectionString;

        public DbContext()
        {
            //DefaultTypeMap.MatchNamesWithUnderscores = true;
            _cn = new SqlConnection(ConnectionString);
        }
        /// <summary>
        /// Open a transaction
        /// </summary>
        public async Task<IDbTransaction> OpenTransaction()
        {
            if (_trans != null)
                throw new Exception("A transaction is already open, you need to use a new HRISDbContext for parallel job.").InnerException;

            if (_cn.State == ConnectionState.Closed)
            {
                if (!(_cn is DbConnection))
                    throw new Exception("Connection object does not support OpenAsync.").InnerException;

                await (_cn as DbConnection).OpenAsync();
            }

            _trans = _cn.BeginTransaction();

            return _trans;
        }


        /// <summary>
        /// Open a transaction with a specified isolation level
        /// </summary>
        public async Task<IDbTransaction> OpenTransaction(IsolationLevel level)
        {
            if (_trans != null)
                throw new Exception("A transaction is already open, you need to use a new HRISDbContext for parallel job.").InnerException;

            if (_cn.State == ConnectionState.Closed)
            {
                if (!(_cn is DbConnection))
                    throw new Exception("Connection object does not support OpenAsync.").InnerException;

                await (_cn as DbConnection).OpenAsync();
            }

            _trans = _cn.BeginTransaction(level);

            return _trans;
        }


        /// <summary>
        /// Commit the current transaction, and optionally dispose all resources related to the transaction.
        /// </summary>
        public void CommitTransaction(bool disposeTrans = true)
        {
            if (_trans == null)
                throw new Exception("DB Transaction is not present.").InnerException;

            _trans.Commit();
            if (disposeTrans) _trans.Dispose();
            if (disposeTrans) _trans = null;
        }

        /// <summary>
        /// Rollback the transaction and all the operations linked to it, and optionally dispose all resources related to the transaction.
        /// </summary>
        public void RollbackTransaction(bool disposeTrans = true)
        {
            if (_trans == null)
                throw new Exception("DB Transaction is not present.").InnerException;

            _trans.Rollback();
            if (disposeTrans) _trans.Dispose();
            if (disposeTrans) _trans = null;
        }

        /// <summary>
        /// Will be call at the end of the service (ex : transient service in api net core)
        /// </summary>
        public void Dispose()
        {
            _trans?.Dispose();
            _cn?.Close();
            _cn?.Dispose();
        }
    }
}