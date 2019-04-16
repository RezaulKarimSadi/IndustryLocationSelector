using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IndustryLocationSelector.Data.Entity
{
    public class OrganizationType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Organizations> Organizations { get; set; } = new List<Organizations>();
    }
}