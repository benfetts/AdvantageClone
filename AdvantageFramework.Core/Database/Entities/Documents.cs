using System;
using System.Collections.Generic;

namespace AdvantageFramework.Core.Database.Entities
{
    public partial class Documents
    {

        #region Constants



        #endregion

        #region Enum
        public enum Properties
        {
            DocumentId,
            RepositoryFilename,
            MimeType,
            Description,
            Keywords,
            UploadedDate,
            UserCode,
            FileSize,
            PrivateFlag,
            DocumentTypeId,
            ProofhqUrl,
            ProofhqFileid,
            Thumbnail,
        }

        #endregion

        #region Variables



        #endregion

        #region Properties
        public int DocumentId { get; set; }
        public string Filename { get; set; }
        public string RepositoryFilename { get; set; }
        public string MimeType { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public DateTime UploadedDate { get; set; }
        public string UserCode { get; set; }
        public int FileSize { get; set; }
        public int? PrivateFlag { get; set; }
        public int? DocumentTypeId { get; set; }
        public string ProofhqUrl { get; set; }
        public int? ProofhqFileid { get; set; }
        public byte[] Thumbnail { get; set; }

        #endregion

        #region Methods



        #endregion

    }
}