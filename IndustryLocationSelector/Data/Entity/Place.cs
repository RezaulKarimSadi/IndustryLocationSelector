using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IndustryLocationSelector.Data.Entity
{
    public class Place
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public PlaceType PlaceType { get; set; }
        public int PlaceTypeId { get; set; }


    }
}
