using Common.Domain.Repository;
using UserModules.Data.Entities;

namespace UserModules.Core.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}