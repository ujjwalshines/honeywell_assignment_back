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
    public class LoginController: ControllerBase
    {
        private IProductService _service;
        public LoginController(IProductService productService) => (_service) = (productService);
        [AllowAnonymous]
        [HttpPost(Routes.LOGIN)]
        public ApiResponse Login([FromBody]LoginRequest request) => _service.Login(request);

       
    }
}
