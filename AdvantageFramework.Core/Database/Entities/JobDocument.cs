
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("JOB_DOCUMENTS")]
    public partial class JobDocument
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
        [Column("JOB_NUMBER")]
        public int JobNumber { get; set; }

        [ForeignKey(nameof(DocumentId))]
        [InverseProperty("JobDocument")]
        public virtual Document Document { get; set; }
        [ForeignKey(nameof(JobNumber))]
        [InverseProperty(nameof(Job.JobDocuments))]
        public virtual Job JobNumberNavigation { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}