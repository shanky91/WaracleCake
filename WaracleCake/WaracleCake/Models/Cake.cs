using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WaracleCake.Models
{
    public class Cake
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public int YumFactor { get; set; }
    }
}
