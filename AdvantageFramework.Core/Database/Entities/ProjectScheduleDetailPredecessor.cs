
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("JOB_TRAFFIC_DET_PREDS")]
    public partial class ProjectScheduleDetailPredecessor
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
        [Column("PREDECESSOR_SEQ_NBR")]
        public short PredecessorSeqNbr { get; set; }

        [ForeignKey("JobNumber,JobComponentNbr,PredecessorSeqNbr")]
        [InverseProperty("JobTrafficDetPredJobTrafficDets")]
        public virtual JobTrafficDet JobTrafficDet { get; set; }
        [ForeignKey("JobNumber,JobComponentNbr,SeqNbr")]
        [InverseProperty("JobTrafficDetPredJobTrafficDetNavigations")]
        public virtual JobTrafficDet JobTrafficDetNavigation { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}