using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IndustryLocationSelector.Data.Entity
{
    public class PlaceType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Place> Places { get; set; } = new List<Place>();
    }
}
