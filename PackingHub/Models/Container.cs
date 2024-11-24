using System.ComponentModel.DataAnnotations;

namespace PackingHub.Models
{
    public class Container
    {
        [Key]
        public int Number { get; set; }
        public string Name { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public float WallThickness { get; set; }
        public string Status { get; set; }
    }

}
