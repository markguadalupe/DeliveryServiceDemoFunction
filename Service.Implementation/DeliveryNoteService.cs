using System;
using System.Collections.Generic;
using Service.Interface;
using Repo.Interface;
using Model;
using Enums = Model.Enums;

namespace Service.Implementation
{
    public class DeliveryNoteService : GenericService<long, DeliveryNote>, IDeliveryNoteService
    {
        public DeliveryNoteService(IDeliveryNoteRepo DeliveryNoteRepo) : base(DeliveryNoteRepo)
        {
        }
    }
}
