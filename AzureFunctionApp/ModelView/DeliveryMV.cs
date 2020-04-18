using System;
using System.Collections.Generic;

namespace AzureFunctionApp.ModelView
{
    [Serializable]
    public class DeliveryMV : BaseView
    {
        public long ConsignorID { get; set; }
        public long ConsigneeID { get; set; }
        public long CreatedByID { get; set; }
        public DateTime CreatedOn { get; set; }

        public CompanyMV Consignor { get; set; }

        public CompanyMV Consignee { get; set; }

        public List<DeliveryItemMV> DeliveryItems { get; set; }

        public List<DeliveryStatusMV> DeliveryStatus { get; set; }

        public List<DeliveryNoteMV> DeliveryNotes { get; set; }

        public DeliveryMV()
        {
            DeliveryItems = new List<DeliveryItemMV>();
            DeliveryStatus = new List<DeliveryStatusMV>();
            DeliveryNotes = new List<DeliveryNoteMV>();
        }

    }
}
