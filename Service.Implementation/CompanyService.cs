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

        public override Company Edit(long id, Company model)
        {
            var entity = companyRepo.Get(id);

            if (entity != null)
            {
                entity.Name = model.Name;
                return companyRepo.Edit(entity);
            }

            return model;
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
