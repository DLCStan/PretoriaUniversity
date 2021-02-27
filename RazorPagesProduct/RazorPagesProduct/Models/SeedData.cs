using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorPagesProduct.Data;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesProduct.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesProductContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesProductContext>>()))
            {
                // Look for any movies.
                if (context.Product.Any())
                {
                    return; // DB has been seeded
                }
                context.Product.AddRange(
                    new Product 
                    { 
                        Category = "CategoryA", 
                        Id = 1, 
                        Name = "Stove", 
                        Price = 7.99M 
                    },
                    new Product 
                    { 
                        Category = "CategoryB", 
                        Id = 2, 
                        Name = "Fridge", 
                        Price = 17.99M 
                    },
                    new Product 
                    { 
                        Category = "CategoryC", 
                        Id = 3, 
                        Name = "TV", 
                        Price = 23.99M 
                    },
                    new Product 
                    { 
                        Category = "CategoryA", 
                        Id = 4, 
                        Name = "Sofa", 
                        Price = 27.49M 
                    }
                );
                context.SaveChanges();
            }
        }
    }
}