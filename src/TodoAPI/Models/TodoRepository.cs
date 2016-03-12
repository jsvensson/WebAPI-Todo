﻿using System;
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

        public IEnumerable<TodoItem> GetAll()
        {
            using (var context = new TodoContext())
            {
                return context.TodoItems.ToList();
            }
        }

        public TodoItem Get(int id)
        {
            using (var context = new TodoContext())
            {
                return context.TodoItems.FirstOrDefault(i => i.Id == id);
            }
        }

        public void Add(TodoItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            using (var context = new TodoContext())
            {
                item.CreatedAt = DateTime.UtcNow;
                context.Attach(item);
                context.SaveChanges();
            }
        }

        public void Update(TodoItem item)
        {
            using (var context = new TodoContext())
            {
                var result = context.TodoItems.SingleOrDefault(i => i.Id == item.Id);
                if (result != null)
                {
                    result.Name        = item.Name;
                    result.Description = item.Description;
                    result.IsCompleted = item.IsCompleted;
                    result.CreatedAt   = item.CreatedAt;
                    result.FinishedAt  = item.FinishedAt;

                    context.SaveChanges();
                }
            }
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
