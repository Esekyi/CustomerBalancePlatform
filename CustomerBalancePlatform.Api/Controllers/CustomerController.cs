using Microsoft.AspNetCore.Mvc;
using CustomerBalancePlatform.Api.Models;
using CustomerBalancePlatform.Api.Data;

namespace CustomerBalancePlatform.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerContext _context;

        public CustomerController(CustomerContext context)
        {
            _context = context;
        }

        
    }
}