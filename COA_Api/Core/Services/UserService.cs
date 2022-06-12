using COA_Api.Core.Services.Interfaces;
using COA_Api.Entities;
using COA_Api.Repositories.Interfaces;

namespace COA_Api.Core.Services;

public class UserService : GenericService<User>, IUserService
{
    public UserService(IUserRepository userRepository) : base(userRepository)
    {
    }
}
