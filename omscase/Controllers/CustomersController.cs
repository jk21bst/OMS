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
        private readonly ICustomer cust;
        


        public CustomersController(ICustomer _cust)
        {
            this.cust = _cust;
            

        }

        //[HttpDelete]
        //public async Task<ActionResult<IEnumerable<Customer>>> DeleteCustomer()
        //{
            

        //}
        //GET api/customers`````````````````````````````````````````````````````````````````````````````````````````````````````
        [HttpGet("all-customers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            try
            {
                return Ok(await cust.GetCustomers());
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpGet("get-customer-by-username")]
        public async Task<IActionResult> GetCustomerByUsername(string username)
        {
            var ar = await cust.GetCustomerByUsername(username);
            if(ar != null)
            {
                return Ok(ar);

            }
            return NotFound();
        }


        [HttpPost("add-customer")]
        public async Task<IActionResult> AddNewCustomer(Customer customer)
        {
            int ar = await cust.AddNewCustomer (customer);
            if(ar>0)
            {
                return Ok(ar);
            }
            return NotFound();
        }

        [HttpDelete("delete-customer-by-id")]
        public async Task<IActionResult> DeleteCustomer(int custid)
        {
            Customer ar = await cust.DeleteCustomer(custid);
            if((ar is null) )
            {
                return BadRequest("Unable to Find");
                
            }

            return Ok(ar);

        }
        [HttpPut("update-customer")]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            Customer ar = await cust.UpdateCustomer(customer);
            if ((ar is null))
            {
                return BadRequest("Unable to Update");
            }
            return Ok(ar);
        }

        [HttpGet("login-validation")]
        public async Task<IActionResult> Login(string username , string password)
        {
            Customer ar = await cust.Login(username, password);
            if((ar is null))
            {
                return BadRequest("Unable to validate");
            }
            return Ok(ar);
        }

    }
}