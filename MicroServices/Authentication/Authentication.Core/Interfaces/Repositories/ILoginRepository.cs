using System.Threading.Tasks;
using Authentication.Core.DBEntities;
using MicroOrm.Dapper.Repositories;

namespace Authentication.Core.Interfaces.Repositories
{
    public interface ILoginRepository : IDapperRepository<Login>
    {
        Task<Login> Getsdasd();
    }
}