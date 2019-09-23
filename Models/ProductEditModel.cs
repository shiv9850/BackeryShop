using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryShop.Models
{
    public class ProductEditModel : ProductCreateModel
    {
        public int Id { get; set; }

        public string ExistingImage { get; set; }
    }
}
