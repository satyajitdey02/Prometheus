using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using FlightAction.Core.Entities;
using FlightAction.Core.Interfaces.Others;
using Framework.Core.Utility;

namespace FlightAction.Core.AIRFileParser
{
    public class AirFileParser : IAirFileParser
    {
        public async Task<Result<FileContent>> ParseUploadedFileAsync(string filePath)
        {
            return await TryCatchExtension.ExecuteAndHandleErrorAsync(async () =>
                   {
                       await Task.Delay(1000);

                       return Result.Success(ParseFile(filePath));
                   },
                   ex => new TryCatchExtensionResult<Result<FileContent>>
                   {
                       DefaultResult = Result.Failure<FileContent>($"Error message: {ex.Message}. Details:"),
                       RethrowException = false
                   });
        }

        private FileContent ParseFile(string filePath)
        {
            // This text is added only once to the file.
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found in the location: {filePath}");


            // Open the file to read from.
            string[] readText = File.ReadAllLines(filePath);
            if (!readText.Any())
                throw new DataException($"File in the location: {filePath} does not contain any data");


            var fileContent = new FileContent();

            // TODO: Check if FileContent.Create() works for dapper as the constructor has be protected
            //var fileContent = new FileContent();


            foreach (string s in readText)
            {
                switch (s)
                {
                    case var someVal when new Regex(@"^[A-]+$").IsMatch(someVal):
                        fileContent.CustomerCode = $"{someVal}: all lower";
                        break;
                    case var someVal when new Regex(@"^[B-]+$").IsMatch(someVal):
                        Console.WriteLine($"{someVal}: all upper");
                        break;
                    case var someVal when new Regex(@"^[C-]+$").IsMatch(someVal):
                        Console.WriteLine($"{someVal}: all upper");
                        break;
                    case var someVal when new Regex(@"^[D-]+$").IsMatch(someVal):
                        Console.WriteLine($"{someVal}: all upper");
                        break;
                    default:
                        Console.WriteLine($"{s}: not all upper or lower");
                        break;
                }
            }

            return fileContent;
        }
    }
}
