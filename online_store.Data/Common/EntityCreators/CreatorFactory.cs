using online_store.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Data.Common.EntityCreators
{
    class CreatorFactory
    {
        public static IEntityCreator<T> Create<T>()
        {
            if (typeof(T) == typeof(Project))
            {
                 return (IEntityCreator<T>)new ProjectCreator();
            }

            if (typeof(T) == typeof(Category))
            {
                return (IEntityCreator<T>)new CategoryCreator();
            }

            if (typeof(T) == typeof(Tag))
            {
                return (IEntityCreator<T>)new TagCreator();
            }

            if (typeof(T) == typeof(TodoTask))
            {
                return (IEntityCreator<T>)new TaskCreator();
            }

            if (typeof(T) == typeof(User))
            {
                return (IEntityCreator<T>)new UserCreator();
            }

            return default;
        }
    }
}
