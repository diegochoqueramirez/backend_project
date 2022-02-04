using System;
using System.Collections.Generic;
using System.Text;

namespace online_store.Core.Models
{
    public class TaskTag
    {
        public Guid TaskId { get; set; }

        public string TagId { get; set; }
    }
}
