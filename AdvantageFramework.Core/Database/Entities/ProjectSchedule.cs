
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("JOB_TRAFFIC")]
    public partial class ProjectSchedule
    {
        public ProjectSchedule()
        {
            JobTrafficPreds = new HashSet<ProjectSchedulePredecessor>();
        }

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
        [Column("JOB_NUMBER")]
        public int JobNumber { get; set; }
        [Key]
        [Column("JOB_COMPONENT_NBR")]
        public short JobComponentNbr { get; set; }
        [Column("TRF_CODE")]
        [StringLength(10)]
        public string TrfCode { get; set; }
        [Column("TRF_PRESET_CODE")]
        [StringLength(6)]
        public string TrfPresetCode { get; set; }
        [Column("TRF_COMMENTS", TypeName = "text")]
        public string TrfComments { get; set; }
        [Column("ASSIGN_1")]
        [StringLength(6)]
        public string Assign1 { get; set; }
        [Column("ASSIGN_2")]
        [StringLength(6)]
        public string Assign2 { get; set; }
        [Column("ASSIGN_3")]
        [StringLength(6)]
        public string Assign3 { get; set; }
        [Column("ASSIGN_4")]
        [StringLength(6)]
        public string Assign4 { get; set; }
        [Column("ASSIGN_5")]
        [StringLength(6)]
        public string Assign5 { get; set; }
        [Column("COMPLETED_DATE", TypeName = "smalldatetime")]
        public DateTime? CompletedDate { get; set; }
        [Column("DATE_DELIVERED", TypeName = "smalldatetime")]
        public DateTime? DateDelivered { get; set; }
        [Column("DATE_SHIPPED", TypeName = "smalldatetime")]
        public DateTime? DateShipped { get; set; }
        [Column("RECEIVED_BY")]
        [StringLength(40)]
        public string ReceivedBy { get; set; }
        [Column("REFERENCE")]
        [StringLength(150)]
        public string Reference { get; set; }
        [Column("ROWID")]
        public int Rowid { get; set; }
        [Column("MGR_EMP_CODE")]
        [StringLength(6)]
        public string MgrEmpCode { get; set; }
        [Column("LOCK_USER")]
        [StringLength(100)]
        public string LockUser { get; set; }
        [Column("LOCKED_USER")]
        [StringLength(100)]
        public string LockedUser { get; set; }
        [Column("PERCENT_COMPLETE", TypeName = "decimal(7, 3)")]
        public decimal? PercentComplete { get; set; }
        [Column("SCHEDULE_CALC")]
        public int? ScheduleCalc { get; set; }
        [Column("AUTO_UPDATE_STATUS")]
        public bool? AutoUpdateStatus { get; set; }
        [Column("JOB_TRAFFIC_VER_ID")]
        public int? JobTrafficVerId { get; set; }
        [Column("VERSION_LAST_APPLIED", TypeName = "smalldatetime")]
        public DateTime? VersionLastApplied { get; set; }
        [Column("IS_TEMPLATE")]
        public bool IsTemplate { get; set; }

        [ForeignKey("JobNumber,JobComponentNbr")]
        [InverseProperty(nameof(JobComponent.JobTraffic))]
        public virtual JobComponent Job { get; set; }
        [InverseProperty(nameof(ProjectSchedulePredecessor.Job))]
        public virtual ICollection<ProjectSchedulePredecessor> JobTrafficPreds { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}