using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroOrm.Dapper.Repositories.Attributes;

namespace Framework.Core.Base.DBEntity
{
    public class DbEntityBase
    {
        [Key, Identity]
        [Column(Order = 0)]
        public int Id { get; set; }
    }
}
