using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WaracleCake.Models.RequestDto
{
    public class CakeDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "The comment must be between {2}-{1} characters long", MinimumLength = 5)]
        public string Comment { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public int YumFactor { get; set; }
    }
}
