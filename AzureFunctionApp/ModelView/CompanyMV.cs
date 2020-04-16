using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionApp.ModelView
{
    [Serializable]
    public class CompanyMV : BaseView
    {
        public string Name { get; set; }
    }
}
