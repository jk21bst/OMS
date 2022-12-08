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
    public class OrderitemsController : ControllerBase
    {
        private readonly IOrderItem _orderitem;
        public OrderitemsController(IOrderItem orderitem)
        {
            this._orderitem = orderitem;
        }
        

        [HttpGet("get-order-item-by-specific=id")]
        public async Task<IActionResult> GetOrderitemBySpecificId(int specific_id)
        {
            var ar = await _orderitem.GetOrderitemBySpecificId(specific_id);
                if(ar != null)
            {
                return Ok(ar);
            }
            return NotFound("No order items with that specific id ");
        }



        [HttpGet("get-all-order-items")]
        public async Task<ActionResult<IEnumerable<Orderitem>>> GetOrderItems()
        {
            try
            {
                return Ok(await _orderitem.GetOrderItems());

            }
            catch(Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet("get-order-items-by-order-id")]
        public async Task<IActionResult> GetOrderitemByOrderId(int order_id)
        {
            var ar = await _orderitem.GetOrderitemByOrderId(order_id);
            if(ar != null)
            {
                return Ok(ar);
            }
            return NotFound("No order items by such order id ");
        }


        [HttpDelete("delete-orderitem-by-specificid")]
        public async Task<IActionResult> DeleteOrderitemBySpecificId(int specific_id)
        {
            Orderitem ar = await _orderitem.DeleteOrderitemBySpecificId(specific_id);
            if(ar != null)
            {
                return Ok(ar);
            }
            return BadRequest("Cannot delete the order item by specific id");
        }


        [HttpPut("update-orderitems-by-specific-id ")]
        public async Task<IActionResult> UpdateOrderitemBySpecificid(Orderitem orderitem)
        {
            var ar = await _orderitem.UpdateOrderitemBySpecificid(orderitem);
            if(ar != null)
            {
                return Ok(ar);
            }
            return BadRequest("unable to delete the orderitem");
        }


        [HttpPost("add-orderitems")]
        public async Task<IActionResult> AddOrderitem(Orderitem orderitem)
        {
            var ar = await _orderitem.AddOrderitem(orderitem);
            if (ar > 0)
            {
                return Ok(ar);
            }
            return BadRequest("Cannot add order item");
        }
    }
}