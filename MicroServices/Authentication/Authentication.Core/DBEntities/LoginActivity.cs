using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Framework.Core.Base.DBEntity;

namespace Authentication.Core.DBEntities
{
    [Table("LoginActivity")]
    public class LoginActivity : DbEntityBasicBase
    {
        public int LoginId { get; set; }

        [StringLength(20)]
        public string Agent { get; set; }

        [StringLength(20)]
        public string Ip { get; set; }

        [StringLength(200)]
        public string Password { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }
    }
}
