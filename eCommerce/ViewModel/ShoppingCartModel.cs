using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerce.ViewModel
{
    public class ShoppingCartModel
    {

        public Guid ItemId { get; set; }

        public string ItemName { get; set; }



        public int Quantity { get; set; }   

        public decimal PricePerUnit { get; set; }   

        public decimal Total { get; set; }   




        public string ImagePath { get; set; }  






        




    }
}