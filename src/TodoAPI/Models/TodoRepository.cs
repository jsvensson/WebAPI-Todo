using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    public class TodoRepository : ITodoRepository
    {
        static ConcurrentDictionary<int, TodoItem> _todos = new ConcurrentDictionary<int, TodoItem>();

        public TodoRepository()
        {
            Add(new TodoItem() {Name = "Item 1"});
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _todos.Values;
        }

        public TodoItem Get(int id)
        {
            TodoItem item;
            _todos.TryGetValue(id, out item);
            return item;
        }

        public void Add(TodoItem item)
        {
            item.Id = _todos.Count + 1;
            _todos[item.Id] = item;
        }

        public void Update(TodoItem item)
        {
            _todos[item.Id] = item;
        }

        public TodoItem Remove(int id)
        {
            TodoItem item;
            _todos.TryGetValue(id, out item);
            _todos.TryRemove(id, out item);
            return item;
        }
    }
}
