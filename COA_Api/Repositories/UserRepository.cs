using COA_Api.DataAccess;
using COA_Api.Entities;
using COA_Api.Repositories.Interfaces;

namespace COA_Api.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(CoaDbContext context) : base(context)
    {
    }
}
