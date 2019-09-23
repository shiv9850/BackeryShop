using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BakeryShop.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BakeryShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository ProductRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public ProductController(IProductRepository productRepository,IHostingEnvironment hostingEnvironment)
        {
            ProductRepository = productRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        public ViewResult Index(string searchString)
        {
            var products = ProductRepository.GetProducts();
            return View(!string.IsNullOrEmpty(searchString) ? products.FindAll(item=>item.Name.Contains(searchString)) : products);
        }


        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductCreateModel model)
        {
            throw new Exception("Test error");
            if (ModelState.IsValid)
            {
                ProductRepository.AddProduct(MapToProduct(model, GetImageName(model)));
                return RedirectToAction("index");
            }
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            var product = ProductRepository.GetProduct(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductEditModel model)
        {
            if (ModelState.IsValid)
            {
                string imageName = GetImageName(model);
                var product = MapToProduct(model, imageName);
                product.Id = model.Id;
                ProductRepository.UpdateProduct(product);
                return RedirectToAction("index");
            }
            return View();
        }

        public ViewResult Details(int id)
        {
            var product = ProductRepository.GetProduct(id);
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            ProductRepository.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        private string GetImageName(ProductCreateModel model)
        {
            string imageName = string.Empty;
            if (model.Image != null)
            {
                imageName = $"{Guid.NewGuid()}_{model.Image.FileName}";
                using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images", imageName), FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                }
            }

            return imageName;
        }

        private Product MapToProduct(ProductCreateModel model,string imageName)
        {
           return new Product
            {
                Category = model.Category,
                Image = imageName,
                FullDescription = model.FullDescription,
                Name = model.Name,
                Price = model.Price,
                ShortDescription = model.ShortDescription
            };
        }
    }
}