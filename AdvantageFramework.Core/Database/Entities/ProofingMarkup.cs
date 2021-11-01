
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("PROOFING_MARKUP")]
    public partial class ProofingMarkup
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
        [Required]
        [Column("MARKUP_XML", TypeName = "xml")]
        public string MarkupXml { get; set; }
        /// <summary>
        /// Content of markup to redraw
        /// </summary>
        [Required]
        [Column("MARKUP")]
        public string Markup { get; set; }
        /// <summary>
        /// Employee code of wh marked it up
        /// </summary>
        [Column("EMP_CODE")]
        [StringLength(6)]
        public string EmpCode { get; set; }
        /// <summary>
        /// Base document ID
        /// </summary>
        [Column("DOCUMENT_ID")]
        public int DocumentId { get; set; }
        /// <summary>
        /// Date markup created
        /// </summary>
        [Column("GENERATED_DATE", TypeName = "smalldatetime")]
        public DateTime Generated { get; set; }
        [Column("MARKUP_TYPE_ID")]
        public int MarkupTypeId { get; set; }
        [Column("COMMENT_ID")]
        public int? CommentId { get; set; }
        [Column("THUMBNAIL", TypeName = "image")]
        public byte[] Thumbnail { get; set; }
        [Column("SEQ_NBR")]
        public short? SeqNbr { get; set; }
        [Column("PROOFING_X_REVIEWER_ID")]
        public int? ProofingXReviwerId { get; set; }

        [NotMapped] 
        public int? AlertId { get; set; }
        #endregion

        #region Methods



        #endregion
    }
}
