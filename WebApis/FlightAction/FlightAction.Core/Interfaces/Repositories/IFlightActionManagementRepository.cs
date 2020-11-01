namespace FlightAction.Core.Interfaces.Repositories
{
    public interface IFlightActionManagementRepository
    {
        IUploadedFilesRepository UploadedFilesRepository { get; }
    }
}