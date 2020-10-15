using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.DomainModel
{
    public class Constants
    {
        public const string SELECT_PRODUCT = "select * from tblProducts where ProductName='{0}'";
        public const string SELECT_PRODUCT_BY_ID = "select * from tblProducts where Id='{0}'";
        public const string LOGIN = "select * from tblLogin where Username='{0}' and Password='{1}'";
        public const string ADD_PRODUCT = "Insert into tblProducts (Id, ProductName ,ProductDescription) Values('{0}', '{1}', '{2}');";
        public const string DELETE_PRODUCT = "delete from tblProducts  Where Id = {0};";
        public const string UPDATE_PRODUCT = "Update tblProducts SET  ProductName ='{0}', ProductDescription = {1} Where Id = {2};";
        public const string APP_SETTINGS = "AppSettings";
    }
    public class Routes
    {
        public const string DEFAULT_ROUTE = "api/[controller]";
        public const string GET_PRODUCTS_BY_NAME= "GetProductsByName";
        public const string GET_PRODUCTS_BY_ID= "GetProductsById/{id}";
        public const string ADD_PRODUCT= "AddProduct";
        public const string UPDATE_PRODUCT = "UpdateProduct";
        public const string DELETE_PRODUCT = "DeleteProduct";
        public const string LOGIN = "Login";
        
    }
}
