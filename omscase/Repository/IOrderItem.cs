using omscase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace omscase.Repository
{
    public interface IOrderItem 
    {
        Task<IEnumerable<Orderitem>> GetOrderItems();
        Task<Orderitem> GetOrderitemBySpecificId(int specific_id);
        Task<Orderitem> GetOrderitemByOrderId(int order_id);
        Task<Orderitem> DeleteOrderitemBySpecificId(int specific_id);
        Task<Orderitem> UpdateOrderitemBySpecificid(Orderitem orderitem);
        Task<int> AddOrderitem(Orderitem orderitem);

    }
}
