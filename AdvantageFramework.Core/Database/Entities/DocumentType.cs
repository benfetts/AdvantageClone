
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("DOCUMENT_TYPE")]
    public partial class DocumentType
    {
        public DocumentType()
        {
            Documents = new HashSet<Document>();
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
        [Column("DOCUMENT_TYPE_ID")]
        public int DocumentTypeId { get; set; }
        [Column("DOCUMENT_TYPE_DESC")]
        [StringLength(20)]
        public string DocumentTypeDesc { get; set; }
        [Column("INACTIVE_FLAG")]
        public bool? InactiveFlag { get; set; }
        [Column("IS_DEFAULT")]
        public bool? IsDefault { get; set; }

        [InverseProperty(nameof(Document.DocumentType))]
        public virtual ICollection<Document> Documents { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}