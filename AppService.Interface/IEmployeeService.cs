using System.Collections.Generic;
using System;
using Model;

namespace Service.Interface
{
    public interface IEmployeeService : IGenericService<long, Employee>
    {
    }
}
