
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("ALERT_RCPT")]
    public partial class AlertRecipient
    {
        #region Constants



        #endregion

        #region Enum

        public enum Properties
        {
            TBD
        }


        #endregion

        #region Variables



        #endregion

        #region Properties

        [Key]
        [Column("ALERT_ID")]
        public int AlertId { get; set; }
        [Key]
        [Column("ALERT_RCPT_ID")]
        public int AlertRcptId { get; set; }
        [Column("EMP_CODE")]
        [StringLength(6)]
        public string EmpCode { get; set; }
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
        [Column("CARD_SEQ_NBR")]
        public int? CardSeqNbr { get; set; }
        [Column("CS_IS_REVIEWER")]
        public bool? CsIsReviewer { get; set; }
        [Column("IS_DELETED")]
        public bool? IsDeleted { get; set; }
        [Column("ALRT_NOTIFY_HDR_ID")]
        public int? AlrtNotifyHdrId { get; set; }
        [Column("ALERT_STATE_ID")]
        public int? AlertStateId { get; set; }
        [Column("PERC_COMPLETE")]
        public short? PercComplete { get; set; }
        [Column("COMPLETED_DATE", TypeName = "smalldatetime")]
        public DateTime? CompletedDate { get; set; }
        [Column("TEMP_COMP_DATE", TypeName = "smalldatetime")]
        public DateTime? TempCompDate { get; set; }
        [Column("HOURS_ALLOWED", TypeName = "decimal(8, 2)")]
        public decimal? HoursAllowed { get; set; }
        [Column("LAST_ASSIGNED")]
        public bool? LastAssigned { get; set; }

        [ForeignKey(nameof(AlertId))]
        [InverseProperty("AlertRcpts")]
        public virtual Alert Alert { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}