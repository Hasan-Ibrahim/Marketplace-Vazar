using System.Threading.Tasks;
using Data.Model;
using Data.Repositories.Abstraction;

namespace Data.Repositories
{
    public class UserRepository : Repository<DbUser>
    {
        public UserRepository(IRepository<DbUser> inneRepository) : base(inneRepository)
        {
        }

        public Task<DbUser> FindByLoginId(string email)
        {
            return Find(user => user.LoginId == email);
        }
    }
}
