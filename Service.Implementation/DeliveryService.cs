using System;
using System.Collections.Generic;
using Service.Interface;
using Repo.Interface;
using Model;
using Enums = Model.Enums;

namespace Service.Implementation
{
    public class DeliveryService : GenericService<long, Delivery>, IDeliveryService
    {
        private readonly IDeliveryRepo deliveryRepo;
        public DeliveryService(IDeliveryRepo deliveryRepo) : base(deliveryRepo)
        {
            this.deliveryRepo = deliveryRepo;
        }

        public override long Create(Delivery model)
        {
            model.CreatedOn = DateTime.Now;

            model.DeliveryStatus.Add(new DeliveryStatus { Status = Enums.DeliveryStatus.PickupRequested, CreatedByID = model.CreatedByID, CreatedOn = model.CreatedOn });

            return base.Create(model);
        }

        public IList<DeliveryItem> GetItems(long deliverID)
        {
            return deliveryRepo.GetItems(deliverID);
        }

        public IList<DeliveryNote> GetNotes(long deliverID)
        {
            return deliveryRepo.GetNotes(deliverID);
        }

        public IList<DeliveryStatus> GetStatus(long deliverID)
        {
            return deliveryRepo.GetStatus(deliverID);
        }
    }
}
