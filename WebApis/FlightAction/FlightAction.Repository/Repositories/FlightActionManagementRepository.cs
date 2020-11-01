using FlightAction.Core.Interfaces.Repositories;
using FlightAction.Repository.DBContext;

namespace FlightAction.Repository.Repositories
{
    public class FlightActionManagementRepository : IFlightActionManagementRepository
    {
        private readonly FlightActionDbContext _flightActionDbContext;

        private IUploadedFilesRepository _uploadedFilesRepository;

        public FlightActionManagementRepository(FlightActionDbContext flightActionDbContext)
        {
            _flightActionDbContext = flightActionDbContext;
        }

        public IUploadedFilesRepository UploadedFilesRepository => _uploadedFilesRepository ??= new UploadedFilesRepository(_flightActionDbContext);
    }
}
