using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MicroOrm.Dapper.Repositories.Attributes;

namespace Framework.Core.Base.DBEntity
{
    public abstract class DbEntityBasicBase
    {
        [Key, Identity]
        [Column(Order = 0)]
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }
    }

    public abstract class DbEntityWithDateBase : DbEntityBasicBase
    {
       public DateTime ModifiedDate { get; set; }
    }

    public abstract class DbEntityBase : DbEntityWithDateBase
    {
        public bool IsActive { get; set; }
    }
}
