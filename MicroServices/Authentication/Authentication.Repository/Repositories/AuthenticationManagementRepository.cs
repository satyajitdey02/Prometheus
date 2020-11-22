using Authentication.Core.Interfaces.Repositories;
using Authentication.Repository.DBContext;

namespace Authentication.Repository.Repositories
{
    public class AuthenticationManagementRepository : IAuthenticationManagementRepository
    {
        private readonly AuthenticationDbContext _authenticationDbContext;

        private LoginRepository _userRepository;

        public AuthenticationManagementRepository(AuthenticationDbContext flightActionDbContext)
        {
            _authenticationDbContext = flightActionDbContext;
        }

        public ILoginRepository LoginRepository => _userRepository ??= new LoginRepository(_authenticationDbContext);
    }
}
