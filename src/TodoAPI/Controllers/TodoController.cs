using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        [FromServices]
        public ITodoRepository TodoItems { get; set; }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return TodoItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(int id)
        {
            var item = TodoItems.Get(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(item);
        }
    }
}
