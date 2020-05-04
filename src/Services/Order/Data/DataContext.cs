using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Order.Models;

namespace Order.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {              
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Orders>(order =>
            {
                order.HasMany(p => p.OrderItems)
                    .WithOne(p => p.Order)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}
