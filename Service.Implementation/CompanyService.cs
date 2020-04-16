using System;
using System.Collections.Generic;
using Service.Interface;
using Repo.Interface;
using Model;

namespace Service.Implementation
{
    public class CompanyService : GenericService<long, Company>, ICompanyService
    {
        private readonly ICompanyRepo companyRepo;
        public CompanyService(ICompanyRepo companyRepo) : base(companyRepo)
        {
            this.companyRepo = companyRepo;
        }

        public void NonGenericMethod()
        {
            companyRepo.NonGenericMethod();
        }

        public IList<Employee> GetEmployees(long companyID)
        {
            return companyRepo.GetEmployees(companyID);
        }
    }
}
