﻿using System;
using System.Collections.Generic;
using Service.Interface;
using Repo.Interface;
using Model;

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

            model.DeliveryStatus.Add(new DeliveryStatus { CreatedByID = model.CreatedByID, CreatedOn = model.CreatedOn });

            return base.Create(model);
        }
    }
}
