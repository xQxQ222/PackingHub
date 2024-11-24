using System.ComponentModel.DataAnnotations;

namespace PackingHub.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Comments { get; set; }
    }

}
