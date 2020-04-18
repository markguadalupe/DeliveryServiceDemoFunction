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
using System.IO;
using Newtonsoft.Json;

namespace AzureFunctionApp.Implementation
{
    public class EmployeeFunction : GenericFunction<long, EmployeeMV, Employee>
    {
        private readonly IEmployeeService employeeService;

        public EmployeeFunction(IEmployeeService employeeService) : base(employeeService)
        {
            this.employeeService = employeeService;
        }

        [FunctionName("Employee_Get")]
        public override async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Employee")] HttpRequest req, ILogger log)
        {

            return await base.Get(req, log);
        }

        [FunctionName("Employee_Create")]
        public override async Task<IActionResult> Create([HttpTrigger(AuthorizationLevel.Function, "post", Route = "Employee")] HttpRequest req, ILogger log)
        {
            try
            {
                log.LogInformation("");

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                EmployeeMV view = JsonConvert.DeserializeObject<EmployeeMV>(requestBody);

                var model = view.Adapt<Employee>();

                var id = await Task.Run(() => { return employeeService.Create(model); });

                view = model.Adapt<EmployeeMV>();
                view.ID = id;

                return new OkObjectResult(Task.FromResult(view));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [FunctionName("Employee_Update")]
        public override async Task<IActionResult> Update(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "Employee")] HttpRequest req, ILogger log)
        {
            return await base.Update(req, log);
        }

        [FunctionName("Employee_Delete")]
        public override async Task<IActionResult> Delete(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "Employee")] HttpRequest req, ILogger log)
        {
            return await base.Delete(req, log);
        }
    }
}
