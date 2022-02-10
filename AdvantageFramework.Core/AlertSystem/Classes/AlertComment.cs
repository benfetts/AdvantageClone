using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace AdvantageFramework.Core.AlertSystem.Classes
{
    [Serializable]
    public class AlertComment
    {
        #region Constants



        #endregion

        #region Enum
        public enum Properties
        {
            RowID,
            CommentID,
            AlertID,
            GeneratedDate,
            CustodyStartDate,
            CustodyEndDate,
            sGeneratedDate,
            sCustodyStartDate,
            sCustodyEndDate,
            Comment,
            UserName,
            UserCode,
            EmployeeCode,
            EmployeeFullName,
            EmployeeNickname,
            AssignedEmployeeCode,
            AssignedEmployeeFullName,
            AssignedEmployeeNickname,
            AlertTemplateID,
            AlertTemplateName,
            AlertStateID,
            AlertStateName,
            AssignmentChanged,
            IsUnassigned,
            ParentID,
            ReplyLevel,
            DocumentList,
            Documents,
            Replies,
            MarkupID,
            MarkupXML,
            Markup,
            MarkupDocumentID,
            MarkupGeneratedDate,
            MarkupTypeID,
            MarkupThumbnail
        }

        #endregion

        #region Variables



        #endregion

        #region Properties
        [Key]
        public int RowID { get; set; }
        public int CommentID { get; set; }
        public int AlertID { get; set; }
        public DateTime? GeneratedDate { get; set; }
        public DateTime? CustodyStartDate { get; set; }
        public DateTime? CustodyEndDate { get; set; }
        public string sGeneratedDate
        {
            get
            {
                if (GeneratedDate != null)
                    return GeneratedDate.ToString();
                else
                    return string.Empty;
            }
        }
        public string sCustodyStartDate
        {
            get
            {
                if (CustodyStartDate != null)
                    return CustodyStartDate.ToString();
                else
                    return string.Empty;
            }
        }
        public string sCustodyEndDate
        {
            get
            {
                if (CustodyEndDate != null)
                    return CustodyEndDate.ToString();
                else
                    return string.Empty;
            }
        }
        public string Comment { get; set; }
        public string UserName { get; set; }
        public string UserCode { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeFullName { get; set; }
        public string EmployeeNickname { get; set; }
        public string AssignedEmployeeCode { get; set; }
        public string AssignedEmployeeFullName { get; set; }
        public string AssignedEmployeeNickname { get; set; }
        public int? AlertTemplateID { get; set; }
        public string AlertTemplateName { get; set; }
        public int? AlertStateID { get; set; }
        public string AlertStateName { get; set; }
        public bool AssignmentChanged { get; set; }
        public bool IsUnassigned { get; set; }
        public int? ParentID { get; set; }
        public int? ReplyLevel { get; set; }
        public string DocumentList { get; set; }
        public System.Collections.Generic.List<CommentDocument> Documents { get; set; }
        public System.Collections.Generic.List<AlertComment> Replies { get; set; }
        public int? MarkupID { get; set; }
        public string MarkupXML { get; set; }
        public string Markup { get; set; }
        public int? MarkupDocumentID { get; set; }
        public DateTime? MarkupGeneratedDate { get; set; }
        public string sMarkupGeneratedDate
        {
            get
            {
                if (MarkupGeneratedDate != null)
                    return MarkupGeneratedDate.ToString();
                else
                    return string.Empty;
            }
        }
        public int? MarkupTypeID { get; set; }
        public byte[] MarkupThumbnail { get; set; }
        public bool? IsMyComment { get; set; }
        public int? DocumentID { get; set; }
        public string Initials { get; set; }
        public bool? HasImage { get; set; }
        public int? ProofingExternalReviewerID { get; set; }

        #endregion

        #region Methods
        public AlertComment()
        {
        }

        #endregion

        #region Classes

        [Serializable]
        public class CommentDocument
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Title { get; set; }
            public string Link { get; set; }
            public string MimeType { get; set; }
            public CommentDocument()
            {
            }
        }

        #endregion
    }
}
