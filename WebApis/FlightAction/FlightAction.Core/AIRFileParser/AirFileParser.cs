
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using FlightAction.Core.DTOs;
using FlightAction.Core.Interfaces.Others;
using Framework.Core.Utility;

namespace FlightAction.Core.AIRFileParser
{
    public class AirFileParser : IAirFileParser
    {
        public AirFileParser()
        {

        }

        public async Task<Result<AirFileDTO>> ParseUploadedFileAsync(string filePath)
        {
            return await TryCatchExtension.ExecuteAndHandleErrorAsync(async () =>
                   {
                       await Task.Delay(1000);
                       var airFile = new AirFileDTO();

                       return Result.Success(airFile);
                   },
                   ex => new TryCatchExtensionResult<Result<AirFileDTO>>
                   {
                       DefaultResult = Result.Failure<AirFileDTO>($"Error message: {ex.Message}. Details:"),
                       RethrowException = false
                   });
        }
    }
}
