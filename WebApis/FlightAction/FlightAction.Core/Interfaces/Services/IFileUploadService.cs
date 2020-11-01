using System.Threading.Tasks;
using FlightAction.Core.DTOs;

namespace FlightAction.Core.Interfaces.Services
{
    public interface IFileUploadService
    {
        Task<bool> UploadFileAsync(FileUploadDTO fileUploadDto);
    }
}