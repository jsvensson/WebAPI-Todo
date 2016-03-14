using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace TodoAPI.Models
{
    public class TodoContext : DbContext
    {
        private const string Connection = @"Data Source=localhost;Initial Catalog=TodoApp;Integrated Security=True";

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Connection);
        }
    }
}
