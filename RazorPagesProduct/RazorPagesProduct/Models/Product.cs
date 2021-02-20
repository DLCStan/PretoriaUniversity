using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesProduct.Models
{
    public class Product
    {
        public string Category { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        //public decimal Price { get; set; }
    }
}

