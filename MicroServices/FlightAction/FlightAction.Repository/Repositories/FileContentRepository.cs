using FlightAction.Core.Entities;
using FlightAction.Core.Interfaces.Repositories;
using FlightAction.Repository.DBContext;
using MicroOrm.Dapper.Repositories;

namespace FlightAction.Repository.Repositories
{
    public class FileContentRepository : DapperRepository<FileContent>, IFileContentRepository
    {
        private readonly FlightActionDbContext _flightActionDbContext;

        public FileContentRepository(FlightActionDbContext flightActionDbContext) : base(flightActionDbContext.Connection)
        {
            _flightActionDbContext = flightActionDbContext;
        }
    }
}
