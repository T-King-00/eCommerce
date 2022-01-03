using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.ViewModel
{
    public class ItemViewModel
    {
            public Guid ItemId { get; set; }
            public int CategoryID { get; set; }
            public string ItemCode { get; set; }
            public string ItemName { get; set; }
            public string Description { get; set; }
            public decimal ItemPrice { get; set; }
            public String ImagePath { get; set; }

            public IEnumerable<SelectListItem> CategorySelectListItem { get; set; }
        
    }
}