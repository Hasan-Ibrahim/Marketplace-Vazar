using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Context;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories.Abstraction
{
    public class PgsqlRepository<TModel>: IRepository<TModel> where TModel : DbModel
    {
        private readonly SqlContext _db;

        public PgsqlRepository(SqlContext sqlContext)
        {
            _db = sqlContext;
        }
        public async Task<TModel> Find(int id)
        {
            return await _db.Set<TModel>().FindAsync(id);
        }

        public async Task<TModel> Find(Expression<Func<TModel, bool>> query)
        {
            return await _db.Set<TModel>().FirstOrDefaultAsync(query);
        }

        public bool Exists(Expression<Func<TModel, bool>> query)
        {
            return _db.Set<TModel>().Any(query);
        }

        public async Task<IEnumerable<TModel>> GetAll()
        {
            return await _db.Set<TModel>().Where(m => m.IsDeleted == false).ToListAsync();
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
            var itemTask = Find(id);
            if (itemTask.IsCompleted && itemTask.Result != null)
            {
                itemTask.Result.IsDeleted = true;
                Update(itemTask.Result);
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
