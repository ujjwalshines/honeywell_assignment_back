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
    public class LoginRepository:BaseRepository,ILoginRepository
    {
        public LoginRepository():base()
        {

        }
        public bool Authenticate(UserModel userModel)
        {
            


            string sqlQuery = string.Format(Constants.LOGIN, userModel.Username,userModel.Password);
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            try
            {
                SqlDataReader dataReader = command.ExecuteReader();
                return dataReader.HasRows;
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
