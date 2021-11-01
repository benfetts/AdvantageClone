
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("JOB_TRAFFIC_DET_CNTS")]
    public partial class ProjectScheduleContact
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
        [Column("CDP_CONTACT_ID")]
        public int CdpContactId { get; set; }

        [ForeignKey("JobNumber,JobComponentNbr,SeqNbr")]
        [InverseProperty("JobTrafficDetCnts")]
        public virtual JobTrafficDet JobTrafficDet { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}