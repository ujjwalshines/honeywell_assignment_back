using Assessment.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Repository.Base
{
    public class BaseRepository
    {
        protected string _connectionString;
        public BaseRepository() => (_connectionString) = (ProjectConfig.ConnectionString);
    }
}
