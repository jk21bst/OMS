using Microsoft.EntityFrameworkCore;
using omscase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace omscase
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext>options): base(options)
        {

        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Orderitem> Orderitems { get; set; }
    }
}
