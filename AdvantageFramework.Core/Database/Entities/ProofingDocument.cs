
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("PROOFING_DOCUMENT")]
    public partial class ProofingDocument
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
        [Column("ALERT_ID")]
        public int? AlertId { get; set; }
        [Column("USER_CODE")]
        [StringLength(100)]
        public string UserCode { get; set; }
        [Column("GENERATED_DATE", TypeName = "datetime")]
        public DateTime? GeneratedDate { get; set; }
        [Column("DOCUMENT_ID")]
        public int? DocumentId { get; set; }
        [Column("ORIGINAL_DOCUMENT_ID")]
        public int? OriginalDocumentId { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}