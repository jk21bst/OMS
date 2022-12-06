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
    public class OrderController : ControllerBase
    {
        private readonly IOrder _order;
        public OrderController(IOrder order)
        {
            this._order = order;
        }


        [HttpGet("all-order")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
            try
            {
                return Ok(await _order.GetOrders());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        [HttpGet("get-order-by-orderid")]
        public async Task<IActionResult> GetOrderByOrderId(int orderid)
        {
            var ar = await _order.GetOrderByOrderId(orderid);
            if (ar != null)
            {
                return Ok(ar);

            }
            return NotFound();
        }



        [HttpPost("add-order")]
        public async Task<IActionResult> AddOrder(Order order)
        {
            int ar = await _order.AddOrder(order);
            if (ar > 0)
            {
                return Ok(ar);
            }
            return NotFound();
        }


        [HttpGet("getorder-bycustomerid")]
        public async Task<IActionResult> GetOrderByCustomerId(string custid)
        {
            var ar = await _order.GetOrderByCustomerId(custid);
            if (ar != null)
            {
                return Ok(ar);
            }

            return NotFound();
        }

        [HttpDelete("delete-order")]
        public async Task<IActionResult> DeleteOrder(int orderid)
        {
            Order ar = await _order.DeleteOrder(orderid);
            if ((ar is null)) 
            {
                return BadRequest("unable to delete ");
            }
            return Ok(ar);
            
        }


        [HttpPut("update")]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            Order ar = await _order.UpdateOrder(order);
            if ((ar is null))
            {
                return BadRequest("Unable to update");
            }
            return Ok(ar);
        }
            



    }
}