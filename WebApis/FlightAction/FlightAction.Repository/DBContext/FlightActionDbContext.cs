using System.Data.SqlClient;
using FlightAction.Core.DBEntities;
using FlightAction.Core.Models;
using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.DbContext;
using Microsoft.Extensions.Configuration;
using Nelibur.ObjectMapper;

namespace FlightAction.Repository.DBContext
{
    public class FlightActionDbContext : DapperDbContext, IFlightActionDbContext
    {
        private IDapperRepository<DbUploadedFiles> _uploadedFiles;

        public FlightActionDbContext(IConfiguration configuration) : base(new SqlConnection(configuration["ConnectionStrings:DefaultConnection"]))
        {
            TinyMapper.Bind<DbUploadedFiles, UploadedFiles>();
            TinyMapper.Bind<UploadedFiles, DbUploadedFiles>();
        }

        public IDapperRepository<DbUploadedFiles> UploadedFile => _uploadedFiles ??= new DapperRepository<DbUploadedFiles>(Connection);
    }
}
