using System.ComponentModel.DataAnnotations;

namespace PackingHub.Models
{
    public class Cargo
    {
        [Key]
        public int Number { get; set; }
        public string Name { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public string Supplier { get; set; }
        public string Customer { get; set; }
        public string DeliveryAddress { get; set; }
        public bool  Fragility { get; set; }

        public bool Flammable { get; set; }
        public bool ChemicallyActive { get; set; }
        public string Status { get; set; }
        public bool AdditionalEquipment { get; set; }
    }

}
