using Microsoft.AspNetCore.Mvc;
using PackingHub.Models;

namespace PackingHub.Controllers
{
    [Route("Cargos")]
    public class CargoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CargoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Метод для получения списка адресов
        [HttpGet("GetCargoList")]
        public IActionResult GetCargoRestrictionList()
        {
            var addresses = _context.Cargos.ToList();
            return PartialView("_CargoCards", addresses);
        }

        // Метод для создания нового адреса
        [HttpPost("CreateCargo")]
        public IActionResult CreateCargoRestriction([FromBody] Cargo newCargoRestriction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newCargoRestriction);
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest("Invalid data.");
        }
    }
}
