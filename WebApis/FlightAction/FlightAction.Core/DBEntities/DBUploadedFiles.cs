using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Framework.Core.Base.DBEntity;

namespace FlightAction.Core.DBEntities
{
    [Table("UploadedFile")]
    public class DbUploadedFiles : DbEntityBase
    {
        [StringLength(200)]
        public string FullPath { get; set; }
    }
}
