using Assessment.DomainModel;
using Assessment.ViewModels;
using Honeywell_Backend_Assessment.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Honeywell_Backend_Assessment.Controllers
{
    [Route(Routes.DEFAULT_ROUTE)]
    public class ProductController: ControllerBase
    {
        private IProductService _service;
        public ProductController(IProductService productService) => (_service) = (productService);
        [Authorize]
        [HttpPost(Routes.GET_PRODUCTS_BY_NAME)]
        public ApiResponse GetProductsByName([FromBody]ProductRequest request) => _service.GetProductsByName(request);
        [Authorize]
        [HttpGet(Routes.GET_PRODUCTS_BY_ID)]
        public ApiResponse GetProductsById([FromRoute]string id) => _service.GetProductsById(id);
        [Authorize]
        [HttpPost(Routes.ADD_PRODUCT)]
        public ApiResponse AddProduct([FromBody]ProductRequest request) => _service.AddProduct(request);
        [Authorize]
        [HttpPut(Routes.UPDATE_PRODUCT)]
        public ApiResponse UpdateProduct([FromBody]ProductRequest request) => _service.UpdateProduct(request);
        [Authorize]
        [HttpDelete(Routes.DELETE_PRODUCT)]
        public ApiResponse DeleteProduct([FromBody]ProductRequest request) => _service.DeleteProduct(request);
    }
}
