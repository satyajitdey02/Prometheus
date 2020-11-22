using System.IO;
using System.Threading.Tasks;
using FlightAction.Core.DTOs;
using FlightAction.Core.Interfaces.Others;
using FlightAction.Core.Interfaces.Repositories;
using FlightAction.Core.Interfaces.Services;
using FConstants = Framework.Constants;
using Framework.Core.Logger;
using Framework.Core.Utility;
using FlightAction.Core.Entities;

namespace FlightAction.Core.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IAirFileParser _airFileParser;
        private readonly IProLogger _proLogger;
        private readonly IFlightActionManagementRepository _flightActionManagementRepository;

        private string FilesToProcessFolderPath => Path.Combine(FConstants.Constants.Application.Path.BasePath, Constants.Constants.Application.Folders.FilesToProcessFolderName);
        private string ProcessedFolderPath => Path.Combine(FConstants.Constants.Application.Path.BasePath, Constants.Constants.Application.Folders.ProcessedFolderName);

        public FileUploadService(
            IAirFileParser airFileParser,
            IFlightActionManagementRepository flightActionManagementRepository,
            IProLogger proLogger)
        {
            _airFileParser = airFileParser;
            _proLogger = proLogger;
            _flightActionManagementRepository = flightActionManagementRepository;
        }

        public async Task<bool> ProcessFileAsync(FileUploadDTO fileUploadDto)
        {
            var uploadResult = false;

            await TryCatchExtension.ExecuteAndHandleErrorAsync(
                async () =>
                {
                    void PrepareDirectory(string folderPath)
                    {
                        if (!Directory.Exists(folderPath))
                            Directory.CreateDirectory(folderPath);

                    }

                    FileInfo WriteFileToDirectory()
                    {
                        var filePath = Path.Combine(FilesToProcessFolderPath, fileUploadDto.FileName);
                        File.WriteAllBytes(filePath, fileUploadDto.FileBytes);

                        return new FileInfo(filePath);
                    }


                    PrepareDirectory(FilesToProcessFolderPath);

                    var processingFileInfo = WriteFileToDirectory();

                    var fileParsedResult = await _airFileParser.ParseUploadedFileAsync(processingFileInfo.FullName);
                    if (fileParsedResult.IsSuccess)
                    {
                        await _flightActionManagementRepository.FileContentRepository.InsertAsync(fileParsedResult.Value);

                        await _flightActionManagementRepository.UploadedFilesRepository.InsertAsync(new UploadedFiles { FullPath = processingFileInfo.FullName });

                        PrepareDirectory(ProcessedFolderPath);

                        processingFileInfo.MoveTo(Path.Combine(ProcessedFolderPath, fileUploadDto.FileName));

                        uploadResult = true;
                    }
                    else
                    {
                        _proLogger.Error($"An error occurred while uploading and processing the file. Error: {fileParsedResult.Error}");
                    }
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
