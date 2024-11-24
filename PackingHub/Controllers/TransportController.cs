using Microsoft.AspNetCore.Mvc;
using PackingHub.Models;

namespace PackingHub.Controllers
{
    [Route("Transport")]
    public class TransportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransportController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Метод для получения списка транспорта
        [HttpGet("GetTransportList")]
        public IActionResult GetTransportList()
        {
            var transports = _context.Transports.ToList();
            return PartialView("_TransportList", transports);
        }

        // Метод для добавления нового транспорта
        [HttpPost("CreateTransport")]
        public IActionResult Create([FromBody] Transport transport)
        {
            if (ModelState.IsValid)
            {
                _context.Transports.Add(transport);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest("Invalid data");
        }
    }
}
