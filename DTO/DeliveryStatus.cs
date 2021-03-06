﻿using Dapper;
using System;

namespace Model
{
    [Table("tblDeliveryStatus")]
    public class DeliveryStatus : BaseModel
    {
        public long DeliveryID { get; set; }

        [Column("DeliveryStatus")]
        public Enums.DeliveryStatus Status { get; set; }
        public string Location { get; set; }
        public long CreatedByID { get; set; }

        [NotMapped]
        public Delivery Delivery { get; set; }
    }
}
