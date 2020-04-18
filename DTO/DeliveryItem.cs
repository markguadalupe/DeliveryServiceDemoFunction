using Dapper;

namespace Model
{
    [Table("tblDeliveryItem")]
    public class DeliveryItem : BaseModel
    {
        public long DeliveryID { get; set; }

        public decimal ItemCount { get; set; }
        public Enums.ItemUnit ItemUnit { get; set; }
        public string ItemDescription { get; set; }
        public Enums.ItemStatus ItemStatus { get; set; }

        [NotMapped]
        public Delivery Delivery { get; set; }
    }
}
