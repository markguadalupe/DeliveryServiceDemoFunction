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
    public class EmployeeFunction : IEmployeeFunction
    {
        private readonly IEmployeeService employeeService;

        public EmployeeFunction(IEmployeeService EmployeeService)
        {
            this.employeeService = EmployeeService;
        }

        [FunctionName("Employee_Create")]
        public async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "Employee")] EmployeeMV model, ILogger log)
        {
            try
            {
                log.LogInformation("");

                var entity = model.Adapt<Employee>();
                model.ID = await Task.Run(() => { return employeeService.Create(entity); });

                return new OkObjectResult(Task.FromResult(model));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("Employee_Update")]
        public async Task<IActionResult> Update(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "Employee")] EmployeeMV model, ILogger log)
        {
            try
            {
                log.LogInformation("");

                var entity = model.Adapt<Employee>();
                var result = await Task.Run(() => { return employeeService.Edit(entity); });
                model = result.Adapt<EmployeeMV>();

                return new OkObjectResult(Task.FromResult(model));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("Employee_Delete")]
        public async Task<IActionResult> Delete(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "Employee")] HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("");

                long.TryParse(req.Query["id"], out long id);

                await Task.Run(() => { employeeService.Delete(id); });

                return new OkObjectResult(Task.FromResult(true));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("Employee_GetAll")]
        public async Task<IActionResult> GetAll(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Employee")] HttpRequest req)
        {
            try
            {
                var result = await Task.Run(() => { return employeeService.GetAll(); });

                return new OkObjectResult(Task.FromResult(result.Adapt<IList<EmployeeMV>>()));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
