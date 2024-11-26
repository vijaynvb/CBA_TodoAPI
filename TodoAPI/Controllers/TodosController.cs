using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Data;
using TodoAPI.DTO;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TodosController : ControllerBase
    {
        private readonly TodoDBContext _context;
        public readonly IMapper _mapper;

        public TodosController(TodoDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [AllowAnonymous]
        // GET: api/Todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodo()
        {
          if (_context.Todo == null)
          {
              return NotFound();
          }
            return await _context.Todo.ToListAsync();
        }
        
        // GET: api/Todos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodo(Guid id)
        {
          if (_context.Todo == null)
          {
              return NotFound();
          }
            var todo = await _context.Todo.FindAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            return todo;
        }

        // PUT: api/Todos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodo([FromRoute]Guid id,[FromBody] TodoDTO todo)
        {

            Todo newTodo = new Todo();
            
            newTodo = _mapper.Map<Todo>(todo);

            /*newTodo.Title = todo.Title;
            newTodo.Description = todo.Description;
            newTodo.DueDate = todo.DueDate;
            newTodo.TodoUserId = todo.UserId;*/
            newTodo.Id = id;

            if (id != newTodo.Id)
            {
                return BadRequest();
            }

            _context.Entry(newTodo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Todos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Todo>> PostTodo([FromBody]TodoDTO todo)
        {
          if (_context.Todo == null)
          {
              return Problem("Entity set 'TodoDBContext.Todo'  is null.");
          }

            Todo newTodo = new Todo();
            newTodo = _mapper.Map<Todo>(todo);

            /*newTodo.Title = todo.Title;
            newTodo.Description = todo.Description;
            newTodo.DueDate = todo.DueDate;
            newTodo.TodoUserId = todo.UserId; */

            _context.Todo.Add(newTodo);

            await _context.SaveChangesAsync();

            TodoResposeDTO responseDTO = new TodoResposeDTO();
            
            responseDTO = _mapper.Map<TodoResposeDTO>(newTodo);
            /*responseDTO.Id = newTodo.Id;
            responseDTO.Title = newTodo.Title;
            responseDTO.Description = newTodo.Description;
            responseDTO.DueDate = newTodo.DueDate;
            responseDTO.UserId = newTodo.TodoUserId;*/


            return CreatedAtAction("GetTodo", new { id = responseDTO.Id }, responseDTO);
        }

        // DELETE: api/Todos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            if (_context.Todo == null)
            {
                return NotFound();
            }
            var todo = await _context.Todo.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Todo.Remove(todo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoExists(Guid id)
        {
            return (_context.Todo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
