using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDosController : ControllerBase
    {
        private readonly ToDoProviderFactory _factory;

        public ToDosController(ToDoProviderFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDo>>> GetToDos(
            [FromQuery] string? provider,
            [FromQuery] string? search    
        )
        {
            var svc = _factory.GetProvider(provider);
            var todos = await svc.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(search))
            {
                todos = todos
                    .Where(t => !string.IsNullOrEmpty(t.Title)
                             && t.Title.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return Ok(todos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ToDo>> GetToDo(
            int id,
            [FromQuery] string? provider
        )
        {
            var svc = _factory.GetProvider(provider);
            var todo = await svc.GetByIdAsync(id);
            if (todo == null) return NotFound();
            return Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult<ToDo>> CreateToDo(
            [FromBody] ToDo todo,
            [FromQuery] string? provider
        )
        {
            var svc = _factory.GetProvider(provider);
            var created = await svc.CreateAsync(todo);
            return CreatedAtAction(
                nameof(GetToDo),
                new { id = created.Id, provider },
                created
            );
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDo(
            int id,
            [FromBody] ToDo updatedToDo,
            [FromQuery] string? provider
        )
        {
            if (id != updatedToDo.Id) return BadRequest();

            var svc = _factory.GetProvider(provider);
            var result = await svc.UpdateAsync(id, updatedToDo);
            if (result == null) return NotFound();
            return NoContent();
        }

  
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDo(
            int id,
            [FromQuery] string? provider
        )
        {
            var svc = _factory.GetProvider(provider);
            var success = await svc.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}