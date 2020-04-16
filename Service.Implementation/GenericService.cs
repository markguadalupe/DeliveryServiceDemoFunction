using System;
using System.Collections.Generic;
using Service.Interface;
using Repo.Interface;
using Model;

namespace Service.Implementation
{
    public class GenericService<TKey, TModel> : IGenericService<TKey, TModel>
        where TModel : BaseModel
    {
        private readonly IGenericRepo<TKey, TModel> genericRepo;

        public GenericService(IGenericRepo<TKey, TModel> genericRepo)
        {
            this.genericRepo = genericRepo;
        }

        public virtual TKey Create(TModel model)
        {
            return genericRepo.Create(model);
        }

        public virtual IList<TModel> Create(IList<TModel> models)
        {
            return genericRepo.Create(models);
        }

        public virtual void Delete(TKey id)
        {
            genericRepo.Delete(id);
        }

        public virtual TModel Edit(TModel model)
        {
            return genericRepo.Edit(model);
        }

        public virtual TModel Get(TKey id)
        {
            var result = genericRepo.Get(id);
            return result;
        }

        public IList<TModel> GetAll()
        {
            var result = genericRepo.GetAll();
            return result;
        }
    }
}
