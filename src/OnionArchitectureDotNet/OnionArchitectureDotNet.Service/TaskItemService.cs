using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnionArchitectureDotNet.Core.Entities;
using OnionArchitectureDotNet.Core.Interfaces.Services;
using OnionArchitectureDotNet.Core.Interfaces.Repository;


namespace OnionArchitectureDotNet.Service
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _taskItemRepository;
        public TaskItemService(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }
        public Task<bool> AddAsync(TaskItem taskItem)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public  List<TaskItem> GetAllAsync()
        {
            List<TaskItem> taskItems = new List<TaskItem>();

            taskItems =  _taskItemRepository.GetAll();

            return taskItems;
        }

        public Task<TaskItem> GetByIdAsync(int id)
        {
            Task<TaskItem> taskItems = _taskItemRepository.GetById(id);

            return taskItems;
        }

        public Task<bool> UpdateAsync(TaskItem taskItem)
        {
            throw new NotImplementedException();
        }
    }
}
