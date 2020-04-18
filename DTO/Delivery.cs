using Dapper;
using System.Collections.Generic;
using System;

namespace Model
{
    [Table("tblDelivery")]
    public class Delivery : BaseModel
    {
        public long ConsignorID { get; set; }
        public long ConsigneeID { get; set; }

        public long CreatedByID { get; set; }

        [NotMapped]
        public Company Consignor { get; set; }
        [NotMapped]
        public Company Consignee { get; set; }

        [NotMapped]
        public IList<DeliveryItem> DeliveryItems { get; set; }

        [NotMapped]
        public IList<DeliveryStatus> DeliveryStatus { get; set; }

        [NotMapped]
        public IList<DeliveryNote> DeliveryNotes { get; set; }

        public Delivery()
        {
            DeliveryItems = new List<DeliveryItem>();
            DeliveryStatus = new List<DeliveryStatus>();
            DeliveryNotes = new List<DeliveryNote>();
        }

    }
}
