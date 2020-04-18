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
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace AzureFunctionApp.Implementation
{
    public class CompanyFunction : GenericFunction<long, CompanyMV, Company>
    {
        private readonly ICompanyService companyService;

        public CompanyFunction(ICompanyService companyService) : base(companyService)
        {
            this.companyService = companyService;
        }

        [FunctionName("Company_Get")]
        public override async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Company")] HttpRequest req, ILogger log)
        {

            return await base.Get(req, log);
        }

        [FunctionName("Company_Create")]
        public override async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "Company")] HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("");

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                CompanyMV view = JsonConvert.DeserializeObject<CompanyMV>(requestBody);

                var model = view.Adapt<Company>();

                var id = await Task.Run(() => { return companyService.Create(model); });

                view = model.Adapt<CompanyMV>();
                view.ID = id;

                return new OkObjectResult(Task.FromResult(view));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("Company_Update")]
        public override async Task<IActionResult> Update(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "Company")] HttpRequest req, ILogger log)
        {
            return await base.Update(req, log);
        }

        [FunctionName("Company_Delete")]
        public override async Task<IActionResult> Delete(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "Company")] HttpRequest req, ILogger log)
        {

            return await base.Delete(req, log);
        }

        [FunctionName("Company_NonGenericMethodAsync")]
        public async Task<IActionResult> NonGenericMethodAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Company/NonGenericMethodAsync")] HttpRequest req)
        {
            try
            {
                await Task.Run(() => { companyService.NonGenericMethod(); });

                return new OkObjectResult(Task.FromResult(string.Empty));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("Company_GetEmployees")]
        public async Task<IActionResult> GetEmployees(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Company/Employees")] HttpRequest req)
        {
            try
            {
                long.TryParse(req.Query["companyID"], out long companyID);

                var result = await Task.Run(() => { return companyService.GetEmployees(companyID); });

                return new OkObjectResult(Task.FromResult(result.Adapt<IList<EmployeeMV>>()));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
