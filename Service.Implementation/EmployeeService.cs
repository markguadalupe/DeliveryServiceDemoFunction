using System;
using System.Collections.Generic;
using Service.Interface;
using Repo.Interface;
using Model;

namespace Service.Implementation
{
    public class EmployeeService : GenericService<long, Employee>, IEmployeeService
    {
        private readonly IEmployeeRepo employeeRepo;
        public EmployeeService(IEmployeeRepo employeeRepo) : base(employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }

        public override Employee Edit(long id, Employee model)
        {
            var entity = employeeRepo.Get(id);

            if (entity != null)
            {
                entity.Name = model.Name;
                return employeeRepo.Edit(entity);
            }

            return model;
        }

    }
}
