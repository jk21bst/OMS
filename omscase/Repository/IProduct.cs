using omscase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace omscase.Repository
{
   public interface IProduct
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductByProductId(int productid);
        Task<Product> GetProductByProductTitle(string title);
        Task<int> AddNewProduct(Product product);
        Task<Product> DeleteProduct(int productid);
        Task<Product> UpdateProduct(Product product);

       

    }
}
