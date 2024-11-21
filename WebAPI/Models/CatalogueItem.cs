using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class CatalogueItem
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImgUri { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
