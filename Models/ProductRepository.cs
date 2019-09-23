using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryShop.Models
{
    public class ProductRepository : IProductRepository
    {
        List<Product> products;
        public ProductRepository()
        {
            products = new List<Product>
            {
                new Product
                {
                    Id=1,
                    Name="Red valvet",
                    Price=500,
                    ShortDescription="500 grams, Delosious cake that can be loved by many couples",
                    Category=Category.Cake
                },
                new Product
                {
                    Id=2,
                    Name="Chocklet",
                    Price=300,
                    ShortDescription="500 grams, Delosious cake that can be loved by many Families",
                    Category=Category.Cake
                },
                new Product
                {
                    Id=3,
                    Name="Vanila",
                    Price=250,
                    ShortDescription="500 grams, Delosious cake that can be loved Everyone",
                    Category=Category.Cake
                },
                 new Product
                {
                    Id=4,
                    Name="Friut",
                    Price=600,
                    ShortDescription="500 grams, Delosious cake that can be loved by many Families",
                    Category=Category.Cake
                },
                new Product
                {
                    Id=5,
                    Name="Pineapple",
                    Price=200,
                    ShortDescription="500 grams, Delosious cake that can be loved Everyone",
                    Category=Category.Cake
                }
            };
        }
        public void AddProduct(Product product)
        {
            product.Id = products.Max(item => item.Id) + 1;
            this.products.Add(product);
        }

        public void DeleteProduct(int id)
        {
            this.products.Remove(products.FirstOrDefault(item=>item.Id==id));
        }

        public Product GetProduct(int id)
        {
            return products.FirstOrDefault(item => item.Id == id);
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public void UpdateProduct(Product product)
        {
            var selectedProduct = products.FirstOrDefault(item => item.Id == product.Id);
            products[products.IndexOf(selectedProduct)] = product;
        }
    }
}
