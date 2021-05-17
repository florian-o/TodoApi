using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Core.Infrastructures.Data;
using TodoApi.Dtos;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoProjectContext _context = null;
        public TodoController(TodoProjectContext context)
        {
            this._context = context;
        }


        // GET: api/<TodoController>
        [HttpGet]
        public ActionResult<Todo.Core.Domain.Todo[]> GetTodo()
        {

            Todo.Core.Domain.Todo[] todos = this._context.Todos.Select(x => x).ToArray();
            return todos;
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public IActionResult GetTodoById([FromQuery] int id)
        {
            if (id != 0)
            {
                var todo = this._context.Todos.Select(x => x.idTodo).ToArray();
                return Ok(todo);
            }
            return NoContent();
        }

        // POST api/<TodoController>
        [HttpPost]
        public IActionResult AddTodo([FromBody] TodoDtos todo)
        {
            IActionResult result = this.BadRequest();

            var newTodo = this._context.Add(new Todo.Core.Domain.Todo
            {
                todoName=todo.todoName,
                todoStatus=todo.todoStatus,
                description=todo.description,
                isModif=todo.isModif,
                image=todo.image,
                todoDay=DateTime.Today,
                updatedAt=DateTime.Now,
            }).Entity;
            this._context.SaveChanges();
            if (newTodo != null)
            {
                return this.Ok(todo);

            }
            return result;
        }

        // PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
