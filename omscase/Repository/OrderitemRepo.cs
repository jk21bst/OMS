using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using omscase.Data.Models;

namespace omscase.Repository
{
    public class OrderitemRepo : IOrderItem
    {
        private readonly AppDbContext _context;
        public OrderitemRepo(AppDbContext context)
        {
            this._context = context; 
        }


        public async Task<int> AddOrderitem(Orderitem orderitem)
        {
            _context.Orderitems.Add(orderitem);
            int res = await _context.SaveChangesAsync();
            if(res>0)
            {
                return (res);

            }
            return 0;
        }

        public async Task<Orderitem> DeleteOrderitemBySpecificId(int specific_id)
        {
            var res = await _context.Orderitems.FirstOrDefaultAsync(c => c.specific_id == specific_id);
            if (res != null) 
            {
                _context.Orderitems.Remove(res);
                await _context.SaveChangesAsync();
                    return res;
            }
            return null;
           
        }

        public async Task<Orderitem> GetOrderitemByOrderId(int order_id)
        {
            return await _context.Orderitems.Where(x=> x.order_id == order_id)
                .FirstOrDefaultAsync();
        }

        public async Task<Orderitem> GetOrderitemBySpecificId(int specific_id)
        {
            return await _context.Orderitems.FirstOrDefaultAsync(e => e.specific_id == specific_id);
        }

        public async Task<IEnumerable<Orderitem>> GetOrderItems()
        {
          var ar = await _context.Orderitems.ToListAsync();
            return ar;
        }

        public async Task<Orderitem> UpdateOrderitemBySpecificid(Orderitem orderitem)
        {
            var ar = await _context.Orderitems.FirstOrDefaultAsync(e => e.order_id == orderitem.order_id);
            if(ar != null)
            {
                ar.order_status = orderitem.order_status;
                ar.price = orderitem.price;
                ar.quantity = orderitem.quantity;

                _context.Entry(ar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return ar;
            }
            return ar;
        }
    }
}
