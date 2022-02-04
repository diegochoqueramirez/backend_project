using online_store.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Core.Interfaces
{
    public interface ITaskRepository : IRepository<TodoTask, Guid>
    {
    }
}
