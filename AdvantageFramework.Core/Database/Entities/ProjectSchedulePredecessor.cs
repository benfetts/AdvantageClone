
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("JOB_TRAFFIC_PREDS")]
    public partial class ProjectSchedulePredecessor
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
        [Column("JOB_PRED")]
        public int JobPred { get; set; }
        [Column("JOB_COMP_PRED")]
        public short JobCompPred { get; set; }

        [ForeignKey("JobNumber,JobComponentNbr")]
        [InverseProperty(nameof(ProjectSchedule.JobTrafficPreds))]
        public virtual ProjectSchedule Job { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}