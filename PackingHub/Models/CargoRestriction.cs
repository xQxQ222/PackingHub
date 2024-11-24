using System.ComponentModel.DataAnnotations;

namespace PackingHub.Models
{
    public class CargoRestriction
    {
        [Key]
        public int Id { get; set; }
        public int Cargo1Id { get; set; }
        public int Cargo2Id { get; set; }
        public string Restriction { get; set; }
    }
}
