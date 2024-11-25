using Microsoft.AspNetCore.Mvc;
using PackingHub.Calculate;
using PackingHub.HelperMethods;
using PackingHub.Models;

namespace PackingHub.Controllers
{
    [Route("Load")]
    public class LoadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoadController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetCargos")]
        public IActionResult GetCargos()
        {
            var cargos = _context.Cargos
                .ToList();

            return PartialView("_CargosStep", cargos);
        }

        [HttpGet("GetContainers")]
        public IActionResult GetContainers()
        {
            var containers = _context.Containers
                .ToList();

            return PartialView("_ContainersStep", containers);
        }

        [HttpGet("GetRoutes")]
        public IActionResult GetRoutes()
        {
            var routes = _context.Routes
                .Select(x=>new RouteWithAddressArray(
                    x,
                    _context.Addresses.Where(address=>x.AddressesNumbers.Contains(address.Id)).ToArray(),
                    _context.Transports.Where(tr=>tr.VinNumber==x.Transport).FirstOrDefault()
                    ))
                .ToList();

            return PartialView("_RoutesStep", routes);
        }

        [HttpGet("SubmitLoad")]
        public IActionResult SubmitLoad()
        {
            var container=new ContainerToCalc(_context.Containers.First());
            List<CargoToCalc> cargosList=_context.Cargos.Select(x=>new CargoToCalc(x)).ToList();
            BestFitPacker.Step = 0.5f;
            var result = new List<ContainerToCalc>
            {
                BestFitPacker.Pack(container, cargosList)
            };
            return PartialView("_ResultCard", result);

        }

    }
}
