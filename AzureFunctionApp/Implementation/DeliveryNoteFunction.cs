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
    public class DeliveryNoteFunction : GenericFunction<long, DeliveryNoteMV, DeliveryNote>
    {
        private readonly IDeliveryNoteService deliveryNoteService;

        public DeliveryNoteFunction(IDeliveryNoteService deliveryNoteService) : base(deliveryNoteService)
        {
            this.deliveryNoteService = deliveryNoteService;
        }

        [FunctionName("DeliveryNote_Create")]
        public override async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "DeliveryNote")] HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("");

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                DeliveryNoteMV view = JsonConvert.DeserializeObject<DeliveryNoteMV>(requestBody);

                var model = view.Adapt<DeliveryNote>();
                var deliveryID = await Task.Run(() => { return deliveryNoteService.Create(model); });

                view = model.Adapt<DeliveryNoteMV>();
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
