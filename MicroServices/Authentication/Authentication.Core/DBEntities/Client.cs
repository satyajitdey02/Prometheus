using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Framework.Core.Base.DBEntity;

namespace Authentication.Core.DBEntities
{
    [Table("Client")]
    public class Client : DbEntityBase
    {
        [StringLength(5)]
        public string Title { get; set; }

        [StringLength(12)]
        public string FirstName { get; set; }

        [StringLength(12)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        [StringLength(20)]
        public string ContactNo { get; set; }

        [StringLength(50)]
        public string PermanentAddress { get; set; }

        [StringLength(50)]
        public string CurrentAddress { get; set; }

        [StringLength(6)]
        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        [StringLength(15)]
        public string PassportNo { get; set; }

        public DateTime PassportIssueDate { get; set; }

        public DateTime PassportExpiryDate { get; set; }

        [StringLength(15)]
        public string NationalIdCardNo { get; set; }

        [StringLength(15)]
        public string SmartCardNo { get; set; }

        [StringLength(100)]
        public string ImagePath { get; set; }

        public string XmlData { get; set; }
    }
}
