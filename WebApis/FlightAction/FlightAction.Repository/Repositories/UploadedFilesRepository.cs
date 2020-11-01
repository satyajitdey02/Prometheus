using System.Collections.Generic;
using System.Threading.Tasks;
using FlightAction.Core.DBEntities;
using FlightAction.Core.Interfaces.Repositories;
using FlightAction.Core.Models;
using FlightAction.Repository.DBContext;
using Nelibur.ObjectMapper;

namespace FlightAction.Repository.Repositories
{
    public class UploadedFilesRepository : IUploadedFilesRepository
    {
        private readonly FlightActionDbContext _flightActionDbContext;

        public UploadedFilesRepository(FlightActionDbContext flightActionDbContext)
        {
            _flightActionDbContext = flightActionDbContext;
        }

        public async Task<bool> InsertAsync(UploadedFiles modelObject)
        {
            var dbObject = TinyMapper.Map<DbUploadedFiles>(modelObject);

            using var db = _flightActionDbContext;
            return await db.UploadedFile.InsertAsync(dbObject);
        }

        public async Task<List<UploadedFiles>> FindAllAsync()
        {
            using var db = _flightActionDbContext;
            var dbObject = await db.UploadedFile.FindAllAsync();

            return TinyMapper.Map<List<UploadedFiles>>(dbObject);
        }
    }
}
