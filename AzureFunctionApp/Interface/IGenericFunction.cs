using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Model;
using AzureFunctionApp.ModelView;

namespace AzureFunctionApp.Interface
{
    public interface IGenericFunction<TKey, TView, TModel>
        where TView : BaseView
        where TModel : BaseModel
    {
        Task<IActionResult> Create([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req, ILogger log);

        Task<IActionResult> Update([HttpTrigger(AuthorizationLevel.Function, "put")] HttpRequest req, ILogger log);

        Task<IActionResult> Delete([HttpTrigger(AuthorizationLevel.Function, "delete")] HttpRequest req, ILogger log);

        Task<IActionResult> Get([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req, ILogger log);
    }
}
