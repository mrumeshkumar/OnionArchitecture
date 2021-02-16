using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnionArchitectureDotNet.Core.Entities;

namespace OnionArchitectureDotNet.Core.Interfaces.Repository
{
   public interface ITaskItemRepository
    {
        Task<bool> Add(TaskItem taskItem);
        Task<bool> Update(TaskItem taskItem);
        List<TaskItem> GetAll();
        Task<TaskItem> GetById(int id);
        Task<bool> Delete(int id);
    }
}
