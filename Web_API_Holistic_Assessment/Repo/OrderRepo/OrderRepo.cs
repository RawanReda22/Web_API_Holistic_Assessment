using Microsoft.EntityFrameworkCore;
using Web_API_Holistic_Assessment.DTOs.CustomerDTOs;
using Web_API_Holistic_Assessment.DTOs.OrderDTO;
using Web_API_Holistic_Assessment.DTOs.ProductDTOs;
using Web_API_Holistic_Assessment.DTOs.ShoppingCartDTO;
using Web_API_Holistic_Assessment.Models;

namespace Web_API_Holistic_Assessment.Repo.OrderRepo
{
    public class OrderRepo : IOrderRepo
    {
        private readonly AppDbContext _context;
        public OrderRepo(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public void Add(OrderForProduct orderDTO)
        {
            var customer = _context.Customers.FirstOrDefault(x=> x.Id == orderDTO.CustomerId);
            var order = new Order
            {
                TotalPrice = orderDTO.TotalPrice,
                CustomerId = orderDTO.CustomerId,
                Products = _context.Products.Select(x=> new Product
                {
                    Name = x.Name,
                    Description = x.Description,
                    StockQuantity = x.StockQuantity,
                }).ToList(),
                //Customer = customer,
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Orders.FirstOrDefault(x => x.Id == id);
            if(product != null)
            {
                _context.Orders.Remove(product);
                _context.SaveChanges();
            }

        }

        public IEnumerable<OrdersDTO> GetAll()
        {
            var order = _context.Orders.Include(x=>x.Products).Include(x=>x.Customer)
                .Select(x=> new OrdersDTO
                {
                    TotalPrice = x.TotalPrice,
                    Products = x.Products.Select(x=> new ProductOnly
                    {
                        Description = x.Description,
                        Name  = x.Name,
                        StockQuantity = x.StockQuantity
                    }).ToList(),
                    Customer = new CustomerOnly
                    {
                        Email = x.Customer.Email,
                        Name = x.Customer.Name,
                        Phone = x.Customer.Phone,
                        
                    }
                }).ToList();
            return order;
        }

        public void Update(OrderForProduct orderForProduct , int id, int productId)
        {
            var order = _context.Orders.Include(x=> x.Products).FirstOrDefault(x=>x.Id == id);
            var product= _context.Products.FirstOrDefault(x => x.Id == productId);
            order.TotalPrice = orderForProduct.TotalPrice;
            order.CustomerId = orderForProduct.CustomerId;

            order.Products = _context.Products.Where(p => orderForProduct.productId.Contains(p.Id)).ToList();


            _context.Orders.Update(order);
            _context.SaveChanges();
        }
    }
}
