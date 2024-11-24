using Microsoft.AspNetCore.Mvc;
using PackingHub.Models;

namespace PackingHub.Controllers
{
    [Route("Containers")]
    public class ContainersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContainersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Метод для получения списка адресов
        [HttpGet("GetContainersList")]
        public IActionResult GetContainersList()
        {
            var containers = _context.Containers.ToList();
            return PartialView("_ContainersCards", containers);
        }

        // Метод для создания нового адреса
        [HttpPost("CreateContainer")]
        public IActionResult CreateContainer([FromBody] Container newContainer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newContainer);
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest("Invalid data.");
        }
    }
}

