using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Service.Interface;
using AzureFunctionApp.Interface;
using Mapster;
using Model;
using AzureFunctionApp.ModelView;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace AzureFunctionApp.Implementation
{
    public class GenericFunction<TKey, TView, TModel> : IGenericFunction<TKey, TView, TModel>
        where TView : BaseView
        where TModel : BaseModel
        where TKey : IConvertible
    {
        private readonly IGenericService<TKey, TModel> genericService;
        public GenericFunction(IGenericService<TKey, TModel> genericService)
        {
            this.genericService = genericService;
        }

        public virtual async Task<IActionResult> Create([HttpTrigger(AuthorizationLevel.Function, new[] { "post" })] HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("");

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                TView view = JsonConvert.DeserializeObject<TView>(requestBody);

                var model = view.Adapt<TModel>();

                await Task.Run(() => { return genericService.Create(model); });

                view = model.Adapt<TView>();

                return new OkObjectResult(Task.FromResult(view));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        public virtual async Task<IActionResult> Delete([HttpTrigger(AuthorizationLevel.Function, new[] { "delete" })] HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("");

                TKey id = (TKey)Convert.ChangeType(req.Query["id"].ToString(), typeof(TKey));

                await Task.Run(() => { genericService.Delete(id); });

                return new OkObjectResult(Task.FromResult(true));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        public virtual async Task<IActionResult> Get([HttpTrigger(AuthorizationLevel.Function, new[] { "get" })] HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("");

                TKey id = (TKey)Convert.ChangeType(req.Query["id"].ToString(), typeof(TKey));

                var result = await Task.Run(() => { return genericService.Get(id); });

                return new OkObjectResult(Task.FromResult(result.Adapt<TView>()));
            }
            catch
            {
                try
                {
                    var result = await Task.Run(() => { return genericService.GetAll(); });

                    return new OkObjectResult(Task.FromResult(result.Adapt<IList<TView>>()));
                }
                catch (Exception ex)
                {

                    return new BadRequestObjectResult(ex.Message);
                }
            }
        }

        public virtual async Task<IActionResult> Update([HttpTrigger(AuthorizationLevel.Function, new[] { "put" })] HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("");


                TKey id = (TKey)Convert.ChangeType(req.Query["id"].ToString(), typeof(TKey));

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                TView view = JsonConvert.DeserializeObject<TView>(requestBody);

                var model = view.Adapt<TModel>();

                var result = await Task.Run(() => { return genericService.Edit(id, model); });
                view = result.Adapt<TView>();

                return new OkObjectResult(Task.FromResult(view));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
