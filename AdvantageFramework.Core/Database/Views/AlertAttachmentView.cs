using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantageFramework.Core.Database.Views
{
    public partial class AlertAttachmentView
    {
        [Column("AttachmentID")]
        public int AttachmentId { get; set; }
        [Column("AlertID")]
        public int AlertId { get; set; }
        [StringLength(100)]
        public string RealFileName { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime AddedDate { get; set; }
        [Required]
        [StringLength(1)]
        public string UserName { get; set; }
        [Required]
        [StringLength(255)]
        public string MimeType { get; set; }
        [Column("EMAILSENT")]
        public bool Emailsent { get; set; }
        [Required]
        [Column("REPOSITORY_FILENAME")]
        [StringLength(200)]
        public string RepositoryFilename { get; set; }
        [Column("DOCUMENT_ID")]
        public int DocumentId { get; set; }
        [Column("FILE_SIZE")]
        public int FileSize { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        [Column("USER_CODE")]
        [StringLength(100)]
        public string UserCode { get; set; }
        [Column("PRIVATE_FLAG")]
        public int PrivateFlag { get; set; }
    }
}
