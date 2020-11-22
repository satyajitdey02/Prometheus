using Authentication.Core.DBEntities;
using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.DbContext;

namespace Authentication.Repository.DBContext
{
    public interface IAuthenticationDbContext : IDapperDbContext
    {
        IDapperRepository<Login> Login { get; }
    }
}
