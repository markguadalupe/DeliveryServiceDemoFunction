using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Repo.Implementation;
using Repo.Interface;

namespace DI
{
    public class Repository
    {
        public static void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<ICompanyRepo, CompanyRepo>();
            builder.Services.AddSingleton<IEmployeeRepo, EmployeeRepo>();
        }
    }
}
