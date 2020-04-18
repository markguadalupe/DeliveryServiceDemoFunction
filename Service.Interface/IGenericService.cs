using Model;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IGenericService<TKey, TModel>
        where TModel : BaseModel
    {
        TKey Create(TModel model);

        IList<TModel> Create(IList<TModel> models);

        TModel Edit(TKey id, TModel model);

        void Delete(TKey id);

        IList<TModel> GetAll();

        TModel Get(TKey id);
    }
}
