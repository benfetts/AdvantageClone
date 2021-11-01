
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("JOB_TRAFFIC_DET_DOCS")]
    public partial class ProjectScheduleDocument
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

        [Column("ROWID")]
        public int Rowid { get; set; }
        [Key]
        [Column("DOCUMENT_ID")]
        public int DocumentId { get; set; }
        [Key]
        [Column("JOB_NUMBER")]
        public int JobNumber { get; set; }
        [Key]
        [Column("JOB_COMPONENT_NBR")]
        public short JobComponentNbr { get; set; }
        [Key]
        [Column("SEQ_NBR")]
        public short SeqNbr { get; set; }

        [ForeignKey(nameof(DocumentId))]
        [InverseProperty("JobTrafficDetDocs")]
        public virtual Document Document { get; set; }
        [ForeignKey("JobNumber,JobComponentNbr,SeqNbr")]
        [InverseProperty("JobTrafficDetDocs")]
        public virtual JobTrafficDet JobTrafficDet { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}