using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Framework.Core.Base.DBEntity;

namespace Authentication.Core.DBEntities
{
    [Table("Company")]
    public class Company : DbEntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string DisplayName { get; set; }

        [StringLength(100)]
        public string Logo { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(20)]
        public string PhoneNo { get; set; }

        [StringLength(20)]
        public string MobileNo { get; set; }

        [StringLength(20)]
        public string TradeLicenseNo { get; set; }

        [StringLength(20)]
        public string RegistrationNo { get; set; }

        public DateTime RegistrationDate { get; set; }

        [StringLength(50)]
        public string ContactEmail { get; set; }

        public string XmlData { get; set; }
    }
}
