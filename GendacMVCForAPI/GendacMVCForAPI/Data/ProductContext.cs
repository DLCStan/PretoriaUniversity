using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GendacMVCForAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace GendacMVCForAPI.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
        }
    }
}
