using Menu.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuType> MenuTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
