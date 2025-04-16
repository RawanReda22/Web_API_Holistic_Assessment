using Web_API_Holistic_Assessment.DTOs.ProductDTOs;
using Web_API_Holistic_Assessment.Models;

namespace Web_API_Holistic_Assessment.Repo.ProductRepo
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _context;
        public ProductRepo(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public void AddProduct(ProductOnly productOnly)
        {
            var product = new Product
            {
                Name = productOnly.Name,
                StockQuantity = productOnly.StockQuantity,
                Description = productOnly.Description,
            };
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}
