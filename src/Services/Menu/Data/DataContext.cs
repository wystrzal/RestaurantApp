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
        public DbSet<MenuIngredient> MenuIngredients { get; set; }
        public DbSet<MenuIngredientsItems> MenuIngredientsItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuIngredientsItems>(m =>
            {
                m.HasKey(up => new { up.MenuIngredientId, up.MenuItemId });

                m.HasOne(x => x.MenuItem)
                .WithMany(x => x.MenuIngredientsItems)
                .HasForeignKey(x => x.MenuItemId);

                m.HasOne(x => x.MenuIngredient)
                .WithMany(x => x.MenuIngredientsItems)
                .HasForeignKey(x => x.MenuIngredientId);
            });
        }

    }
}
