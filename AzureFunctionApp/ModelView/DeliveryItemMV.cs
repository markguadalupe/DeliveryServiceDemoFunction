using System;
using Enums = Model.Enums;

namespace AzureFunctionApp.ModelView
{
    [Serializable]
    public class DeliveryItemMV : BaseView
    {
        public long DeliveryID { get; set; }

        public decimal ItemCount { get; set; }
        public Enums.ItemUnit ItemUnit { get; set; }
        public string ItemDescription { get; set; }
        public Enums.ItemStatus ItemStatus { get; set; }

        public DeliveryMV Delivery { get; set; }
    }
}
