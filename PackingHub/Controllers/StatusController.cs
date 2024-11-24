using Microsoft.AspNetCore.Mvc;
using PackingHub.Models;

namespace PackingHub.Controllers
{
    [Route("Statuses")]
    public class StatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Метод для получения списка адресов
        [HttpGet("GetStatusesList")]
        public IActionResult GetAddressList()
        {
            var addresses = _context.Statuses.ToList();
            return PartialView("_StatusesCards", addresses);
        }

        // Метод для создания нового адреса
        [HttpPost("CreateStatus")]
        public IActionResult CreateAddress([FromBody] Status newAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newAddress);
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest("Invalid data.");
        }
    }
}
