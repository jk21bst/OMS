using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using omscase.Data.Models;

namespace omscase.Repository
{
    public class CustomerRepo : ICustomer
    {
        private readonly AppDbContext _context;

        public CustomerRepo(AppDbContext context)
        {
            this._context = context;

        }

        //public async Task<Customer> AddCustomer(Customer customer)
        //{
        //    var result = await _context.Customers.AddAsync(customer);
        //    await _context.SaveChangesAsync();
        //    return result.Entity;
        //}

        public async Task<int> AddNewCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
          
            int res = await _context.SaveChangesAsync();
                if(res > 0)
            {
                return 1;
            }
            return 0;
        }

        //public Task<Customer> AddNewCustomer(Customer customer)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Customer> DeleteCustomer(int id)
        {
            var result = await _context.Customer.FirstOrDefaultAsync(c => c.custid == id);
            if (result != null)
            {
                _context.Customer.Remove(result);

                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        //public Task<Customer> DeleteCustomer(int custid)
        //{
        //    throw new NotImplementedException();
        //}
        public async Task<Customer> GetCustomerByUsername(string username)
        {
            return await _context.Customer
                   .FirstOrDefaultAsync(e => e.username == username);
        }
        //public Task<Customer> GetCustomerByUsername(string username)
        //{
        //    throw new NotImplementedException();
        //}
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var ar = await _context.Customer.ToListAsync();
            return ar;
        }

        public async Task<Customer> Login(string username, string password)
        {
            var result = await _context.Customer.FirstOrDefaultAsync(e => (e.username).Equals(username) && (e.password).Equals( password));
            if(result != null)
            {
                return result;

            }
            return result;
           

        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            var result = await _context.Customer.FirstOrDefaultAsync(e => e.custid == customer.custid);
            if (result != null)
            {
                result.custname = customer.custname;
                result.password = customer.password;
                result.username = customer.username;
                result.gender = customer.gender;
                result.mobileno = customer.mobileno;
                result.custaddress = customer.custaddress;

                _context.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;

            //    public Task<Customer> UpdateCustomer(Customer customer)
            //{
            //    throw new NotImplementedException();
            //}
        }
    }
}
