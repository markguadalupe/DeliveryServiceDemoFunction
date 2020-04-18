using Dapper;
using System;

namespace Model
{
    [Table("tblDeliveryNote")]
    public class DeliveryNote : BaseModel
    {
        public long DeliveryID { get; set; }

        public string Notes { get; set; }
        public long CreatedByID { get; set; }
        public DateTime CreatedOn { get; set; }

        [NotMapped]
        public Delivery Delivery { get; set; }
    }
}
