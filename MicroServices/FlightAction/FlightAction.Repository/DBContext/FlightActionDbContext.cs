using System.Data.SqlClient;
using FlightAction.Core.Entities;
using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.DbContext;
using Microsoft.Extensions.Configuration;

namespace FlightAction.Repository.DBContext
{
    public class FlightActionDbContext : DapperDbContext, IFlightActionDbContext
    {
        private IDapperRepository<UploadedFiles> _uploadedFiles;
        private IDapperRepository<FileContent> _fileContent;

        public FlightActionDbContext(IConfiguration configuration) : base(new SqlConnection(configuration["ConnectionStrings:DefaultConnection"]))
        {
            
        }

        public IDapperRepository<UploadedFiles> UploadedFile => _uploadedFiles ??= new DapperRepository<UploadedFiles>(Connection);
        public IDapperRepository<FileContent> FileContent => _fileContent ??= new DapperRepository<FileContent>(Connection);
    }
}
