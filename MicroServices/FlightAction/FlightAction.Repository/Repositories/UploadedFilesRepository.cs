using FlightAction.Core.Entities;
using FlightAction.Core.Interfaces.Repositories;
using FlightAction.Repository.DBContext;
using MicroOrm.Dapper.Repositories;

namespace FlightAction.Repository.Repositories
{
    public class UploadedFilesRepository : DapperRepository<UploadedFiles>, IUploadedFilesRepository
    {
        private readonly FlightActionDbContext _flightActionDbContext;

        public UploadedFilesRepository(FlightActionDbContext flightActionDbContext) : base(flightActionDbContext.Connection)
        {
            _flightActionDbContext = flightActionDbContext;
        }
    }
}
