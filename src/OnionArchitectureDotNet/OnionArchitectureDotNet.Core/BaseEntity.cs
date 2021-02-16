using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitectureDotNet.Core
{
    public class BaseEntity
    {
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public string CreatedById { get; set; }
        public string ModifiedById { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
