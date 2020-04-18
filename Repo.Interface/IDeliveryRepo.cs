using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Repo.Interface
{
    public interface IDeliveryRepo : IGenericRepo<long, Delivery>
    {
        IList<DeliveryItem> GetItems(long deliverID);
        IList<DeliveryStatus> GetStatus(long deliverID);
        IList<DeliveryNote> GetNotes(long deliverID);
    }
}
