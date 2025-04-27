using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Models;
using TodoList.Services;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        [HttpGet("GetAll")]

        public ActionResult<IEnumerable<Todoitems>> GetAll()
        {
            return Ok(_todoService.GetAll());

        }
        [HttpGet("Get")]
        public ActionResult<Todoitems> Get(int id)
        {
            var item = _todoService.GetById(id);
            if (item == null)
                return NotFound();

            return Ok(item); ;
        }

        [HttpPost("Create")]
        public ActionResult<Todoitems> Create(Todoitems item) { 
        _todoService.Create(item);
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }
        [HttpPut("Update/{id}")]
        public ActionResult Update(int id, Todoitems updated) {
            bool result = _todoService.update(id, updated);
               if(result== false) return NotFound();
            return NoContent();
        }
        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id) {
            if (!_todoService.Delete(id)) return NotFound();
                return NoContent();

        }

    }

}
