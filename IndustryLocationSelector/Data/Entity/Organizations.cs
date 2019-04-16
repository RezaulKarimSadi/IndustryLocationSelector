using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IndustryLocationSelector.Data.Entity
{
    public class Organizations
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="you must enter your name")]
        public string Name { get; set; }
        [Display(Name="Organization Type")]
        public int OrganizationTypeId { get; set; }
        public OrganizationType OrganizationType { get; set; }
        [Required]
        public float Latitude { get; set; }      
        [Required]
        public float Longitude { get; set; }
    }
}
