using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace eCommerce.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

    }
}