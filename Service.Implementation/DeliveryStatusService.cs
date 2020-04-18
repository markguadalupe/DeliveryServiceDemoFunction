using System;
using System.Collections.Generic;
using Service.Interface;
using Repo.Interface;
using Model;
using Enums = Model.Enums;

namespace Service.Implementation
{
    public class DeliveryStatusService : GenericService<long, DeliveryStatus>, IDeliveryStatusService
    {
        public DeliveryStatusService(IDeliveryStatusRepo DeliveryStatusRepo) : base(DeliveryStatusRepo)
        {
        }
    }
}
