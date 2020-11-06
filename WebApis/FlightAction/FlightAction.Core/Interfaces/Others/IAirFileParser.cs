using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using FlightAction.Core.DTOs;

namespace FlightAction.Core.Interfaces.Others
{
    public interface IAirFileParser
    {
        Task<Result<AirFileDTO>> ParseUploadedFileAsync(string filePath);
    }
}