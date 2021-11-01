
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("JOB_TRAFFIC_DET_EMPS")]
    public partial class ProjectScheduleEmployee
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
        [Column("JOB_NUMBER")]
        public int JobNumber { get; set; }
        [Column("JOB_COMPONENT_NBR")]
        public short JobComponentNbr { get; set; }
        [Column("SEQ_NBR")]
        public short SeqNbr { get; set; }
        [Required]
        [Column("EMP_CODE")]
        [StringLength(6)]
        public string EmpCode { get; set; }
        [Column("HOURS_ALLOWED", TypeName = "decimal(8, 2)")]
        public decimal? HoursAllowed { get; set; }
        [Column("TEMP_COMP_DATE", TypeName = "smalldatetime")]
        public DateTime? TempCompDate { get; set; }
        [Column("COMPLETED_COMMENTS", TypeName = "text")]
        public string CompletedComments { get; set; }
        [Column("PERCENT_COMPLETE", TypeName = "decimal(7, 3)")]
        public decimal? PercentComplete { get; set; }
        [Column("CARD_SEQ_NBR")]
        public int? CardSeqNbr { get; set; }
        [Column("READ_ALERT")]
        public bool? ReadAlert { get; set; }

        [ForeignKey("JobNumber,JobComponentNbr,SeqNbr")]
        [InverseProperty("JobTrafficDetEmps")]
        public virtual JobTrafficDet JobTrafficDet { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}