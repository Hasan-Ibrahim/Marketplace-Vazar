using System.Data.Entity;
using Data.Context;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories.Abstraction
{
    class PgsqlRepository<TModel>: IRepository<TModel> where TModel : DbModel
    {
        private readonly SqlContext _db;

        public PgsqlRepository()
        {
            _db = new SqlContext();
        }
        public TModel Find(int id)
        {
            return _db.Set<TModel>().Find(id);
        }

        public TModel Find(Func<TModel, bool> query)
        {
            return _db.Set<TModel>().Find(query);
        }

        public bool Exists(Func<TModel, bool> query)
        {
            return _db.Set<TModel>().Any(query);
        }

        public IEnumerable<TModel> GetAll()
        {
            return _db.Set<TModel>().Where(m => m.IsDeleted == false);
        }

        public TModel Create(TModel item)
        {
            return _db.Set<TModel>().Add(item);
        }

        public bool Update(TModel updatedItem)
        {
            _db.Entry(updatedItem).State = EntityState.Modified;
            return true;
        }

        public bool SoftDelete(int id)
        {
            var itemToDelete = Find(id);
            if (itemToDelete != null)
            {
                itemToDelete.IsDeleted = true;
                Update(itemToDelete);
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            SaveChanges();
            _db.Dispose();
        }

        public bool SaveChanges()
        {
            if (_db.ChangeTracker.HasChanges())
            {
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
