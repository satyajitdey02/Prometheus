using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Framework.Core.Base.DBEntity;
using MicroOrm.Dapper.Repositories.Attributes.Joins;

namespace Authentication.Core.DBEntities
{
    [Table("Login")]
    public class Login : DbEntityWithDateBase
    {
        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(20)]
        public string Password { get; set; }

        public int EmployeeId { get; set; }

        [LeftJoin("Employee", "EmployeeId", "Id")]
        public virtual Employee Employee { get; set; }
    }
}
