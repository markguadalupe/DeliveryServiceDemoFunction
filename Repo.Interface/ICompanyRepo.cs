using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Repo.Interface
{
    public interface ICompanyRepo : IGenericRepo<long, Company>
    {
        public void NonGenericMethod();

        public IList<Employee> GetEmployees(long companyID);
    }
}
