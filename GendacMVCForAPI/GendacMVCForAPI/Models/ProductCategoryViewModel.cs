using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GendacMVCForAPI.Models
{
    public class ProductCategoryViewModel
    {
        public List<Product> Products { get; set; }
        public SelectList CategoryList { get; set; }
        public string ProductCategory { get; set; }
        public string SearchString { get; set; }
    }
}
