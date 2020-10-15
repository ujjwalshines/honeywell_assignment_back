using Assessment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeywell_Backend_Assessment.Services
{
    public interface IProductService
    {
        ApiResponse GetProductsByName(ProductRequest request);
        ApiResponse AddProduct(ProductRequest request);
        ApiResponse UpdateProduct(ProductRequest request);
        ApiResponse DeleteProduct(ProductRequest request);
        ApiResponse Login(LoginRequest request);
        ApiResponse GetProductsById(string id);
    }
}
