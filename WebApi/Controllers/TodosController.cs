using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Todos;
using WebApi.Repos.Todos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        //{
        //    "id": "e60f6e6a-4f42-49f3-8923-b4d68e429029"
        //    "type": "task",
        //    "title": "Вынести мусор",
        //    "text": "Уже семь пакетов"
        //}
        private readonly ITodosRepository _todosRepository;

        public TodosController(ITodosRepository todosRepository)
        {
            _todosRepository = todosRepository;
        }

        // GET /todos
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Request.Headers.TryGetValue("X-Auth", out var authToken);
            return Ok(await _todosRepository.GetAsync());
        }

        // POST /todos
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TodoInfo todoInfo)
        {
            Request.Headers.TryGetValue("X-Auth", out var authToken);
            var result = await _todosRepository.PostAsync(todoInfo);
            if (!string.IsNullOrEmpty(result.Error))
            {
                return BadRequest(new { Error = result.Error });
            }

            return Created(string.Empty, new {Id = result.Id});
        }

        // DELETE /todos/1eed8b01-1a8b-45e0-8414-1788c2acb7cd
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            Request.Headers.TryGetValue("X-Auth", out var authToken);
            var delete = await _todosRepository.DeleteAsync(id);
            if (!delete)
            {
                return NotFound(new {Error = "Item not found"});
            }
            return Ok();
        }

        // PATCH /todos/1eed8b01-1a8b-45e0-8414-1788c2acb7cd
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody]TodoInfo todoInfo)
        {
            Request.Headers.TryGetValue("X-Auth", out var authToken);
            var patched = await _todosRepository.PatchAsync(id, todoInfo);
            if (!patched)
            {
                return NotFound(new {Error = "Item not found"});
            }

            return Ok();
        }
    }
}