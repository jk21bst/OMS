using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using omscase.Data.Models;

namespace omscase.Repository
{
    public class ProductRepo : IProduct
    {
        private readonly AppDbContext _context;
        public ProductRepo(AppDbContext context)
        {
            this._context = context;
        }



        public async Task<int> AddNewProduct(Product product)
        {
            _context.Products.Add(product);
            int res = await _context.SaveChangesAsync();
            if(res>0)
            {
                return 1;
            }
            return 0;
        }




        //public Task<Product> DeleteProduct(int productid)
        //{
        //    throw new NotImplementedException();
        //}
        public async Task<Product> DeleteProduct(int id)
        {
            var result = await _context.Products.FirstOrDefaultAsync(c => c.productid == id);
            if (result != null)
            {
                _context.Products.Remove(result);

                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        



      



       
       
        public async Task<Product> GetProductByProductId(int productid)
        {

            return await _context.Products
                   .FirstOrDefaultAsync(e => e.productid == productid);

        }

        public async Task<Product> GetProductByProductTitle(string title)
        {
            return await _context.Products
                .FirstOrDefaultAsync(e => e.title == title);

        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var ar = await _context.Products.ToListAsync();
            return ar;
        }




        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await _context.Products.FirstOrDefaultAsync(e => e.productid == product.productid);
                if (result != null) 
            {
                result.title = product.title;
                result.price = product.price;
                result.product_description = product.product_description;
                result.image = product.image;

                _context.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;

        }
           
        }
    }

