using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace eCommerce.Models
{
    public class ECommerce:DbContext
    {
        public ECommerce() : base("DefaultConnection")
        {

        }
        public DbSet<Product> products { get; set; }
    }
}