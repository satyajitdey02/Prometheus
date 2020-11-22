using System.Data.SqlClient;
using Authentication.Core.DBEntities;
using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.DbContext;
using Microsoft.Extensions.Configuration;

namespace Authentication.Repository.DBContext
{
    public class AuthenticationDbContext : DapperDbContext, IAuthenticationDbContext
    {
        private IDapperRepository<Login> _fileContent;

        public AuthenticationDbContext(IConfiguration configuration) : base(new SqlConnection(configuration["ConnectionStrings:DefaultConnection"]))
        {

        }

        public IDapperRepository<Login> Login => _fileContent ??= new DapperRepository<Login>(Connection);
    }
}
