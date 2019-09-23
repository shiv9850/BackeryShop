using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BakeryShop.Models
{
    public class ProductCreateModel
    {
        [Required]
        public string Name { get; set; }

        public IFormFile Image { get; set; }

        [MaxLength(100)]
        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        [Required]
        [Range(1, 100000)]
        public decimal Price { get; set; }

        public Category Category { get; set; }
    }
}
