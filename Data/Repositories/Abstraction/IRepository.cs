using System;
using System.Collections.Generic;
using Data.Model;

namespace Data.Repositories.Abstraction
{
    public interface IRepository<TModel> : IDisposable where TModel : DbModel
    {
        TModel Find(int id);

        TModel Find(Func<TModel, bool> query);

        bool Exists(Func<TModel, bool> query);

        IEnumerable<TModel> GetAll();
        TModel Create(TModel item);
        bool Update(TModel updatedItem);
        bool SoftDelete(int id);
    }
}
