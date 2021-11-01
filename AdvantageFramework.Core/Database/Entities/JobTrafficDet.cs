
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("JOB_TRAFFIC_DET")]
    public partial class JobTrafficDet
    {
        public JobTrafficDet()
        {
            JobTrafficDetCnts = new HashSet<ProjectScheduleContact>();
            JobTrafficDetDocs = new HashSet<ProjectScheduleDocument>();
            JobTrafficDetEmps = new HashSet<ProjectScheduleEmployee>();
            JobTrafficDetPredJobTrafficDetNavigations = new HashSet<ProjectScheduleDetailPredecessor>();
            JobTrafficDetPredJobTrafficDets = new HashSet<ProjectScheduleDetailPredecessor>();
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
        [Key]
        [Column("SEQ_NBR")]
        public short SeqNbr { get; set; }
        [Column("FNC_CODE")]
        [StringLength(10)]
        public string FncCode { get; set; }
        [Column("FNC_EST")]
        [StringLength(6)]
        public string FncEst { get; set; }
        [Column("TASK_DESCRIPTION")]
        [StringLength(40)]
        public string TaskDescription { get; set; }
        [Column("TASK_START_DATE", TypeName = "smalldatetime")]
        public DateTime? TaskStartDate { get; set; }
        [Column("JOB_DUE_DATE", TypeName = "smalldatetime")]
        public DateTime? JobDueDate { get; set; }
        [Column("JOB_REVISED_DATE", TypeName = "smalldatetime")]
        public DateTime? JobRevisedDate { get; set; }
        [Column("DUE_DATE_LOCK")]
        public short? DueDateLock { get; set; }
        [Column("JOB_COMPLETED_DATE", TypeName = "smalldatetime")]
        public DateTime? JobCompletedDate { get; set; }
        [Column("JOB_ORDER")]
        public short? JobOrder { get; set; }
        [Column("JOB_DAYS")]
        public short? JobDays { get; set; }
        [Column("PARENT_TASK")]
        [StringLength(10)]
        public string ParentTask { get; set; }
        [Column("FNC_COMMENTS", TypeName = "text")]
        public string FncComments { get; set; }
        [Column("DUE_DATE_COMMENTS", TypeName = "text")]
        public string DueDateComments { get; set; }
        [Column("REV_DATE_COMMENTS", TypeName = "text")]
        public string RevDateComments { get; set; }
        [Column("JOB_HRS", TypeName = "decimal(8, 2)")]
        public decimal? JobHrs { get; set; }
        [Column("DUE_TIME")]
        [StringLength(10)]
        public string DueTime { get; set; }
        [Column("REVISED_DUE_TIME")]
        [StringLength(10)]
        public string RevisedDueTime { get; set; }
        [Column("TASK_STATUS")]
        [StringLength(1)]
        public string TaskStatus { get; set; }
        [Column("MILESTONE")]
        public short? Milestone { get; set; }
        [Column("TRAFFIC_PHASE_ID")]
        public int? TrafficPhaseId { get; set; }
        [Column("ROWID")]
        public int Rowid { get; set; }
        [Column("TEMP_SEQ")]
        public short? TempSeq { get; set; }
        [Column("TRF_ROLE")]
        [StringLength(6)]
        public string TrfRole { get; set; }
        [Column("HOURS_ASSIGNED", TypeName = "decimal(15, 2)")]
        public decimal? HoursAssigned { get; set; }
        [Column("EMP_CODE")]
        [StringLength(6)]
        public string EmpCode { get; set; }
        [Column("TEMP_COMP_DATE", TypeName = "smalldatetime")]
        public DateTime? TempCompDate { get; set; }
        [Column("PARENT_TASK_SEQ")]
        public short? ParentTaskSeq { get; set; }
        [Column("GRID_ORDER")]
        public short? GridOrder { get; set; }

        [ForeignKey("JobNumber,JobComponentNbr")]
        [InverseProperty(nameof(JobComponent.JobTrafficDets))]
        public virtual JobComponent Job { get; set; }
        [InverseProperty(nameof(ProjectScheduleContact.JobTrafficDet))]
        public virtual ICollection<ProjectScheduleContact> JobTrafficDetCnts { get; set; }
        [InverseProperty(nameof(ProjectScheduleDocument.JobTrafficDet))]
        public virtual ICollection<ProjectScheduleDocument> JobTrafficDetDocs { get; set; }
        [InverseProperty(nameof(ProjectScheduleEmployee.JobTrafficDet))]
        public virtual ICollection<ProjectScheduleEmployee> JobTrafficDetEmps { get; set; }
        [InverseProperty(nameof(ProjectScheduleDetailPredecessor.JobTrafficDetNavigation))]
        public virtual ICollection<ProjectScheduleDetailPredecessor> JobTrafficDetPredJobTrafficDetNavigations { get; set; }
        [InverseProperty(nameof(ProjectScheduleDetailPredecessor.JobTrafficDet))]
        public virtual ICollection<ProjectScheduleDetailPredecessor> JobTrafficDetPredJobTrafficDets { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}
