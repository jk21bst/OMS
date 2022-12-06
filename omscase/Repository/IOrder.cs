using omscase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace omscase.Repository
{
    public interface IOrder
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrderByCustomerId(int customerid);
        Task<Order> GetOrderByOrderId(int orderid);
        Task<int> AddOrder(Order order);
        Task<Order> DeleteOrder(int orderid);
        Task<Order> UpdateOrder(Order order);

    }
}
