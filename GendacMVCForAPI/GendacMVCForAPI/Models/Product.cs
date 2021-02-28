using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GendacMVCForAPI.Models
{
    public class Product
    {
        [Required]
        public string Category { get; set; }
        public int Id { get; set; }


        [RegularExpression(@"^[A-Za-z0-9 ]*$")]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }

    public enum Categories
    {
        CategoryA, CategoryB, CategoryC
    }
}
