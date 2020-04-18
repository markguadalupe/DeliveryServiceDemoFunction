using Dapper;
using Model;
using Repo.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Repo.Implementation
{
    public class GenericRepo<TKey, TEntity> : IGenericRepo<TKey, TEntity>
        where TEntity : BaseModel
    {
        protected SqlConnection GetOpenConnection()
        {
            string conn = Environment.GetEnvironmentVariable("MarkDBContext");
            var connection = new SqlConnection(conn);
            connection.Open();
            return connection;
        }

        public virtual TKey Create(TEntity entity)
        {
            using SqlConnection sqlConnection = GetOpenConnection();
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                entity.CreatedOn = DateTime.Now;
                TKey id = sqlConnection.Insert<TKey, TEntity>(entity, sqlTransaction);

                sqlTransaction.Commit();

                return id;
            }
            catch
            {
                sqlTransaction.Rollback();
                throw;
            }
        }

        public virtual IList<TEntity> Create(IList<TEntity> entities)
        {
            using SqlConnection sqlConnection = GetOpenConnection();
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                foreach (var entity in entities)
                    sqlConnection.Insert<TKey, TEntity>(entity, sqlTransaction);

                sqlTransaction.Commit();

                return entities;
            }
            catch
            {
                sqlTransaction.Rollback();
                throw;
            }
        }

        public virtual void Delete(TKey id)
        {
            using SqlConnection sqlConnection = GetOpenConnection();
            using SqlTransaction transaction = sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                sqlConnection.Delete<TEntity>(id, transaction: transaction);

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public virtual TEntity Edit(TEntity entity)
        {
            using SqlConnection sqlConnection = GetOpenConnection();
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                sqlConnection.Update(entity, sqlTransaction);

                sqlTransaction.Commit();

                return entity;
            }
            catch
            {
                sqlTransaction.Rollback();
                throw;
            }
        }

        public virtual TEntity Get(TKey id)
        {
            using SqlConnection sqlConnection = GetOpenConnection();
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);

            return sqlConnection.Get<TEntity>(id, transaction: sqlTransaction);
        }

        public virtual IList<TEntity> GetAll()
        {
            using SqlConnection sqlConnection = GetOpenConnection();

            return sqlConnection.GetList<TEntity>().ToList();
        }
    }
}
