using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Framework.Core.Base.DBEntity;

namespace Authentication.Core.DBEntities
{
    [Table("Role")]
    public class Role : DbEntityBase
    {
        [StringLength(15)]
        public string RoleName { get; set; }

        [StringLength(20)]
        public string FriendlyName { get; set; }
    }
}
