using Microsoft.AspNetCore.Mvc;
using PackingHub.Models;

namespace PackingHub.Controllers
{
    [Route("OrganizationTypes")]
    public class OrganizationTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizationTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Метод для получения списка адресов
        [HttpGet("GetOrganizationTypesList")]
        public IActionResult GetAddressList()
        {
            var addresses = _context.OrganizationTypes.ToList();
            return PartialView("_OrganizationTypesCards", addresses);
        }

        // Метод для создания нового адреса
        [HttpPost("CreateOrganizationType")]
        public IActionResult CreateAddress([FromBody] OrganizationType newAddress)
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
