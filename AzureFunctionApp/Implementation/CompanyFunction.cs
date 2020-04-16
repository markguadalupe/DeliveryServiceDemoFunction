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

namespace AzureFunctionApp.Implementation
{
    public class CompanyFunction : ICompanyFunction
    {
        private readonly ICompanyService companyService;

        public CompanyFunction(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [FunctionName("Company_Create")]
        public async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "Company")] CompanyMV model, ILogger log)
        {
            try
            {
                log.LogInformation("");

                var entity = model.Adapt<Company>();
                model.ID = await Task.Run(() => { return companyService.Create(entity); });

                return new OkObjectResult(Task.FromResult(model));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("Company_Update")]
        public async Task<IActionResult> Update(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "Company")] CompanyMV model, ILogger log)
        {
            try
            {
                log.LogInformation("");

                var entity = model.Adapt<Company>();
                var result = await Task.Run(() => { return companyService.Edit(entity); });
                model = result.Adapt<CompanyMV>();

                return new OkObjectResult(Task.FromResult(model));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("Company_Delete")]
        public async Task<IActionResult> Delete(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "Company")] HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("");

                long.TryParse(req.Query["id"], out long id);

                await Task.Run(() => { companyService.Delete(id); });

                return new OkObjectResult(Task.FromResult(true));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("Company_GetAll")]
        public async Task<IActionResult> GetAll(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Company")] HttpRequest req)
        {
            try
            {
                var result = await Task.Run(() => { return companyService.GetAll(); });

                return new OkObjectResult(Task.FromResult(result.Adapt<IList<CompanyMV>>()));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
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
