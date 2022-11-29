using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using omscase.Data.Models;
using omscase.Repository;

namespace omscase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerRepo _customerRepo;

        public CustomersController(CustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;

        }
        //GET api/customers`````````````````````````````````````````````````````````````````````````````````````````````````````
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            try
            {
                return Ok(await _customerRepo.GetCustomers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrievind data from database");
            }

        }
    }
}