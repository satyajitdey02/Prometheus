using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Framework.Core.Base.DBEntity;

namespace FlightAction.Core.Entities
{
    [Table("FileContent")]
    public class FileContent : DbEntityBase
    {
        [StringLength(200)]
        public string CustomerCode { get; set; }

        [StringLength(200)]
        public string CustomerName { get; set; }

        [StringLength(200)]
        public string PassportDetails { get; set; }

        [StringLength(200)]
        public string Tax { get; set; }

        [StringLength(200)]
        public string Fare { get; set; }

        [StringLength(200)]
        public string TicketType { get; set; }

        [StringLength(200)]
        public string TicketingStuff { get; set; }

        [StringLength(200)]
        public string BookingStuff { get; set; }

        [StringLength(200)]
        public string ReturnClass { get; set; }

        [StringLength(200)]
        public string TravelClass { get; set; }

        [StringLength(200)]
        public string ReturnDate { get; set; }

        [StringLength(200)]
        public string TravelDate { get; set; }

        [StringLength(200)]
        public string IssueDate { get; set; }

        [StringLength(200)]
        public string Pax { get; set; }

        [StringLength(200)]
        public string Sector { get; set; }

        [StringLength(200)]
        public string SupplierCode { get; set; }

        [StringLength(200)]
        public string AirlinesCode { get; set; }

        [StringLength(200)]
        public string Original { get; set; }

        [StringLength(200)]
        public string Data { get; set; }
    }
}
