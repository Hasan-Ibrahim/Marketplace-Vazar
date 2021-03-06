﻿using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repositories.Abstraction
{
    public interface IRepository<TModel> : IDisposable where TModel : DbModel
    {
        Task<TModel> Find(int id);

        Task<TModel> Find(Expression<Func<TModel, bool>> query);

        bool Exists(Expression<Func<TModel, bool>> query);

        Task<IEnumerable<TModel>> GetAll();
        TModel Create(TModel item);
        bool Update(TModel updatedItem);
        bool SoftDelete(int id);
    }
}
