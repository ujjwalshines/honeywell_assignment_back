using Assessment.GlueService;
using Assessment.Models;
using Assessment.ViewModels;
using Honeywell_Backend_Assessment.AuthenticationModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Honeywell_Backend_Assessment.Services
{
    public class ProductService:IProductService
    {
        private IInstanceGenerator _generator;
        private AppSettings _appSettings;
        public ProductService(IInstanceGenerator instanceGenerator, IOptions<AppSettings> appSettings)
        {
            _generator = instanceGenerator;
            _appSettings = appSettings.Value;
        }

        public ApiResponse GetProductsByName(ProductRequest request)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.Response = _generator.Product.GetProductsByName(request.ProductName);
                response.Status = "success";
                response.Message = "Products retrieved successfully";
            }
            catch (Exception ex)
            {
                ApiError error = new ApiError();
                error.ErrorCode = "Product Error";
                error.ErrorDescription = ex.Message;
                response.Status = "error";
                response.Error = error;
            }
            return response;
        }
        public ApiResponse GetProductsById(string id)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.Response = _generator.Product.GetProductsById(id);
                response.Status = "success";
                response.Message = "Products retrieved successfully";
            }
            catch (Exception ex)
            {
                ApiError error = new ApiError();
                error.ErrorCode = "Product Error";
                error.ErrorDescription = ex.Message;
                response.Status = "error";
                response.Error = error;
            }
            return response;
        }
        public ApiResponse AddProduct(ProductRequest request)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.Response = _generator.Product.AddProduct(new Product {ProductName=request.ProductName,ProductDescription=request.ProductDescription });
                response.Status = "success";
                response.Message = "Products added successfully";
            }
            catch (Exception ex)
            {
                ApiError error = new ApiError();
                error.ErrorCode = "Product Error";
                error.ErrorDescription = ex.Message;
                response.Status = "error";
                response.Error = error;
            }
            return response;
        }
        public ApiResponse Login(LoginRequest request)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                bool isAuthenticUser = _generator.Login.Authenticate(new UserModel { Username = request.Username, Password = request.Password });
                if (isAuthenticUser)
                {
                    response.Response = CreateToken(request.Username, "user");
                }
                response.Status = "success";
                response.Message = "Login success";
            }
            catch (Exception ex)
            {
                ApiError error = new ApiError();
                error.ErrorCode = "Product Error";
                error.ErrorDescription = ex.Message;
                response.Status = "error";
                response.Error = error;
            }
            return response;
        }
        public ApiResponse UpdateProduct(ProductRequest request)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.Response = _generator.Product.UpdateProduct(new Product { Id=request.Id, ProductName = request.ProductName, ProductDescription = request.ProductDescription });
                response.Status = "success";
                response.Message = "Products updated successfully";
            }
            catch (Exception ex)
            {
                ApiError error = new ApiError();
                error.ErrorCode = "Product Error";
                error.ErrorDescription = ex.Message;
                response.Status = "error";
                response.Error = error;
            }
            return response;
        }
        public ApiResponse DeleteProduct(ProductRequest request)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.Response = _generator.Product.DeleteProduct(request.Id);
                response.Status = "success";
                response.Message = "Products deleted successfully";
            }
            catch (Exception ex)
            {
                ApiError error = new ApiError();
                error.ErrorCode = "Product Error";
                error.ErrorDescription = ex.Message;
                response.Status = "error";
                response.Error = error;
            }
            return response;
        }

        private string CreateToken(string userName, string userRole)
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = CreateClaim(userName, userRole),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private ClaimsIdentity CreateClaim(string userName, string userRole) => new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, userRole)
                    });
    }
}
