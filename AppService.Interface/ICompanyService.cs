using System.Collections.Generic;
using System;
using Model;

namespace Service.Interface
{
    public interface ICompanyService : IGenericService<long, Company>
    {
        public void NonGenericMethod();
        public IList<Employee> GetEmployees(long companyID);
    }
}
