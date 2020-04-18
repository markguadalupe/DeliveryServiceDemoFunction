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
        public DeliveryService(IDeliveryRepo deliveryRepo) : base(deliveryRepo)
        {
        }

        public override long Create(Delivery model)
        {
            model.CreatedOn = DateTime.Now;

            model.DeliveryStatus.Add(new DeliveryStatus { Status = Enums.DeliveryStatus.Requested, CreatedByID = model.CreatedByID, CreatedOn = model.CreatedOn });

            return base.Create(model);
        }
    }
}
