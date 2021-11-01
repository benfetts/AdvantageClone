using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("MEDIA_RFP_HEADER")]
    public partial class MediaRFPHeader
    {
        [Key]
        [Column("MEDIA_RFP_HEADER_ID")]
        public int MediaRfpHeaderId { get; set; }
        [Column("MEDIA_BROADCAST_WORKSHEET_MARKET_ID")]
        public int MediaBroadcastWorksheetMarketId { get; set; }
        [Column("REQUEST_DATE", TypeName = "smalldatetime")]
        public DateTime? RequestDate { get; set; }
        [Column("DUE_DATE", TypeName = "smalldatetime")]
        public DateTime? DueDate { get; set; }
        [Required]
        [Column("VN_CODE")]
        [StringLength(6)]
        public string VnCode { get; set; }
        [Column("SYSCODE")]
        public int? Syscode { get; set; }
        [Column("COMMENTS")]
        public string Comments { get; set; }
        [Column("COMMENT_TO_VENDOR")]
        public string CommentToVendor { get; set; }
        [Column("ALERT_ID")]
        public int? AlertId { get; set; }
        [Column("TIME_DUE")]
        [StringLength(10)]
        public string TimeDue { get; set; }

        [ForeignKey(nameof(AlertId))]
        [InverseProperty("MediaRfpHeaders")]
        public virtual Alert Alert { get; set; }
    }
}
