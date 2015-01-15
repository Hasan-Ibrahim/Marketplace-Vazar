using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;

namespace Data.Repositories.Abstraction
{
    class PgsqlRepository<TModel>: IRepository<TModel> where TModel : DbModel
    {
        public TModel Find(int id)
        {
            throw new NotImplementedException();
        }

        public TModel Find(Func<TModel, bool> query)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Func<TModel, bool> query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public TModel Create(TModel item)
        {
            throw new NotImplementedException();
        }

        public bool Update(TModel updatedItem)
        {
            throw new NotImplementedException();
        }

        public bool SoftDelete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
