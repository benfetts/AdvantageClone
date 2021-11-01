
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("JOB_TRAFFIC_DET_CMTS")]
    public partial class ProjectScheduleComment
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
        [Column("CREATE_USER")]
        [StringLength(100)]
        public string CreateUser { get; set; }
        [Column("CREATE_DATE", TypeName = "smalldatetime")]
        public DateTime? CreateDate { get; set; }
        [Column("CREATE_TIME", TypeName = "smalldatetime")]
        public DateTime? CreateTime { get; set; }
        [Column("COMMENT", TypeName = "text")]
        public string Comment { get; set; }

        [ForeignKey("JobNumber,JobComponentNbr,SeqNbr")]
        public virtual JobTrafficDet JobTrafficDet { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}