using System.Threading.Tasks;
using FlightAction.Core.DTOs;
using FlightAction.Core.Interfaces.Repositories;
using FlightAction.Core.Interfaces.Services;
using FlightAction.Core.Models;
using Framework.Core.Logger;
using Framework.Core.Utility;

namespace FlightAction.Core.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IProLogger _proLogger;
        private readonly IFlightActionManagementRepository _flightActionManagementRepository;

        public FileUploadService(IFlightActionManagementRepository flightActionManagementRepository, IProLogger proLogger)
        {
            _proLogger = proLogger;
            _flightActionManagementRepository = flightActionManagementRepository;
        }

        public async Task<bool> UploadFileAsync(FileUploadDTO fileUploadDto)
        {
            var uploadResult = false;

            await TryCatchExtension.ExecuteAndHandleErrorAsync(
                async () =>
                {
                    await _flightActionManagementRepository.UploadedFilesRepository.InsertAsync(new UploadedFiles { FullPath = @"C:\FlightAction\Processed\a.txt" });
                    uploadResult = true;
                },
                ex =>
                {
                    _proLogger.Error($"An error occurred while uploading and processing the file. Error: {ex.Message}");
                    uploadResult = false;

                    return false;
                });

            return uploadResult;
        }
    }
}
