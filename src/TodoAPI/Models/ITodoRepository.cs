using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    public interface ITodoRepository
    {
        void Add(TodoItem item);
        IEnumerable<TodoItem> GetAll();
        TodoItem Get(int id);
        TodoItem Remove(int id);
        void Update(TodoItem item);
    }
}
