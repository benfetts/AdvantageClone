
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("ALERT_EMP_HOURS")]
    public partial class AlertEmployeeHour
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
        [Required]
        [Column("EMP_CODE")]
        [StringLength(6)]
        public string EmpCode { get; set; }
        [Column("PERC_COMPLETE")]
        public short? PercComplete { get; set; }
        [Column("COMPLETED_DATE", TypeName = "smalldatetime")]
        public DateTime? CompletedDate { get; set; }
        [Column("HOURS_ALLOWED", TypeName = "decimal(8, 2)")]
        public decimal? HoursAllowed { get; set; }
        [Column("ALERT_STATE_ID")]
        public int? AlertStateId { get; set; }
        [Column("ALRT_NOTIFY_HDR_ID")]
        public int? AlrtNotifyHdrId { get; set; }

        [ForeignKey(nameof(AlertId))]
        [InverseProperty("AlertEmpHours")]
        public virtual Alert Alert { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}