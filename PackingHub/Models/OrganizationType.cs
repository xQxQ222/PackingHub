using System.ComponentModel.DataAnnotations;

namespace PackingHub.Models
{
    public class OrganizationType
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
