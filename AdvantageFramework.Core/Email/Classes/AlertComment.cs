using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantageFramework.Core.Email.Classes
{
    [Serializable]
    public class AlertComment
    {
        #region  Constants 



        #endregion

        #region  Enum 



        #endregion

        #region  Variables 



        #endregion

        #region  Properties 

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
                if (GeneratedDate is object)
                {
                    return GeneratedDate.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string sCustodyStartDate
        {
            get
            {
                if (CustodyStartDate is object)
                {
                    return CustodyStartDate.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string sCustodyEndDate
        {
            get
            {
                if (CustodyEndDate is object)
                {
                    return CustodyEndDate.ToString();
                }
                else
                {
                    return string.Empty;
                }
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
        public int ParentID { get; set; }
        public int ReplyLevel { get; set; }
        public string DocumentList { get; set; }
        public List<CommentDocument> Documents { get; set; }
        public List<AlertComment> Replies { get; set; }

        #endregion

        #region  Methods 
        public AlertComment()
        {
        }

        #endregion

        #region  Classes 

        public partial class CommentDocument
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }

        #endregion
    }
}
