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
        public RazorPagesProductContext (
            DbContextOptions<RazorPagesProductContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
        }

    }
}
