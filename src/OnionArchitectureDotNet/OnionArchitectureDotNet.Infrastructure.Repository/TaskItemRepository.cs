using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnionArchitectureDotNet.Core.Entities;
using OnionArchitectureDotNet.Core.Interfaces.Repository;
using Dapper;
using System.Data;
using System.Linq;
using System.Data.SqlClient;

namespace OnionArchitectureDotNet.Infrastructure.Repository
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly IDbContext _dbContext;
        public TaskItemRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<bool> Add(TaskItem taskItem)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TaskItem> GetAll()
        {
            try
            {
                List<TaskItem> taskItems = _dbContext.Connection.Query<TaskItem>(sql: "usp_GetAllToDoItem", commandType: CommandType.StoredProcedure).ToList();
                
                return taskItems;
  
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<TaskItem> GetById(int id)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("TaskID", id, DbType.Int32);

               var taskItem = _dbContext.Connection.QueryFirstAsync<TaskItem>(sql: "usp_GetAllToDoItemByTaskID", param: p, commandType: CommandType.StoredProcedure);

                return taskItem;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public Task<bool> Update(TaskItem taskItem)
        {
            throw new NotImplementedException();
        }
    }
}
