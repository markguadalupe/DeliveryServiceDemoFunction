﻿using Dapper;
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
                    item.CreatedOn = entity.CreatedOn;
                    item.ID = sqlConnection.Insert<long, DeliveryItem>(item, sqlTransaction);
                }

                foreach (var item in entity.DeliveryStatus)
                {
                    item.CreatedOn = entity.CreatedOn;
                    item.DeliveryID = deliveryID;
                    item.ID = sqlConnection.Insert<long, DeliveryStatus>(item, sqlTransaction);
                }

                foreach (var item in entity.DeliveryNotes)
                {
                    item.CreatedOn = entity.CreatedOn;
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

        public override IList<Delivery> GetAll()
        {
            using SqlConnection sqlConnection = GetOpenConnection();
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);

            var list = sqlConnection.GetList<Delivery>(new { }, sqlTransaction).ToList();

            foreach (var item in list)
            {
                item.DeliveryItems = sqlConnection.GetList<DeliveryItem>(new { DeliveryID = item.ID }, sqlTransaction).ToList();
                item.DeliveryStatus = sqlConnection.GetList<DeliveryStatus>(new { DeliveryID = item.ID }, sqlTransaction).ToList();
                item.DeliveryNotes = sqlConnection.GetList<DeliveryNote>(new { DeliveryID = item.ID }, sqlTransaction).ToList();
            }

            return list;
        }

        public IList<DeliveryItem> GetItems(long deliverID)
        {
            using SqlConnection sqlConnection = GetOpenConnection();
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);

            return sqlConnection.GetList<DeliveryItem>(new { DeliveryID = deliverID }, sqlTransaction).ToList();
        }

        public IList<DeliveryStatus> GetStatus(long deliverID)
        {
            using SqlConnection sqlConnection = GetOpenConnection();
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);

            return sqlConnection.GetList<DeliveryStatus>(new { DeliveryID = deliverID }, sqlTransaction).ToList();
        }

        public IList<DeliveryNote> GetNotes(long deliverID)
        {
            using SqlConnection sqlConnection = GetOpenConnection();
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);

            return sqlConnection.GetList<DeliveryNote>(new { DeliveryID = deliverID }, sqlTransaction).ToList();
        }
    }
}
