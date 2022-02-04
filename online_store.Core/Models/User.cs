using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace online_store.Core.Models
{
    public class User
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public Guid ProjectId { get; set; }
    }
}
