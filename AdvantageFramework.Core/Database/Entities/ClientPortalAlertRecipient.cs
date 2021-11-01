using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    public partial class ClientPortalAlertRecipient
    {
        [Key]
        [Column("ALERT_ID")]
        public int AlertId { get; set; }
        [Key]
        [Column("ALERT_RCPT_ID")]
        public int AlertRcptId { get; set; }
        [Column("CDP_CONTACT_ID")]
        public int CdpContactId { get; set; }
        [Column("EMAIL_ADDRESS")]
        [StringLength(50)]
        public string EmailAddress { get; set; }
        [Column("PROCESSED", TypeName = "smalldatetime")]
        public DateTime? Processed { get; set; }
        [Column("NEW_ALERT")]
        public short? NewAlert { get; set; }
        [Column("READ_ALERT")]
        public short? ReadAlert { get; set; }
        [Column("CURRENT_RCPT")]
        public short? CurrentRcpt { get; set; }
        [Column("CURRENT_NOTIFY")]
        public int? CurrentNotify { get; set; }
        [Column("CS_IS_REVIEWER")]
        public bool? CsIsReviewer { get; set; }
        [Column("IS_DELETED")]
        public bool? IsDeleted { get; set; }
        [Column("PROOFING_STATUS_ID")]
        public int? ProofingStatusId { get; set; }

        [ForeignKey(nameof(AlertId))]
        [InverseProperty("ClientPortalAlertRecipients")]
        public virtual Alert Alert { get; set; }
    }
}
