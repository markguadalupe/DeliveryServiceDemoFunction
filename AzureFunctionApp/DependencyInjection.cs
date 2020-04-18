using AzureFunctionApp.Implementation;
using AzureFunctionApp.Interface;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace AzureFunctionApp
{
    public class DependencyInjection
    {
        public static void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<ICompanyFunction, CompanyFunction>();
            builder.Services.AddSingleton<IEmployeeFunction, EmployeeFunction>();
            builder.Services.AddSingleton<IDeliveryFunction, DeliveryFunction>();
        }
    }
}
