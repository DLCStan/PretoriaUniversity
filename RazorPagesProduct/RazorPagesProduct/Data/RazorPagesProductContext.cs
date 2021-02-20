using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesProduct.Models;

namespace RazorPagesProduct.Data
{
    public class RazorPagesProductContext : DbContext
    {
        public RazorPagesProductContext (DbContextOptions<RazorPagesProductContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesProduct.Models.Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Category = "CategoryA", Id = 1, Name = "Stove" }, //Price = 7.99M
                new Product { Category = "CategoryB", Id = 2, Name = "Fridge" }, //Price = 17.99M
                new Product { Category = "CategoryC", Id = 3, Name = "TV" }, //Price = 23.99M
                new Product { Category = "CategoryA", Id = 4, Name = "Sofa" } //Price = 27.49M

                );
                   
        }


    }
}
