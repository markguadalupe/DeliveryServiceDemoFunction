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
            builder.Services.AddSingleton<IDeliveryItemRepo, DeliveryItemRepo>();
            builder.Services.AddSingleton<IDeliveryNoteRepo, DeliveryNoteRepo>();
            builder.Services.AddSingleton<IDeliveryRepo, DeliveryRepo>();
            builder.Services.AddSingleton<IDeliveryStatusRepo, DeliveryStatusRepo>();
            builder.Services.AddSingleton<IEmployeeRepo, EmployeeRepo>();
        }
    }
}
