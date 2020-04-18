using System;
using Enums = Model.Enums;

namespace AzureFunctionApp.ModelView
{
    [Serializable]
    public class DeliveryStatusMV : BaseView
    {
        public long DeliveryID { get; set; }

        public Enums.DeliveryStatus Status { get; set; }
        public string Location { get; set; }
        public long CreatedByID { get; set; }

        public DeliveryMV Delivery { get; set; }
    }
}
