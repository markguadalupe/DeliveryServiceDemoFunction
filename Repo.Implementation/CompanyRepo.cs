using Dapper;
using Model;
using Repo.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Repo.Implementation
{
    public class CompanyRepo : GenericRepo<long, Company>, ICompanyRepo
    {


        public void NonGenericMethod()
        {
            throw new NotImplementedException();
        }

        public IList<Employee> GetEmployees(long companyID)
        {
            using SqlConnection sqlConnection = GetOpenConnection();
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);

            return sqlConnection.GetList<Employee>(new { companyID }, sqlTransaction).ToList();
        }
    }
}
