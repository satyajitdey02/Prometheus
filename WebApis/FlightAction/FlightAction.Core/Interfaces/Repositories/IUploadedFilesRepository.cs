using System.Collections.Generic;
using System.Threading.Tasks;
using FlightAction.Core.Models;

namespace FlightAction.Core.Interfaces.Repositories
{
    public interface IUploadedFilesRepository
    {
        Task<bool> InsertAsync(UploadedFiles dbObject);
        Task<List<UploadedFiles>> FindAllAsync();
    }
}