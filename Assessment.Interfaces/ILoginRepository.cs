using Assessment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Interfaces
{
    public interface ILoginRepository
    {
        bool Authenticate(UserModel userModel);
    }
}
