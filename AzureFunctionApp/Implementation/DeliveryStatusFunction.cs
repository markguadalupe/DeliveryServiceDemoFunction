using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Service.Interface;
using Mapster;
using Model;
using AzureFunctionApp.ModelView;
using System.IO;
using Newtonsoft.Json;

namespace AzureFunctionApp.Implementation
{
    public class DeliveryStatusFunction : GenericFunction<long, DeliveryStatusMV, DeliveryStatus>
    {
        private readonly IDeliveryStatusService deliveryStatusService;

        public DeliveryStatusFunction(IDeliveryStatusService deliveryStatusService) : base(deliveryStatusService)
        {
            this.deliveryStatusService = deliveryStatusService;
        }

        [FunctionName("DeliveryStatus_Create")]
        public override async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "DeliveryStatus")] HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("");

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                DeliveryStatusMV view = JsonConvert.DeserializeObject<DeliveryStatusMV>(requestBody);

                var model = view.Adapt<DeliveryStatus>();
                var deliveryID = await Task.Run(() => { return deliveryStatusService.Create(model); });

                view = model.Adapt<DeliveryStatusMV>();
                view.ID = deliveryID;

                return new OkObjectResult(Task.FromResult(view));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
