using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using omscase.Data.Models;

namespace omscase.Repository
{
    public class OrderRepo : IOrder
    {
        private readonly AppDbContext _context;
        public OrderRepo(AppDbContext context)
        {
            this._context = context;
        }




        public async Task<int> AddOrder(Order order)
        {


            _context.Orders.Add(order);

            int res = await _context.SaveChangesAsync();
            if (res > 0)
            {
                return 1;
            }
            return 0;
        }





        public async Task<Order> DeleteOrder(int orderid)
        {

            var result = await _context.Orders.FirstOrDefaultAsync(c => c.orderid == orderid);
            if (result != null)
            {
                _context.Orders.Remove(result);

                await _context.SaveChangesAsync();
                return result;
            }
            return null;
            
        }




        public  async Task<Order> GetOrderByCustomerId(int customerid)

        {
            return await _context.Orders.Where(x => x.customerid == customerid )
                .FirstOrDefaultAsync();

        }




        public async Task<Order> GetOrderByOrderId(int orderid)
        {
            return await _context.Orders
                 .FirstOrDefaultAsync(e => e.orderid == orderid);
           
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            var ar = await _context.Orders.ToListAsync();
            return ar;
        }




        public async Task<Order> UpdateOrder(Order order)
        {
            var result = await _context.Orders.FirstOrDefaultAsync(e => e.orderid == order.orderid);
            if (result != null)
            {
                result.deliveryaddress = order.deliveryaddress;
                result.totalamount = order.totalamount;
                result.orderstatus = order.orderstatus;
               

                _context.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
            
        }
    }

}