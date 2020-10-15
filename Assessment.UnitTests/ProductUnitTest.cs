using Assessment.GlueService;
using Assessment.ViewModels;
using Honeywell_Backend_Assessment.Controllers;
using Honeywell_Backend_Assessment.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assessment.UnitTests
{
    [TestClass]  
    public class ProductUnitTest  
    {  
        [TestMethod]
    public void GetProductById()
    {
        // Set up Prerequisites   
        var controller = new ProductController(new ProductService(new InstanceGenerator(),null));
        // Act on Test  
        var response = controller.GetProductsById("21828631-e75f-488e-a2f9-96c1735be04f");
        var contentResult = response.Status;
        // Assert the result  
        Assert.IsNotNull(contentResult);
        Assert.IsNotNull(response.Response);
        Assert.AreEqual("success", contentResult);
    }
        [TestMethod]
        public void GetProductByName()
        {
            // Set up Prerequisites   
            var controller = new ProductController(new ProductService(new InstanceGenerator(), null));
            // Act on Test  
            var response = controller.GetProductsByName(new ProductRequest { ProductName = "Mobile" });
            var contentResult = response.Status;
            // Assert the result  
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(response.Response);
            Assert.AreEqual("success", contentResult);
        }
        [TestMethod]
        public void DeleteProduct()
        {
            // Set up Prerequisites   
            var controller = new ProductController(new ProductService(new InstanceGenerator(), null));
            // Act on Test  
            var response = controller.DeleteProduct(new ProductRequest { Id = "21828631-e75f-488e-a2f9-96c1735be04f" });
            var contentResult = response.Status;
            // Assert the result  
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(response.Response);
            Assert.AreEqual("success", contentResult);
        }
    }  
}
