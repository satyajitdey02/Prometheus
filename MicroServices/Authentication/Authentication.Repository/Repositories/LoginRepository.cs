using System.Threading.Tasks;
using Authentication.Core.DBEntities;
using Authentication.Core.Interfaces.Repositories;
using Authentication.Repository.DBContext;
using Dapper;
using MicroOrm.Dapper.Repositories;

namespace Authentication.Repository.Repositories
{
    public class LoginRepository : DapperRepository<Login>, ILoginRepository
    {
        private readonly AuthenticationDbContext _authenticationDbContext;

        public LoginRepository(AuthenticationDbContext authenticationDbContext) : base(authenticationDbContext.Connection)
        {
            _authenticationDbContext = authenticationDbContext;
        }

        public async Task<Login> Getsdasd()
        {
            _authenticationDbContext.Connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Users WHERE Users.Deleted != 1");

            var login = await _authenticationDbContext.Login
                .FindAsync<Employee>(x => x.UserName == "dpalash23" && x.Password == "pass12345", x => x.Employee);

            return login;

        }
    }
}
