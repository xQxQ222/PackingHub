using System.ComponentModel.DataAnnotations;

namespace PackingHub.Models
{
    public class Organization
    {
        [Key]
        public int Inn { get; set; }
        public string Name { get; set; }
        public string OrganizationType { get; set; }
        public int LegalNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }

}
