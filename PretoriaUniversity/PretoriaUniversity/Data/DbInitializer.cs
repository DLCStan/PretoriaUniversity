using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PretoriaUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace PretoriaUniversity.Data
{
    public static class DbInitializer
    {
        
        public static void Initialize(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Products>().HasData(
                new Products { Id = 1, Category = "CategoryA", Name = "Stove", Price = 10.00M },
                new Products { Id = 2, Category = "CategoryB", Name = "Fridge", Price = 19.99M },
                new Products { Id = 3, Category = "CategoryA", Name = "Stove", Price = 29.99M }
                );
        }
    }
}
