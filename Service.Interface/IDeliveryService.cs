using System.Collections.Generic;
using System;
using Model;

namespace Service.Interface
{
    public interface IDeliveryService : IGenericService<long, Delivery>
    {
        IList<DeliveryItem> GetItems(long deliverID);
        IList<DeliveryStatus> GetStatus(long deliverID);
        IList<DeliveryNote> GetNotes(long deliverID);
    }
}
