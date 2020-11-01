using FlightAction.Core.DBEntities;
using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.DbContext;

namespace FlightAction.Repository.DBContext
{
    public interface IFlightActionDbContext : IDapperDbContext
    {
        IDapperRepository<DbUploadedFiles> UploadedFile { get; }
    }
}
