using omscase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace omscase.Repository
{
   public interface ICustomer
    {
        Task<IEnumerable<Customer>> GetCustomers();
      
        //Task<Customer> Login(string username, string password);
        Task<Customer> AddNewCustomer(Customer customer);
        Task<Customer> GetCustomerByUsername(string username);
        Task<Customer> UpdateCustomer(Customer customer);
        Task<Customer> DeleteCustomer(int custid);
        
  
    }
}
