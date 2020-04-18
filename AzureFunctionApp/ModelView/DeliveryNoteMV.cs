using System;

namespace AzureFunctionApp.ModelView
{
    [Serializable]
    public class DeliveryNoteMV : BaseView
    {
        public long DeliveryID { get; set; }

        public string Notes { get; set; }
        public long CreatedByID { get; set; }
        public DateTime CreatedOn { get; set; }

        public DeliveryMV Delivery { get; set; }
    }
}
