using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("MEDIA_TRAFFIC_VENDOR")]
    public partial class MediaTrafficVendor
    {
        [Key]
        [Column("MEDIA_TRAFFIC_VENDOR_ID")]
        public int MediaTrafficVendorId { get; set; }
        [Column("MEDIA_TRAFFIC_REVISION_ID")]
        public int MediaTrafficRevisionId { get; set; }
        [Required]
        [Column("VN_CODE")]
        [StringLength(6)]
        public string VnCode { get; set; }
        [Column("ALERT_ID")]
        public int? AlertId { get; set; }
    }
}
