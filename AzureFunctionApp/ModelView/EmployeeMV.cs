using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionApp.ModelView
{
    public class EmployeeMV : BaseView
    {
        public long CompanyID { get; set; }
        public string Name { get; set; }
    }
}
