using System.ComponentModel.DataAnnotations;

namespace PackingHub.Models
{
    public class Transport
    {
        [Key]
        public string VinNumber { get; set; }
        public string VehicleType { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double LoadCapacity { get; set; }
        public double BodyVolume { get; set; }
        public string Comments { get; set; }
    }

}
