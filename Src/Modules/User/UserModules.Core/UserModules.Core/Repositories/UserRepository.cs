using Common.Infrastructure.Repository;
using UserModules.Data;
using UserModules.Data.Entities;

namespace UserModules.Core.Repositories
{
    public class UserRepository : BaseRepository<User, UserContext>, IUserRepository
    {
        public UserRepository(UserContext context) : base(context)
        {
        }
    }
}