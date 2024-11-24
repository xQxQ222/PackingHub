using System.ComponentModel.DataAnnotations;

namespace PackingHub.Models
{
    public class Route
    {
        [Key]
        public int RouteNumber { get; set; }
        public string AddressesNumbers { get; set; }
        public int Length { get; set; }
        public string Transport { get; set; }
        public DateOnly DepartureDate { get; set; }
        public DateOnly ArrivalDate { get; set; }
        public string Comments { get; set; }
    }

}
