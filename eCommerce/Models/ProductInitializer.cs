using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace eCommerce.Models
{
    public class ProductInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ECommerce>
    {
            protected override void Seed(ECommerce context)
        {
            var products = new List<Product>
            {
            new Product{ProductId=1050,Name="Galaxy A7",},
            new Product{ProductId=4022,Name="Dell G3"},
            new Product{ProductId=4041,Name="Logitech"},
            new Product{ProductId=1045,Name="PS4"},
            new Product{ProductId=3141,Name="XBOX ONE"},
            };
            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();
        }
    } 
}
