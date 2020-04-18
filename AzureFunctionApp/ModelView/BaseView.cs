using System;

namespace AzureFunctionApp.ModelView
{
    public abstract class BaseView
    {
        public long ID { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
