using Microsoft.EntityFrameworkCore;
using Web_API_Holistic_Assessment.DTOs.CustomerDTOs;
using Web_API_Holistic_Assessment.DTOs.OrderDTO;
using Web_API_Holistic_Assessment.DTOs.ProductDTOs;
using Web_API_Holistic_Assessment.DTOs.ShoppingCartDTO;
using Web_API_Holistic_Assessment.Models;

namespace Web_API_Holistic_Assessment.Repo.CustomerRepo
{
    public class CustomerRepo : ICutomerRepo
    {
        private readonly AppDbContext _context;
        public CustomerRepo(AppDbContext contect)
        {
            _context = contect;
        }
        public void AddCustomer(PostCustomer customerPost)
        {
            var customer = new Customer
            {
                Email = customerPost.Email,
                Name = customerPost.Name,
                Phone = customerPost.Phone,
                ShoppingCart = new ShoppingCart
                {
                    CustomerId = customerPost.ShoppingCart.CustomerId,
                    NumberOfItems = customerPost.ShoppingCart.NumberOfItems
                },
                Orders = customerPost.Orders.Select(x => new Order
                {
                    TotalPrice = x.TotalPrice,
                    Products = x.Products.Select(o => new Product
                    {
                        Name = o.Name,
                        Description = o.Description,
                        StockQuantity = o.StockQuantity,
                    }).ToList(),
                } ).ToList(),
                
            };
            _context.Customers.Add( customer );
            _context.SaveChanges();
        }

        public PostCustomer GetCustomerById(int id)
        {
            var customer = _context.Customers.Include(x=>x.ShoppingCart)
                .Include(x=>x.Orders).ThenInclude(x=>x.Products).FirstOrDefault(x=> x.Id == id);
            return new PostCustomer
            {
                Name = customer.Name,
                Email = customer.Email, 
                Phone = customer.Phone,
                ShoppingCart = new ShoppingCartOnly{
                    NumberOfItems = customer.ShoppingCart.NumberOfItems,
                },
                Orders = customer.Orders.Select(x => new OrderForProduct
                {
                     TotalPrice = x.TotalPrice,
                     Products = x.Products.Select(x=> new ProductOnly
                     {
                         Name=x.Name,
                         Description=x.Description,
                         StockQuantity=x.StockQuantity,
                     }).ToList(),
                }).ToList(),
            };
        }
    }
}
