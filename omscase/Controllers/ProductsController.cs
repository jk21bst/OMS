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
    public class ProductsController : ControllerBase
    {
        private readonly IProduct prod;

        public ProductsController(IProduct _prod)
        {
            this.prod = _prod;
        }





        [HttpPost("add-product")]
        public async Task<IActionResult> AddNewProduct(Product product)
        {
            int ar = await prod.AddNewProduct(product);
            if (ar > 0)
            {
                return Ok(ar);
            }
            return NotFound();
        }



        //GET all Products 
        [HttpGet("get-all-product")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            try
            {
                return Ok(await prod.GetProducts());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }




        [HttpPut("update-product")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            Product ar = await prod.UpdateProduct(product);
            if ((ar is null))
            {
                return BadRequest("Unable to Update");
            }
            return Ok(ar);
        }


        [HttpDelete("delete-product")]
       
        public async Task<IActionResult> DeleteProduct(int productid)
        {
            Product ar = await prod.DeleteProduct(productid);
            if ((ar is null))
            {
                return BadRequest("Unable to Find");

            }

            return Ok(ar);

        }


        [HttpGet("get-product-by-productid")]
        public async Task<IActionResult> GetProductByProductId(int productid)
        {
            var ar = await prod.GetProductByProductId(productid);
            if (ar != null)
            {
                return Ok(ar);

            }
            return NotFound();
        }




        [HttpGet("get-product-by-producttitle")]
        public async Task<IActionResult> GetProductByProductTitle(string title)
        {
            var ar = await prod.GetProductByProductTitle(title);
            if (ar != null)
            {
                return Ok(ar);

            }
            return NotFound();
        }






    }
}




