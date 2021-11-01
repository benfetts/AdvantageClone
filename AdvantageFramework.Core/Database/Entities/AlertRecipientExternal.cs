
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("ALERT_RCPT_EXT")]
    public partial class AlertRecipientExternal
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
        [Column("ID")]
        public int Id { get; set; }
        [Column("ALERT_ID")]
        public int AlertId { get; set; }
        [Column("PRF_EXT_ID")]
        public int PrfExtId { get; set; }
        [Column("IS_DISMISSED")]
        public bool? IsDismissed { get; set; }
        [Column("IS_COMPLETED")]
        public bool? IsCompleted { get; set; }
        [Column("IS_READ")]
        public bool? IsRead { get; set; }

        [ForeignKey(nameof(AlertId))]
        [InverseProperty("AlertRcptExts")]
        public virtual Alert Alert { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}