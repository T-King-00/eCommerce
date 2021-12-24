using System.Collections.Generic;
using eCommerce.Entities;

namespace eCommerce.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}