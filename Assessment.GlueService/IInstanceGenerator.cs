using Assessment.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.GlueService
{
    public interface IInstanceGenerator
    {
        IProductRepository Product { get; set; }
        ILoginRepository Login { get; set; }
    }
}
