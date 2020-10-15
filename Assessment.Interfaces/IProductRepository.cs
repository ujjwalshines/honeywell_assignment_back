using Assessment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Interfaces
{
    public interface IProductRepository
    {
        bool AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(string productId);
        IEnumerable<Product> GetProductsByName(string productName);
        IEnumerable<Product> GetProductsById(string productId)
    }
}
