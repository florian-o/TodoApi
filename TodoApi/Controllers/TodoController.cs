using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
        public ActionResult<Todo.Core.Domain.Todo[]> AddTodo([FromBody] TodoDtos todo)        
        {
            ActionResult result = this.BadRequest();

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
                todo.id = newTodo.idTodo;
                return GetTodo();

            }
            return result;
        }

        // PUT api/<TodoController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateTodo(Todo.Core.Domain.Todo todo)
        {
            if ( todo.idTodo == null)
            {
                return BadRequest();
            }
            this._context.Entry(todo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            try
            {
                await this._context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                var x = ex.Message;
                return NotFound();
            }
            return Ok(todo);
        }

        // DELETE api/<TodoController>/5
       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var todoDelete = await this._context.Todos.FindAsync(id);
            if (todoDelete == null)
            {
                return NoContent();
            }
            this._context.Todos.Remove(todoDelete);
            await this._context.SaveChangesAsync();
            return Ok(todoDelete);
        }
    }
}
