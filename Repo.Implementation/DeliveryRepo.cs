using Dapper;
using Model;
using Repo.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Repo.Implementation
{
    public class DeliveryRepo : GenericRepo<long, Delivery>, IDeliveryRepo
    {

        public override long Create(Delivery entity)
        {
            using SqlConnection sqlConnection = GetOpenConnection();
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                long deliveryID = sqlConnection.Insert<long, Delivery>(entity, sqlTransaction);

                foreach (var item in entity.DeliveryItems)
                {
                    item.DeliveryID = deliveryID;
                    item.ID = sqlConnection.Insert<long, DeliveryItem>(item, sqlTransaction);
                }

                foreach (var item in entity.DeliveryStatus)
                {
                    item.DeliveryID = deliveryID;
                    item.ID = sqlConnection.Insert<long, DeliveryStatus>(item, sqlTransaction);
                }

                foreach (var item in entity.DeliveryNotes)
                {
                    item.DeliveryID = deliveryID;
                    item.ID = sqlConnection.Insert<long, DeliveryNote>(item, sqlTransaction);
                }

                sqlTransaction.Commit();

                return deliveryID;
            }
            catch
            {
                sqlTransaction.Rollback();
                throw;
            }
        }

        public override Delivery Get(long id)
        {
            using SqlConnection sqlConnection = GetOpenConnection();
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);

            var entity = sqlConnection.Get<Delivery>(id, transaction: sqlTransaction);

            if (entity != null)
            {
                entity.DeliveryItems = sqlConnection.GetList<DeliveryItem>(new { DeliveryID = entity.ID }, sqlTransaction).ToList();
                entity.DeliveryStatus = sqlConnection.GetList<DeliveryStatus>(new { DeliveryID = entity.ID }, sqlTransaction).ToList();
                entity.DeliveryNotes = sqlConnection.GetList<DeliveryNote>(new { DeliveryID = entity.ID }, sqlTransaction).ToList();
            }

            return entity;
        }
    }
}
