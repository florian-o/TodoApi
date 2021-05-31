using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Todo.Core.Domain;
using Todo.Core.Infrastructures.Data;
using TodoApi.Dtos;


namespace TodoApi.Controllers
{
   
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    //[EnableCors("http://localhost:4200/")]
    public class TodoController : ControllerBase
    {
        private readonly TodoProjectContext _context = null;
        private readonly UserManager<ApplicationUser> _userManager;
        public TodoController(TodoProjectContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            _userManager = userManager;
        }


        // GET: api/<TodoController>
        [HttpGet]
       
        public async Task<ActionResult<Todo.Core.Domain.Todo[]>> GetTodo()
         {
           string user = User.Claims.First(c => c.Type == "userId").Value;
           var userId= await this._userManager.FindByIdAsync(user);
          Todo.Core.Domain.Todo[] todos =   this._context.Todos.Where(x=>x.userId == userId.Id).ToArray();
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
        public async Task<ActionResult<Todo.Core.Domain.Todo[]>> AddTodo([FromBody]TodoDtos todo)        
        {
            ActionResult result = this.BadRequest();


            var user = await _userManager.FindByIdAsync(User.Identity.Name);
           
            var newTodo = this._context.Add(new Todo.Core.Domain.Todo
            {
                todoName = todo.todoName,
                todoStatus = todo.todoStatus,
                description = todo.description,
                isModif = todo.isModif,
                image = todo.image,
                todoDay = DateTime.Today,
                updatedAt = DateTime.Now,
                //recuperate id user
               userId = user.Id,
            }).Entity;
            this._context.SaveChanges();
            if (newTodo != null)
            {
                todo.id = newTodo.idTodo;
                return await this.GetTodo();

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
            todo.updatedAt = DateTime.Now;
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
