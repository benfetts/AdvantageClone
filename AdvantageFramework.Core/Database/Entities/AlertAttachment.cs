
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("ALERT_ATTACHMENT")]
    public partial class AlertAttachment
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
        [Column("ATTACHMENT_ID")]
        public int AttachmentId { get; set; }
        [Column("ALERT_ID")]
        public int AlertId { get; set; }
        [Required]
        [Column("USER_CODE")]
        [StringLength(100)]
        public string UserCode { get; set; }
        [Column("GENERATED_DATE", TypeName = "smalldatetime")]
        public DateTime GeneratedDate { get; set; }
        [Required]
        [Column("EMAILSENT")]
        public bool? Emailsent { get; set; }
        [Column("DOCUMENT_ID")]
        public int DocumentId { get; set; }
        [Column("USER_CODE_CP")]
        public int? UserCodeCp { get; set; }
        [Column("THUMBNAIL")]
        public byte[] Thumbnail { get; set; }

        [ForeignKey(nameof(AlertId))]
        [InverseProperty("AlertAttachments")]
        public virtual Alert Alert { get; set; }
        [ForeignKey(nameof(DocumentId))]
        [InverseProperty("AlertAttachments")]
        public virtual Document Document { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}
