using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitectureDotNet.Core.Entities
{
    public class TaskItem : BaseEntity
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
