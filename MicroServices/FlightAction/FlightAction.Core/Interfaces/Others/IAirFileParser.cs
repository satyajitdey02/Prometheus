using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using FlightAction.Core.Entities;

namespace FlightAction.Core.Interfaces.Others
{
    public interface IAirFileParser
    {
        Task<Result<FileContent>> ParseUploadedFileAsync(string filePath);
    }
}