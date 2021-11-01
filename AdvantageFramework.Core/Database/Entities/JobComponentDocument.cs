
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("JOB_COMPONENT_DOCUMENTS")]
    public partial class JobComponentDocument
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
        [Column("DOCUMENT_ID")]
        public int DocumentId { get; set; }
        [Key]
        [Column("JOB_COMPONENT_NUMBER")]
        public short JobComponentNumber { get; set; }
        [Key]
        [Column("JOB_NUMBER")]
        public int JobNumber { get; set; }

        [ForeignKey(nameof(DocumentId))]
        [InverseProperty("JobComponentDocuments")]
        public virtual Document Document { get; set; }
        [ForeignKey("JobNumber,JobComponentNumber")]
        [InverseProperty(nameof(JobComponent.JobComponentDocuments))]
        public virtual JobComponent Job { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}