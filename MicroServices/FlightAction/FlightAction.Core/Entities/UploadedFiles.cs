using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using Framework.Core.Base.DBEntity;

namespace FlightAction.Core.Entities
{
    [Table("UploadedFile")]
    public class UploadedFiles : DbEntityBase
    {
        [StringLength(200)]
        public string FullPath { get; set; }

        [NotMapped]
        public string FullName => Path.GetFileName(FullPath);
    }
}
