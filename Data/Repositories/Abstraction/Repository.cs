﻿using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repositories.Abstraction
{
    public class Repository<TModel> : IRepository<TModel> where TModel : DbModel
    {
        private readonly IRepository<TModel> _inneRepository;

        public Repository(IRepository<TModel> inneRepository)
        {
            _inneRepository = inneRepository;
        }

        public async Task<TModel> Find(int id)
        {
            return await _inneRepository.Find(id);
        }

        public async Task<TModel> Find(Expression<Func<TModel, bool>> query)
        {
            return await _inneRepository.Find(query);
        }

        public bool Exists(Expression<Func<TModel, bool>> query)
        {
            return _inneRepository.Exists(query);
        }

        public async Task<IEnumerable<TModel>> GetAll()
        {
            return await _inneRepository.GetAll();
        }

        public TModel Create(TModel item)
        {
           return _inneRepository.Create(item);
        }

        public bool Update(TModel updatedItem)
        {
            return _inneRepository.Update(updatedItem);
        }

        public bool SoftDelete(int id)
        {
            return _inneRepository.SoftDelete(id);
        }

        public void Dispose()
        {
            _inneRepository.Dispose();
        }
    }
}
