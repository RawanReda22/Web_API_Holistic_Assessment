using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_Holistic_Assessment.DTOs.OrderDTO;
using Web_API_Holistic_Assessment.Repo.OrderRepo;

namespace Web_API_Holistic_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepo _repo;
        public OrderController(IOrderRepo order)
        {
            _repo = order;   
        }
        [HttpPost]
        public IActionResult PostOrder(OrderForProduct ordersDTO)
        {
            if (ordersDTO == null)
            {
                return BadRequest();
            }
            _repo.Add(ordersDTO);
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult PutOrder(OrderForProduct orderForProduct, int id, int productId)
        {
            _repo.Update(orderForProduct, id , productId);
            return Accepted();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            _repo.Delete(id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
          var order =  _repo.GetAll();
            return Ok(order);
        }
        
    }
}
