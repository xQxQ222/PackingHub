using Microsoft.AspNetCore.Mvc;
using PackingHub.Models;

namespace PackingHub.Controllers
{
    [Route("CargoRestriction")]
    public class CargoRestrictionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CargoRestrictionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Метод для получения списка адресов
        [HttpGet("GetCargoRestrictionList")]
        public IActionResult GetActionsList()
        {
            var addresses = _context.CargoRestrictions.ToList();
            return PartialView("_CargoRestrictionCards", addresses);
        }

        // Метод для создания нового адреса
        [HttpPost("CreateCargoRestriction")]
        public IActionResult CreateAction([FromBody] Models.CargoRestriction newAction)
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
