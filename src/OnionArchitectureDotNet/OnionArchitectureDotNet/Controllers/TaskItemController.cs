using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using OnionArchitectureDotNet.Core.Entities;
using OnionArchitectureDotNet.Core.Interfaces.Services;
using OnionArchitectureDotNet.Service;

namespace OnionArchitectureDotNet.Controllers
{
    public class TaskItemController : ApiController
    {
        private readonly ITaskItemService _taskItemService;
        public TaskItemController(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }
        // GET: api/TaskItem
        public List<TaskItem> Get()
        {
            List<TaskItem> listTaskItem = new List<TaskItem>();
            listTaskItem =  _taskItemService.GetAllAsync();
            return listTaskItem;
        }

        // GET: api/TaskItem/5
        public Task<TaskItem> Get(int id)
        {
            Task<TaskItem> taskItems = _taskItemService.GetByIdAsync(id);
            return taskItems;
        }

        // POST: api/TaskItem
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TaskItem/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TaskItem/5
        public void Delete(int id)
        {
        }
    }
}
