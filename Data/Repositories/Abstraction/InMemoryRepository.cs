/*
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Model;
using FizzWare.NBuilder;

namespace Data.Repositories.Abstraction
{
    public class InMemoryRepository<TModel> : IRepository<TModel> where TModel : DbModel
    {
        private static int _sequence = 100000;
        private static IDictionary<Type, IDictionary> _database;
        static InMemoryRepository()
        {
            _database = new Dictionary<Type, IDictionary>();

            var users = Builder<DbUser>.CreateListOfSize(10).All().Do(user => user.HashedPassword = "202cb962ac59075b964b07152d234b70").Build().ToDictionary(user => user.Id, user => user);

            _database[typeof(DbUser)] = users;
        }

        private readonly IDictionary<int, TModel> _collection;
        public InMemoryRepository()
        {
            _collection = (IDictionary<int, TModel>)_database[typeof(TModel)];
        }

        public async Task<TModel> Find(int id)
        {
            return await GetAll().FirstOrDefaultAsync(model => model.Id == id);
        }

        public Task<TModel> Find(Expression<Func<TModel, bool>> query)
        {
            return GetAll().FirstOrDefaultAsync(query);
        }

        public bool Exists(Func<TModel, bool> query)
        {
            return GetAll().Any(query);
        }

        public Task<IQueryable<TModel>> GetAll()
        {
            var models = _collection.Values.Where(model => !model.IsDeleted).ToList();
            return models;
        }

        public TModel Create(TModel item)
        {
            var id = ++_sequence;
            item.Id = id;
            _collection.Add(id, item);
            return item;
        }

        public bool Update(TModel updatedItem)
        {
            if (!_collection.ContainsKey(updatedItem.Id))
            {
                return false;
            }
            _collection[updatedItem.Id] = updatedItem;
            return true;
        }
        
        public bool SoftDelete(int id)
        {
            var itemToDelete = Find(id);
            if (itemToDelete == null)
            {
                return false;
            }

            itemToDelete.IsDeleted = true;
            return true;
        }

        public void Dispose()
        {
        }
    }
}
*/
