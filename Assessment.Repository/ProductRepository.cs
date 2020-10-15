using Assessment.DomainModel;
using Assessment.Interfaces;
using Assessment.Models;
using Assessment.Repository.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Assessment.Repository
{
    public class ProductRepository :BaseRepository, IProductRepository
    {
      
        public ProductRepository():base()
        {

        }
        public bool AddProduct(Product product)
        {
            string createQuery = String.Format(Constants.ADD_PRODUCT, Guid.NewGuid().ToString(),product.ProductName,product.ProductDescription);
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(createQuery, connection);
            try
            {
                var commandResult = command.ExecuteScalar();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }
            
            
        }

        public bool DeleteProduct(string productId)
        {
            string deleteQuery = String.Format(Constants.DELETE_PRODUCT,  productId);
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(deleteQuery, connection);
            try
            {
                int rowsDeletedCount = command.ExecuteNonQuery();
                return rowsDeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

        }


        public IEnumerable<Product> GetProductsByName(string productName)
        {
            List<Product> products = new List<Product>();

           
            string sqlQuery = string.Format(Constants.SELECT_PRODUCT, productName);
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            try
            {
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Product product = new Product
                        {
                            Id = Convert.ToString(dataReader["Id"]),
                            ProductName = Convert.ToString(dataReader["ProductName"]),
                            ProductDescription = Convert.ToString(dataReader["ProductDescription"])
                        };
                        products.Add(product);
                    }
                }

                return products;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

        }

        public IEnumerable<Product> GetProductsById(string productId)
        {
            List<Product> products = new List<Product>();


            string sqlQuery = string.Format(Constants.SELECT_PRODUCT_BY_ID, productId);
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            try
            {
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Product product = new Product
                        {
                            Id = Convert.ToString(dataReader["Id"]),
                            ProductName = Convert.ToString(dataReader["ProductName"]),
                            ProductDescription = Convert.ToString(dataReader["ProductDescription"])
                        };
                        products.Add(product);
                    }
                }

                return products;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

        }

        public bool UpdateProduct(Product product)
        {
            string updateQuery = String.Format(Constants.UPDATE_PRODUCT,  product.ProductName, product.ProductDescription,product.Id);
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(updateQuery, connection);
            try
            {
                var commandResult = command.ExecuteScalar();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }
           
        }
    }
}
