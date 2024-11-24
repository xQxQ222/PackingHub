using Microsoft.AspNetCore.Mvc;
using PackingHub.Models;

namespace PackingHub.Controllers
{
    [Route("Actions")]
    public class ActionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Метод для получения списка адресов
        [HttpGet("GetActionsList")]
        public IActionResult GetActionsList()
        {
            var addresses = _context.Actions.ToList();
            return PartialView("_ActionsCards", addresses);
        }

        // Метод для создания нового адреса
        [HttpPost("CreateAction")]
        public IActionResult CreateAction([FromBody] Models.Action newAction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newAction);
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest("Invalid data.");
        }
    }
}
