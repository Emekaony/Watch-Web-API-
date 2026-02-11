using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    // every controller must inherit from the ControllerBase class & also end in the word "controller"
    public class ProductsController : ControllerBase {
        private static readonly List<Product> _products = [
            new() { ID = 1, Name = "Mechanical Keyboard", Description = "RGB Backlit", Price = 99.99m },
            new() { ID = 2, Name = "Wireless Mouse", Description = "Ergonomic 5-button", Price = 49.50m },
            new() { ID = 3, Name = "4K Monitor", Description = "27-inch IPS panel", Price = 299.00m },
            new() { ID = 4, Name = "USB-C Hub", Description = "7-in-1 Aluminum", Price = 35.00m },
            new() { ID = 5, Name = "Webcam", Description = "1080p with Mic", Price = 65.25m },
            new() { ID = 6, Name = "Headphones", Description = "Noise Cancelling", Price = 199.99m },
            new() { ID = 7, Name = "Desk Mat", Description = "Extra large felt", Price = 22.00m },
            new() { ID = 8, Name = "Laptop Stand", Description = "Adjustable height", Price = 45.00m },
            new() { ID = 9, Name = "External SSD", Description = "1TB Portable", Price = 120.00m },
            new() { ID = 10, Name = "Smart Light Bulb", Description = "WiFi Enabled RGB", Price = 15.99m }
        ];

        [HttpGet]
        public IEnumerable<Product> Get() {
            return _products;
        }

        [HttpPost]
        // when you get the product from the body of the http request, how do you make sure all parameters were sent? 
        // how do you make sure that the types are aligned properly???
        public void Post([FromBody] Product product) {
            _products.Add(product);
            _products.ForEach(p => Console.WriteLine(p.Name));
        }

        [HttpPut("{id}")]
        // when you get the product from the body of the http request, how do you make sure all parameters were sent? 
        // how do you make sure that the types are aligned properly???
        public void Put(int id, [FromBody] Product product) {
            var existingProduct = _products.FirstOrDefault(p => p.ID == id);
            if (existingProduct != null) {
                Console.WriteLine($"Before: {existingProduct.Name}");
                // if not null then update database!
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
            }
            // print it to see the changes
            Console.WriteLine($"after: {existingProduct.Name}");
        }

        [HttpDelete("{id}")]
        public void Delete(int id) {
            Console.WriteLine($"The length before removal: {_products.Count}");
            var item = _products.Find(p => p.ID == id);
            if (item != null) {
                _products.Remove(item);
            }
            Console.WriteLine($"The length after removal: {_products.Count}");
        }
    }
}