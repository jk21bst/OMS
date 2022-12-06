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

        public Task<Orderitem> GetOrderitemByOrderId(int orderid)
        {
            throw new NotImplementedException();
        }

        public Task<Orderitem> GetOrderitemBySpecificId(int specific_id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Orderitem>> GetOrderItems()
        {
            throw new NotImplementedException();
        }

        public Task<Orderitem> UpdateOrderitemBySpecificid(Orderitem orderitem)
        {
            throw new NotImplementedException();
        }
    }
}
