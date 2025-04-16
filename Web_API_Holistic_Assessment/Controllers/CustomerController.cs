using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_Holistic_Assessment.DTOs.CustomerDTOs;
using Web_API_Holistic_Assessment.Repo.CustomerRepo;

namespace Web_API_Holistic_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICutomerRepo _repo;

        public CustomerController(ICutomerRepo cutomerRepo)
        {
            _repo = cutomerRepo;
        }
        [HttpPost]
        public ActionResult Post(PostCustomer dto) 
        {
            if(dto == null)
            {
                return BadRequest();
            }
            _repo.AddCustomer(dto);
            return Created();
            
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var customer = _repo.GetCustomerById(id);
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
    }
}
