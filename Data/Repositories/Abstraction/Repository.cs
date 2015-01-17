using System;
using System.Collections.Generic;
using Data.Model;

namespace Data.Repositories.Abstraction
{
    public class Repository<TModel> : IRepository<TModel> where TModel : DbModel
    {
        private readonly IRepository<TModel> _inneRepository;

        public Repository(IRepository<TModel> inneRepository)
        {
            _inneRepository = inneRepository;
        }

        public TModel Find(int id)
        {
            return _inneRepository.Find(id);
        }

        public TModel Find(Func<TModel, bool> query)
        {
            return _inneRepository.Find(query);
        }

        public bool Exists(Func<TModel, bool> query)
        {
            return _inneRepository.Exists(query);
        }

        public IEnumerable<TModel> GetAll()
        {
            return _inneRepository.GetAll();
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
