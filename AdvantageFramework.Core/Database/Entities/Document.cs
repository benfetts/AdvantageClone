
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Entities
{
    [Table("DOCUMENTS")]
    public partial class Document
    {
        public Document()
        {
            AlertAttachments = new HashSet<AlertAttachment>();
            JobComponentDocuments = new HashSet<JobComponentDocument>();
            JobTrafficDetDocs = new HashSet<ProjectScheduleDocument>();
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
        [Column("DOCUMENT_ID")]
        public int DocumentId { get; set; }
        [Column("FILENAME")]
        [StringLength(300)]
        public string Filename { get; set; }
        [Required]
        [Column("REPOSITORY_FILENAME")]
        [StringLength(200)]
        public string RepositoryFilename { get; set; }
        [Required]
        [Column("MIME_TYPE")]
        [StringLength(255)]
        public string MimeType { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(200)]
        public string Description { get; set; }
        [Column("KEYWORDS")]
        [StringLength(255)]
        public string Keywords { get; set; }
        [Column("UPLOADED_DATE", TypeName = "datetime")]
        public DateTime UploadedDate { get; set; }
        [Column("USER_CODE")]
        [StringLength(100)]
        public string UserCode { get; set; }
        [Column("FILE_SIZE")]
        public int FileSize { get; set; }
        [Column("PRIVATE_FLAG")]
        public int? PrivateFlag { get; set; }
        [Column("DOCUMENT_TYPE_ID")]
        public int? DocumentTypeId { get; set; }
        [Column("PROOFHQ_URL")]
        public string ProofhqUrl { get; set; }
        [Column("PROOFHQ_FILEID")]
        public int? ProofhqFileid { get; set; }
        [Column("THUMBNAIL", TypeName = "image")]
        public byte[] Thumbnail { get; set; }

        [ForeignKey(nameof(DocumentTypeId))]
        [InverseProperty("Documents")]
        public virtual DocumentType DocumentType { get; set; }
        [InverseProperty("Document")]
        public virtual JobDocument JobDocument { get; set; }
        [InverseProperty("Document")]
        public virtual ProductDocument ProductDocument { get; set; }
        [InverseProperty(nameof(AlertAttachment.Document))]
        public virtual ICollection<AlertAttachment> AlertAttachments { get; set; }
        [InverseProperty(nameof(JobComponentDocument.Document))]
        public virtual ICollection<JobComponentDocument> JobComponentDocuments { get; set; }
        [InverseProperty(nameof(ProjectScheduleDocument.Document))]
        public virtual ICollection<ProjectScheduleDocument> JobTrafficDetDocs { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}