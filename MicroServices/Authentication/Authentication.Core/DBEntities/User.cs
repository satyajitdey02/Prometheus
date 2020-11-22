using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Framework.Core.Base.DBEntity;

namespace Authentication.Core.DBEntities
{
    [Table("User")]
    public class User : DbEntityBase
    {
        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(40)]
        public string DisplayName { get; set; }

        [StringLength(200)]
        public string Password { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }
    }
}
