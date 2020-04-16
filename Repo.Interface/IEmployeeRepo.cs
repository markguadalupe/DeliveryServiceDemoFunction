using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Repo.Interface
{
    public interface IEmployeeRepo : IGenericRepo<long, Employee>
    {
    }
}
