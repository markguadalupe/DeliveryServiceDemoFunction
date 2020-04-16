using System;
using System.Collections.Generic;
using Service.Interface;
using Repo.Interface;
using Model;

namespace Service.Implementation
{
    public class EmployeeService : GenericService<long, Employee>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepo employeeRepo) : base(employeeRepo)
        {
        }

    }
}
