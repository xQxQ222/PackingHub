using Microsoft.AspNetCore.Mvc;
using PackingHub.HelperMethods;
using PackingHub.Models;

namespace PackingHub.Controllers
{
    [Route("Routes")]
    public class RouteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RouteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Метод для получения списка адресов
        [HttpGet("GetRoutesList")]
        public IActionResult GetAddressList()
        {
            var routes = _context.Routes
                .Select(x => new RouteWithAddressArray(
                    x,
                    _context.Addresses.Where(address => x.AddressesNumbers.Contains(address.Id)).ToArray(),
                    _context.Transports.Where(tr => tr.VinNumber == x.Transport).FirstOrDefault()
                    ))
                .ToList();
            return PartialView("_RoutesCards", routes);
        }

        // Метод для создания нового адреса
        [HttpPost("CreateRoute")]
        public IActionResult CreateAddress([FromBody] Models.Route newAddress)
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
