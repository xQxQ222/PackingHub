using System.ComponentModel.DataAnnotations;

namespace PackingHub.Models
{
    public class Plan
    {
        [Key]
        public int Number { get; set; }
        public int ContainerNumber { get; set; }
        public int[] CargoNumbers { get; set; }
        public string Status { get; set; }
        public int RouteNumber { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }

}
