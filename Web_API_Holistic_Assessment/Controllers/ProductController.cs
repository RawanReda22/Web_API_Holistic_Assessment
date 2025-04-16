using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_Holistic_Assessment.DTOs.ProductDTOs;
using Web_API_Holistic_Assessment.Repo.ProductRepo;

namespace Web_API_Holistic_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _repo;
        public ProductController(IProductRepo productRepo)
        {
            _repo = productRepo;
        }

        [HttpPost]
        public IActionResult PostProduct(ProductOnly productOnly)
        {
            if (productOnly == null)
            {
                return BadRequest();
            }
            _repo.AddProduct(productOnly);
            return Ok();
        }
    }
}
