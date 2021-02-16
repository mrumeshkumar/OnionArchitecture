using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnionArchitectureDotNet.Core.Entities;
namespace OnionArchitectureDotNet.Core.Interfaces.Services
{
   public interface ITaskItemService
    {
        Task<bool> AddAsync(TaskItem taskItem);
        Task<bool> UpdateAsync(TaskItem taskItem);
        List<TaskItem> GetAllAsync();
        Task<TaskItem> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
