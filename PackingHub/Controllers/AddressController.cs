using Microsoft.AspNetCore.Mvc;
using PackingHub.Models;

namespace PackingHub.Controllers
{
    [Route("Address")]
    public class AddressController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddressController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Метод для получения списка адресов
        [HttpGet("GetAddressList")]
        public IActionResult GetAddressList()
        {
            var addresses = _context.Addresses.ToList();
            return PartialView("_AddressCards", addresses);
        }

        // Метод для создания нового адреса
        [HttpPost("CreateAddress")]
        public IActionResult CreateAddress([FromBody] Address newAddress)
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
