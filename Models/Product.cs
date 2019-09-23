using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryShop.Models
{
    public class Product
    {
        public Product()
        {

        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        [MaxLength(100)]
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        
        [Required]
        [Range(1,100000)]
        public decimal Price { get; set; }
        public Category Category { get; set; }
    }

    public enum Category
    {
        Cake,
        Pestry
    }
}
