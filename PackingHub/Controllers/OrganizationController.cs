using Microsoft.AspNetCore.Mvc;
using PackingHub.Models;

namespace PackingHub.Controllers
{
    [Route("Organizations")]
    public class OrganizationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Метод для получения списка адресов
        [HttpGet("GetOrganizationsList")]
        public IActionResult GetAddressList()
        {
            var addresses = _context.Organizations.ToList();
            return PartialView("_OrganizationCards", addresses);
        }

        // Метод для создания нового адреса
        [HttpPost("CreateOrganization")]
        public IActionResult CreateAddress([FromBody] Organization newAddress)
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
