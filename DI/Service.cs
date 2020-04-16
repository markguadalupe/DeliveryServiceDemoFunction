using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Service.Implementation;
using Service.Interface;

namespace DI
{
    public class Service
    {
        public static void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<ICompanyService, CompanyService>();
            builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
        }
    }
}
