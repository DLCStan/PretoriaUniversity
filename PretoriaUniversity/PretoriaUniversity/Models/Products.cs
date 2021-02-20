﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PretoriaUniversity.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
