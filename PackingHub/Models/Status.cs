using System.ComponentModel.DataAnnotations;

namespace PackingHub.Models
{
    public class Status
    {
        [Key]
        public string Name { get; set; }
        public bool CargoStatus { get; set; }
        public bool ContainerStatus { get; set; }
        public bool PlanStatus { get; set; }
        public string Description { get; set; }
    }

}
