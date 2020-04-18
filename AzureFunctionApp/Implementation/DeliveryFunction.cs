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
    public class DeliveryFunction : GenericFunction<long, DeliveryMV, Delivery>
    {
        private readonly IDeliveryService deliveryService;

        public DeliveryFunction(IDeliveryService deliveryService) : base(deliveryService)
        {
            this.deliveryService = deliveryService;
        }

        [FunctionName("Delivery_Create")]
        public override async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "Delivery")] HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("");

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                DeliveryMV view = JsonConvert.DeserializeObject<DeliveryMV>(requestBody);

                var model = view.Adapt<Delivery>();
                var deliveryID = await Task.Run(() => { return deliveryService.Create(model); });

                view = model.Adapt<DeliveryMV>();
                view.ID = deliveryID;

                return new OkObjectResult(Task.FromResult(view));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("Delivery_Update")]
        public override async Task<IActionResult> Update([HttpTrigger(AuthorizationLevel.Function, "put", Route = "Delivery")] HttpRequest view, ILogger log)
        {
            return await base.Update(view, log);
        }

        [FunctionName("Delivery_Delete")]
        public override async Task<IActionResult> Delete(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "Delivery")] HttpRequest req, ILogger log)
        {
            return await base.Delete(req, log);
        }

        [FunctionName("Delivery_Get")]
        public override async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Delivery")] HttpRequest req, ILogger log)
        {

            return await base.Get(req, log);
        }
    }
}
