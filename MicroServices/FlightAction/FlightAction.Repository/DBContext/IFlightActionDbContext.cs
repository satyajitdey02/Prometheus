using FlightAction.Core.Entities;
using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.DbContext;

namespace FlightAction.Repository.DBContext
{
    public interface IFlightActionDbContext : IDapperDbContext
    {
        IDapperRepository<UploadedFiles> UploadedFile { get; }
        IDapperRepository<FileContent> FileContent { get; }
    }
}
